using LmCorbieUI.Design;
using LmCorbieUI.Interfaces;
using LmCorbieUI.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;

namespace LmCorbieUI.Controls
{
    [ProvideToolboxControl()]
    [ToolboxBitmap(typeof(TabControl))]
    [DefaultEvent("Load")]
    [Designer(typeof(LmCorbieUI.Controls.Design.LmTabControlDesigner))]
    public partial class LmTabControl : TabControl, ILmControl
    {
        #region Construtor

        public LmTabControl()
        {
            SetStyle(ControlStyles.UserPaint |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.SupportsTransparentBackColor, true);

            Padding = new Point(6, 8);
            this.Selecting += CmxTabControl_Selecting;

        }

        #endregion

        #region Interface

        [Category(LmDefault.PropertyCategory.LmUI)]
        public event EventHandler<LmPaintEventArgs> CustomPaintBackground;
        protected virtual void OnCustomPaintBackground(LmPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintBackground != null)
            {
                CustomPaintBackground(this, e);
            }
        }

        [Category(LmDefault.PropertyCategory.LmUI)]
        public event EventHandler<LmPaintEventArgs> CustomPaint;
        protected virtual void OnCustomPaint(LmPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaint != null)
            {
                CustomPaint(this, e);
            }
        }

        [Category(LmDefault.PropertyCategory.LmUI)]
        public event EventHandler<LmPaintEventArgs> CustomPaintForeground;
        protected virtual void OnCustomPaintForeground(LmPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintForeground != null)
            {
                CustomPaintForeground(this, e);
            }
        }

        private bool useCustomBackColor = false;
        [DefaultValue(false)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        public bool UseCustomBackColor
        {
            get { return useCustomBackColor; }
            set { useCustomBackColor = value; }
        }

        private bool useCustomForeColor = false;
        [DefaultValue(false)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        public bool UseCustomForeColor
        {
            get { return useCustomForeColor; }
            set { useCustomForeColor = value; }
        }

        private bool useStyleColors = false;
        [DefaultValue(false)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        public bool UseStyleColors
        {
            get { return useStyleColors; }
            set { useStyleColors = value; }
        }

        [Browsable(false)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        [DefaultValue(false)]
        public bool UseSelectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, value); }
        }

        #endregion

        #region Fields

        //Additional variables to be used by HideTab and ShowTab
        private List<string> tabDisable = new List<string>();
        private List<string> tabOrder = new List<string>();
        private List<HiddenTabs> hidTabs = new List<HiddenTabs>();

        private SubClass scUpDown = null;
        private bool bUpDown = false;

        private const int TabBottomBorderHeight = 3;

        private LmTabControlSize lmLabelSize = LmTabControlSize.Medium;
        [DefaultValue(LmTabControlSize.Medium)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        public LmTabControlSize FontSize
        {
            get { return lmLabelSize; }
            set { lmLabelSize = value; }
        }

        private LmTabControlWeight lmLabelWeight = LmTabControlWeight.Regular;
        [DefaultValue(LmTabControlWeight.Regular)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        public LmTabControlWeight FontWeight
        {
            get { return lmLabelWeight; }
            set { lmLabelWeight = value; }
        }

        private ContentAlignment textAlign = ContentAlignment.MiddleLeft;
        [DefaultValue(ContentAlignment.MiddleLeft)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        public ContentAlignment TextAlign
        {
            get
            {
                return textAlign;
            }
            set
            {
                textAlign = value;
            }
        }

        [Editor(typeof(Design.LmTabPageCollectionEditor), typeof(UITypeEditor))]
        public new TabPageCollection TabPages
        {
            get
            {
                return base.TabPages;
            }
        }


        private bool isMirrored;
        [DefaultValue(false)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        public new bool IsMirrored
        {
            get
            {
                return isMirrored;
            }
            set
            {
                if (isMirrored == value)
                {
                    return;
                }
                isMirrored = value;
                UpdateStyles();
            }
        }

        #endregion

        #region Paint Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (GetStyle(ControlStyles.AllPaintingInWmPaint))
                {
                    OnPaintBackground(e);
                }

                OnCustomPaint(new LmPaintEventArgs(Color.Empty, Color.Empty, e.Graphics));
                OnPaintForeground(e);
            }
            catch
            {
                Invalidate();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                Color backColor = BackColor;

                if (!useCustomBackColor)
                {
                    backColor = LmCor.Bc_Form;
                }

                if (backColor.A == 255 && BackgroundImage == null)
                {
                    e.Graphics.Clear(backColor);
                    return;
                }

                base.OnPaintBackground(e);
                OnCustomPaintBackground(new LmPaintEventArgs(backColor, Color.Empty, e.Graphics));
            }
            catch
            {
                Invalidate();
            }
        }

        protected virtual void OnPaintForeground(PaintEventArgs e)
        {
            for (var index = 0; index < TabPages.Count; index++)
            {
                if (index != SelectedIndex)
                {
                    DrawTab(index, e.Graphics);
                }
            }
            if (SelectedIndex <= -1)
            {
                return;
            }

            DrawTabBottomBorder(SelectedIndex, e.Graphics);
            DrawTab(SelectedIndex, e.Graphics);
            DrawTabSelected(SelectedIndex, e.Graphics);

            OnCustomPaintForeground(new LmPaintEventArgs(Color.Empty, Color.Empty, e.Graphics));
        }

        private void DrawTabBottomBorder(int index, Graphics graphics)
        {
            using (Brush bgBrush = new SolidBrush(LmCor.Br_Normal))
            {
                Rectangle borderRectangle = new Rectangle(DisplayRectangle.X, GetTabRect(index).Bottom + 2 - TabBottomBorderHeight, DisplayRectangle.Width, TabBottomBorderHeight);
                graphics.FillRectangle(bgBrush, borderRectangle);
            }
        }

        private Size MeasureText(string text)
        {
            Size preferredSize;
            using (Graphics g = CreateGraphics())
            {
                Size proposedSize = new Size(int.MaxValue, int.MaxValue);
                preferredSize = TextRenderer.MeasureText(g, text, LmFonts.TabControl(lmLabelSize, lmLabelWeight),
                                                         proposedSize,
                                                         LmFonts.GetTextFormatFlags(TextAlign) |
                                                         TextFormatFlags.NoPadding);
            }
            return preferredSize;
        }

        private void DrawTabSelected(int index, Graphics graphics)
        {
            using (Brush selectionBrush = new SolidBrush(LmCor.Bc_Header))
            {
                Rectangle selectedTabRect = GetTabRect(index);

                Rectangle borderRectangle = new Rectangle(selectedTabRect.X + ((index == 0) ? 2 : 0),
                    GetTabRect(index).Bottom + 2 - TabBottomBorderHeight, selectedTabRect.Width + ((index == 0) ? 0 : 2),
                    TabBottomBorderHeight);

                graphics.FillRectangle(selectionBrush, borderRectangle); //Draw Botton

                TabPage tabPage = TabPages[index];
                //tabPage.ForeColor = Color.Red;

                Color foreColorSelected = LmCor.Bc_Header;
                Color backColorSelected = Color.Transparent;

                //using (Brush bgBrush = /*new SolidBrush(CmxPaint.GetStyleColor(Style)))*/new SolidBrush(Color.Blue))
                //{
                //    graphics.FillRectangle(bgBrush, selectedTabRect);
                //}

                Rectangle newSelectedTabRect = new Rectangle(selectedTabRect.X + ((index == 0) ? 2 : 0),
                    GetTabRect(index).Y, selectedTabRect.Width + ((index == 0) ? 0 : 2),
                    selectedTabRect.Height);

                TextRenderer.DrawText(graphics, tabPage.Text, LmFonts.TabControl(lmLabelSize, lmLabelWeight),
                                  newSelectedTabRect, foreColorSelected, backColorSelected, LmFonts.GetTextFormatFlags(TextAlign));
            }
        }

        private void DrawTab(int index, Graphics graphics)
        {
            if (SelectedIndex == index) return;

            Color foreColor;
            Color backColor = BackColor;

            if (!useCustomBackColor)
            {
                backColor = LmCor.Bc_Form;
            }

            TabPage tabPage = TabPages[index];
            Rectangle tabRect = GetTabRect(index);

            if (!Enabled || tabDisable.Contains(tabPage.Name))
            {
                foreColor = LmCor.Br_Disabled;
            }
            else
            {
                if (useCustomForeColor)
                {
                    foreColor = DefaultForeColor;
                }
                else
                {
                    foreColor = LmCor.Br_Normal;
                }
            }

            if (index == 0)
            {
                tabRect.X = DisplayRectangle.X;
            }

            Rectangle bgRect = tabRect;

            //using (Brush bgBrush = new SolidBrush(Color.GreenYellow))
            //{
            //    graphics.FillRectangle(bgBrush, bgRect);
            //}

            TextRenderer.DrawText(graphics, tabPage.Text, LmFonts.TabControl(lmLabelSize, lmLabelWeight),
                                  tabRect, foreColor, Color.Transparent, LmFonts.GetTextFormatFlags(TextAlign));
        }

        [SecuritySafeCritical]
        private void DrawUpDown(Graphics graphics)
        {
            Color backColor = Parent != null ? Parent.BackColor : LmCor.Bc_Form;

            Rectangle borderRect = new Rectangle();
            WinApi.GetClientRect(scUpDown.Handle, ref borderRect);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            graphics.Clear(backColor);

            using (Brush b = new SolidBrush(LmCor.Br_Normal))
            {
                GraphicsPath gp = new GraphicsPath(FillMode.Winding);
                PointF[] pts = { new PointF(6, 6), new PointF(16, 0), new PointF(16, 12) };
                gp.AddLines(pts);

                graphics.FillPath(b, gp);

                gp.Reset();

                PointF[] pts2 = { new PointF(borderRect.Width - 15, 0), new PointF(borderRect.Width - 5, 6), new PointF(borderRect.Width - 15, 12) };
                gp.AddLines(pts2);

                graphics.FillPath(b, gp);

                gp.Dispose();
            }
        }

        #endregion

        #region Overridden Methods

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        [SecuritySafeCritical]
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (!DesignMode)
            {
                try
                {
                    WinApi.ShowScrollBar(Handle, (int)WinApi.ScrollBar.SB_BOTH, 0);
                }
                catch (System.ObjectDisposedException)
                {
                    // CmxMessageBox.MsgBox.Show(ex.Message, "Erro ao fechar"); 
                }
            }
        }

        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                const int WS_EX_LAYOUTRTL = 0x400000;
                const int WS_EX_NOINHERITLAYOUT = 0x100000;
                var cp = base.CreateParams;
                if (isMirrored)
                {
                    cp.ExStyle = cp.ExStyle | WS_EX_LAYOUTRTL | WS_EX_NOINHERITLAYOUT;
                }
                return cp;
            }
        }

        private new Rectangle GetTabRect(int index)
        {
            if (index < 0)
                return new Rectangle();

            Rectangle baseRect = base.GetTabRect(index);
            return baseRect;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (SelectedIndex != -1)
            {
                if (!TabPages[SelectedIndex].Focused)
                {
                    bool subControlFocused = false;
                    foreach (Control ctrl in TabPages[SelectedIndex].Controls)
                    {
                        if (ctrl.Focused)
                        {
                            subControlFocused = true;
                            return;
                        }
                    }

                    if (!subControlFocused)
                    {
                        TabPages[SelectedIndex].Select();
                        TabPages[SelectedIndex].Focus();
                    }
                }
            }

            base.OnMouseWheel(e);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.OnFontChanged(EventArgs.Empty);
            FindUpDown();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            FindUpDown();
            UpdateUpDown();
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            FindUpDown();
            UpdateUpDown();
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            UpdateUpDown();
            Invalidate();
        }

        //send font change to properly resize tab page header rects
        //http://www.codeproject.com/Articles/13305/Painting-Your-Own-Tabs?msg=2707590#xx2707590xx
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_SETFONT = 0x30;
        private const int WM_FONTCHANGE = 0x1d;

        [SecuritySafeCritical]
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            IntPtr hFont = LmFonts.TabControl(lmLabelSize, lmLabelWeight).ToHfont();
            SendMessage(this.Handle, WM_SETFONT, hFont, (IntPtr)(-1));
            SendMessage(this.Handle, WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero);
            this.UpdateStyles();
        }

        void CmxTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabDisable.Count > 0 && tabDisable.Contains(e.TabPage.Name))
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Helper Methods

        [SecuritySafeCritical]
        private void FindUpDown()
        {
            if (!DesignMode)
            {
                bool bFound = false;

                IntPtr pWnd = WinApi.GetWindow(Handle, WinApi.GW_CHILD);

                while (pWnd != IntPtr.Zero)
                {
                    char[] className = new char[33];

                    int length = WinApi.GetClassName(pWnd, className, 32);

                    string s = new string(className, 0, length);

                    if (s == "msctls_updown32")
                    {
                        bFound = true;

                        if (!bUpDown)
                        {
                            this.scUpDown = new SubClass(pWnd, true);
                            this.scUpDown.SubClassedWndProc += new SubClass.SubClassWndProcEventHandler(scUpDown_SubClassedWndProc);

                            bUpDown = true;
                        }
                        break;
                    }

                    pWnd = WinApi.GetWindow(pWnd, WinApi.GW_HWNDNEXT);
                }

                if ((!bFound) && (bUpDown))
                    bUpDown = false;
            }
        }

        [SecuritySafeCritical]
        private void UpdateUpDown()
        {
            if (bUpDown && !DesignMode)
            {
                if (WinApi.IsWindowVisible(scUpDown.Handle))
                {
                    Rectangle rect = new Rectangle();
                    WinApi.GetClientRect(scUpDown.Handle, ref rect);
                    WinApi.InvalidateRect(scUpDown.Handle, ref rect, true);
                }
            }
        }

        [SecuritySafeCritical]
        private int scUpDown_SubClassedWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)WinApi.Messages.WM_PAINT:

                    IntPtr hDC = WinApi.GetWindowDC(scUpDown.Handle);

                    Graphics g = Graphics.FromHdc(hDC);

                    DrawUpDown(g);

                    g.Dispose();

                    WinApi.ReleaseDC(scUpDown.Handle, hDC);

                    m.Result = IntPtr.Zero;

                    Rectangle rect = new Rectangle();

                    WinApi.GetClientRect(scUpDown.Handle, ref rect);
                    WinApi.ValidateRect(scUpDown.Handle, ref rect);

                    return 1;
            }

            return 0;
        }

        #endregion


        #region Additional functions by DenRic Denise

        /// <summary>
        /// This will hide LmTabPage from LmTabControl
        /// Hidden LmTabPage can be displayed by calling ShowTab functions
        /// </summary>
        /// <param name="tabpage"></param>
        public void HideTab(LmTabPage tabpage)
        {
            if (this.TabPages.Contains(tabpage))
            {
                int _tabid = this.TabPages.IndexOf(tabpage);

                hidTabs.Add(new HiddenTabs(_tabid, tabpage.Name));
                this.TabPages.Remove(tabpage);
            }
        }

        /// <summary>
        /// This will show hiddent LmTabPage from LmTabControl
        /// </summary>
        /// <param name="tabpage"></param>
        public void ShowTab(LmTabPage tabpage)
        {
            HiddenTabs result = hidTabs.Find(
                 delegate (HiddenTabs bk)
                 {
                     return bk.tabpage == tabpage.Name;
                 }
             );

            if (result != null)
            {
                this.TabPages.Insert(result.index, tabpage);
                hidTabs.Remove(result);
            }
        }

        /// <summary>
        /// This will disable a LmTabPage from LmTabControl
        /// </summary>
        /// <param name="tabpage"></param>
        public void DisableTab(LmTabPage tabpage)
        {
            if (!tabDisable.Contains(tabpage.Name))
            {
                if (this.SelectedTab == tabpage && this.TabCount == 1) return;
                if (this.SelectedTab == tabpage)
                {
                    if (SelectedIndex == this.TabCount - 1)
                    { SelectedIndex = 0; }
                    else { SelectedIndex++; }
                }

                int _tabid = this.TabPages.IndexOf(tabpage);

                tabDisable.Add(tabpage.Name);
                Graphics e = this.CreateGraphics();
                DrawTab(_tabid, e);
                DrawTabBottomBorder(SelectedIndex, e);
                DrawTabSelected(SelectedIndex, e);
            }
        }

        /// <summary>
        /// This will enable a LmTabPage from LmTabControl
        /// </summary>
        /// <param name="tabpage"></param>
        public void EnableTab(LmTabPage tabpage)
        {
            if (tabDisable.Contains(tabpage.Name))
            {
                tabDisable.Remove(tabpage.Name);
                int _tabid = this.TabPages.IndexOf(tabpage);

                Graphics e = this.CreateGraphics();
                DrawTab(_tabid, e);
                DrawTabBottomBorder(SelectedIndex, e);
                DrawTabSelected(SelectedIndex, e);
            }
        }

        /// <summary>
        /// This will check if LmTabPage is enable or not
        /// true if enable otherwise false
        /// </summary>
        /// <param name="tabpage"></param>
        /// <returns></returns>
        public bool IsTabEnable(LmTabPage tabpage)
        {
            return tabDisable.Contains(tabpage.Name);
        }

        /// <summary>
        /// This will check if LmTabPage is hidden or not
        /// true if hidden otherwise false
        /// </summary>
        public bool IsTabHidden(LmTabPage tabpage)
        {
            HiddenTabs result = hidTabs.Find(
                delegate (HiddenTabs bk)
                {
                    return bk.tabpage == tabpage.Name;
                }
            );

            return (result != null);
        }

        #endregion
    }

    #region CmxTabPageCollection

    [ToolboxItem(false)]
    [Editor(typeof(Design.LmTabPageCollectionEditor), typeof(UITypeEditor))]
    public class CmxTabPageCollection : TabControl.TabPageCollection
    {
        public CmxTabPageCollection(LmTabControl owner)
            : base(owner)
        { }
    }

    #endregion

    #region HiddenTabClass

    public class HiddenTabs
    {
        public HiddenTabs(int id, string page)
        {
            _index = id;
            _tabpage = page;
        }

        private int _index;
        private string _tabpage;

        public int index { get { return _index; } }

        public string tabpage { get { return _tabpage; } }
    }

    #endregion HiddenTabClass

}
