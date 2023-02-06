using LmCorbieUI.Controls;
using LmCorbieUI.Design;
using LmCorbieUI.Metodos;
using LmCorbieUI.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LmCorbieUI.LmForms
{
    [ProvideToolboxControl()]
    [ToolboxBitmap(typeof(Form))]
    [DefaultEvent("Load")]
    [Designer(typeof(Design.LmFormDesign), typeof(IRootDesigner))]
    public partial class LmSingleForm : Form, IDisposable
    {
        #region Construtor

        private ToolTip toolTip1;
        public LmSingleForm()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.UserPaint, true);


            this.Padding = new Padding(borderSize);//Border size

            var rec = Screen.FromHandle(this.Handle).WorkingArea;
            this.MaximizedBounds = new Rectangle(0, 0, rec.Width, rec.Height - 1);

            this.toolTip1 = new ToolTip();
            this.SuspendLayout();
            // 
            // LmSingleForm
            // 
            this.FormBorderStyle = FormBorderStyle.None;
            this.ClientSize = new System.Drawing.Size(150, 150);
            this.Name = "LmSingleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = Color.Magenta;
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.Collect();
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Campos

        //Fields
        private int borderSize = 2;
    
        [Browsable(true)]
        public LmFormTextAlign TextAlign { get; set; } = LmFormTextAlign.Left;

        [Browsable(false)]
        public override Color BackColor => LmCor.Bc_Form;

        public new Padding Padding
        {
            get { return base.Padding; }
            set
            {
                base.Padding = value;
            }
        }

        protected override Padding DefaultPadding
        {
            get { return new Padding(2, 30, 2, 2); }
        }

        public bool Resizable { get; set; } = true;

        /// <summary>
        /// Nome do controle usado como Chave primaria
        /// </summary>
        [Browsable(true)]
        public LmTextBox ChavePrimaria { get; set; } = null;

        private Modo _modo = Modo.Padrao;

        [DefaultValue(Modo.Padrao)]
        [Browsable(false)]
        public Modo Modo
        {
            get { return _modo; }
            set { _modo = value; }
        }

        [DefaultValue(false)]
        [Browsable(false)]
        public bool IsClosing { get; set; } = false;

        #endregion

        #region Paint Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            Color foreColor = LmCor.Bc_Header.GetForeColor(LmControlStatus.Normal);

            // Pintar Cabeçalho
            if (ControlBox)
            {
                using (SolidBrush b = new SolidBrush(LmCor.Bc_Header))
                {
                    Rectangle topRect = new Rectangle(0, 0, Width, 30);
                    e.Graphics.FillRectangle(b, topRect);
                }

                // Imprimir Texto
                Rectangle bounds = new Rectangle(15, 5, ClientRectangle.Width - 2 * 30, 45);
                TextFormatFlags flags = TextFormatFlags.EndEllipsis | GetTextFormatFlags();
                TextRenderer.DrawText(e.Graphics, Text, LmFonts.TitleForm, bounds, foreColor, flags);
            }

            // pintar Bordas
            using (Pen pen = new Pen(LmCor.Bc_Header, 2))
            {
                e.Graphics.DrawLines(pen, new[]
                {
                    new Point(1, 1),
                    new Point(1, Height - 1),
                    new Point(Width - 1, Height - 1),
                    new Point(Width - 1, 1),
                    new Point(0, 1)
                });
            }
        }

        private TextFormatFlags GetTextFormatFlags()
        {
            switch (TextAlign)
            {
                case LmFormTextAlign.Left: return TextFormatFlags.Left;
                case LmFormTextAlign.Center: return TextFormatFlags.HorizontalCenter;
                case LmFormTextAlign.Right: return TextFormatFlags.Right;
            }

            throw new InvalidOperationException();
        }

        #endregion

        #region Metodos de Gestão

        public delegate void FormLoad(object sender, EventArgs e);
        public event FormLoad Loaded;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;

            //if (!DesignMode)
            //{
            switch (StartPosition)
            {
                case FormStartPosition.CenterParent:
                    CenterToParent();
                    break;
                case FormStartPosition.CenterScreen:
                    CenterToScreen();

                    break;
            }
            //}

            if (ControlBox)
            {
                AddWindowButton(WindowButtons.Close);

                if (MaximizeBox)
                    AddWindowButton(WindowButtons.Maximize);

                if (MinimizeBox)
                    AddWindowButton(WindowButtons.Minimize);

                //if (HelpButton)
                //    AddWindowButton(WindowButtons.Help);

                //System.Threading.Thread t = new System.Threading.Thread(() => { UpdateWindowButtonPosition(); }) { IsBackground = true };
                //t.Start();
                UpdateWindowButtonPosition();
            }

            System.Threading.Thread t = new System.Threading.Thread(() => { this.OnLoaded(); }) { IsBackground = true };
            t.Start();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Maximized) return;

                ReleaseCapture();
                SendMessage(Handle, (int)WinApi.Messages.WM_NCLBUTTONDOWN, (int)WinApi.Messages.WM_DESTROY, 0);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            try
            {
                IsClosing = true;
            }
            catch (Exception)
            {
            }
        }

        internal void OnLoaded()
        {
            System.Threading.Thread.Sleep(300);

            try
            {
                System.Threading.Thread.Sleep(200);

                if (this.IsClosing) return;

                if (ChavePrimaria != null)
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        ChavePrimaria.Focus();
                        ChavePrimaria.Refresh();
                    }));
                }

                Loaded?.Invoke(this, new EventArgs());
            }
            catch (InvalidOperationException ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
                MessageBox.Show("Evento Loaded deve manipular Objetos com 'Invoke', informar Desenvolvedores",
                    "Erro ao Carregar Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Overridden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;

            #region Form Resize
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTCAPTION = 2; //Represents the client Header of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            const int WM_SIZE = 0x5;

            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>

            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);

                if (Resizable && (int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                {
                    Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                    Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          

                    if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                    {
                        if (RectangleToScreen(new Rectangle(5, 5, ClientRectangle.Width - 10, 30)).Contains(screenPoint))
                        {
                            m.Result = (IntPtr)HTCAPTION;
                        }
                        else if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                    else
                    {
                        if (RectangleToScreen(new Rectangle(5, 5, ClientRectangle.Width - 10, 30)).Contains(screenPoint))
                        {
                            m.Result = (IntPtr)HTCAPTION;
                        }
                    }
                }
                return;
            }
            else if (m.Msg == WM_SIZE)
            {
                if (windowButtonList != null)
                {
                    LmFormButton btn;
                    windowButtonList.TryGetValue(WindowButtons.Maximize, out btn);
                    if (btn == null) return;
                    if (WindowState == FormWindowState.Normal)
                    {
                        this.toolTip1.SetToolTip(btn, "Maximizar");
                        btn.Text = "1";
                    }
                    if (WindowState == FormWindowState.Maximized)
                    {
                        this.toolTip1.SetToolTip(btn, "Rest. Tamanho");
                        btn.Text = "2";
                    }
                }
            }

            #endregion

            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                int sc = m.WParam.ToInt32() & 0xFFF0;
                switch (sc)
                {
                    case (int)WinApi.Messages.SC_MAXIMIZE:
                        break;
                    case (int)WinApi.Messages.SC_RESTORE:
                        break;
                }
            }
            base.WndProc(ref m);
        }

        #endregion

        #region Metodos Públicos

        public void AtualizarPrimaria(bool tornarSomenteLeitura, string texto = "")
        {
            if (ChavePrimaria != null)
            {
                ChavePrimaria.ReadOnly = tornarSomenteLeitura;

                if (!string.IsNullOrEmpty(texto))
                    ChavePrimaria.Text = texto;

                ChavePrimaria.Refresh();
            }
            else
                Controles.UpdatePrimaryKeyControl(this, tornarSomenteLeitura);
        }

        #endregion

        #region Metodos Privados

        #endregion

        #region Window Buttons

        //public delegate void ButClick(object sender, EventArgs e);
        //public event ButClick ClickHelp;

        private enum WindowButtons
        {
            Minimize,
            Maximize,
            Close,
            //Help,
        }

        private Dictionary<WindowButtons, LmFormButton> windowButtonList;

        private void AddWindowButton(WindowButtons button)
        {
            if (windowButtonList == null)
                windowButtonList = new Dictionary<WindowButtons, LmFormButton>();

            if (windowButtonList.ContainsKey(button))
                return;

            LmFormButton newButton = new LmFormButton(button == WindowButtons.Close);
            var fntWeb = new Font("Webdings", 9.25f);

            if (button == WindowButtons.Close)
            {
                this.toolTip1.SetToolTip(newButton, "Fechar");
                newButton.Font = fntWeb;
                newButton.Text = "r";
            }
            else if (button == WindowButtons.Minimize)
            {
                this.toolTip1.SetToolTip(newButton, "Minimizar");
                newButton.Font = fntWeb;
                newButton.Text = "0";
            }
            else if (button == WindowButtons.Maximize)
            {
                if (WindowState == FormWindowState.Normal)
                {
                    this.toolTip1.SetToolTip(newButton, "Maximizar");
                    newButton.Font = fntWeb;
                    newButton.Text = "1";
                }
                else
                {
                    this.toolTip1.SetToolTip(newButton, "Rest. Tamanho");
                    newButton.Font = fntWeb;
                    newButton.Text = "2";
                }
            }

            newButton.Tag = button;

            newButton.Size = new Size(30, 28);
            newButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            newButton.TabStop = false;
            newButton.Click += WindowButton_Click;
            Controls.Add(newButton);

            windowButtonList.Add(button, newButton);
        }

        private void WindowButton_Click(object sender, EventArgs e)
        {
            var btn = sender as LmFormButton;
            if (btn != null)
            {
                var btnFlag = (WindowButtons)btn.Tag;
                if (btnFlag == WindowButtons.Close)
                {
                    Close();
                }
                else if (btnFlag == WindowButtons.Minimize)
                {
                    WindowState = FormWindowState.Minimized;
                }
                else if (btnFlag == WindowButtons.Maximize)
                {
                    if (WindowState == FormWindowState.Normal)
                    {
                        //formSize = this.Size;
                        WindowState = FormWindowState.Maximized;
                        this.toolTip1.SetToolTip(btn, "Rest. Tamanho");
                        btn.Text = "2";
                    }
                    else
                    {
                        WindowState = FormWindowState.Normal;
                        //this.Size = formSize;
                        this.toolTip1.SetToolTip(btn, "Maximizar");
                        btn.Text = "1";

                        if (this.Top < 0)
                            this.Top = 0;
                    }
                }
                //else if (btnFlag == WindowButtons.Help)
                //{
                //    ClickHelp?.Invoke(btn, e);
                //}
            }
        }

        private void UpdateWindowButtonPosition()
        {
            if (!ControlBox) return;

            System.Threading.Thread.Sleep(100);
            Dictionary<int, WindowButtons> priorityOrder = new Dictionary<int, WindowButtons>(3) {
                { 0, WindowButtons.Close }, { 1, WindowButtons.Maximize }, { 2, WindowButtons.Minimize }/*,
                { 3, WindowButtons.Help }*/};

            Point firstButtonLocation = new Point(ClientRectangle.Width - 32, 2);
            int lastDrawedButtonPosition = firstButtonLocation.X - 30;

            LmFormButton firstButton = null;

            if (windowButtonList.Count == 1)
            {
                foreach (KeyValuePair<WindowButtons, LmFormButton> button in windowButtonList)
                {
                    button.Value.Location = firstButtonLocation;
                }
            }
            else
            {
                foreach (KeyValuePair<int, WindowButtons> button in priorityOrder)
                {
                    bool buttonExists = windowButtonList.ContainsKey(button.Value);

                    if (firstButton == null && buttonExists)
                    {
                        firstButton = windowButtonList[button.Value];
                        firstButton.Location = firstButtonLocation;
                        continue;
                    }

                    if (firstButton == null || !buttonExists) continue;

                    windowButtonList[button.Value].Location = new Point(lastDrawedButtonPosition, 2);
                    lastDrawedButtonPosition = lastDrawedButtonPosition - 30;
                }
            }

            Refresh();
        }

        private class LmFormButton : Button
        {
            #region Fields

            private bool isHovered = false;
            private bool isPressed = false;
            private bool isCloseBtn = false;

            #endregion

            #region Constructor

            public LmFormButton(bool isCloseButton)
            {
                SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.ResizeRedraw |
                         ControlStyles.UserPaint, true);

                isCloseBtn = isCloseButton;
            }

            #endregion

            #region Paint Methods

            protected override void OnPaint(PaintEventArgs e)
            {
                Color backColor, foreColor;

                if (Parent != null)
                {
                    var corHead = LmCor.Bc_Header;// LmPaint.BackColor.FormHeader(_Tema);
                    var corForm = LmCor.Bc_Form;  // LmPaint.BackColor.Form(_Tema);

                    foreColor = corHead.GetForeColor(LmControlStatus.Normal);

                    backColor = corHead;

                    if (isHovered && !isPressed && Enabled)
                    {
                        if (!isCloseBtn)
                        {
                            foreColor = corForm.GetForeColor(LmControlStatus.Selected);

                            backColor = LmCor.Bc_Form;
                        }
                        else
                        {
                            foreColor = LmCor.Bc_Form;
                            backColor = Color.FromArgb(232, 17, 35);
                        }
                    }
                    else if (isHovered && isPressed && Enabled)
                    {
                        foreColor = corHead.GetForeColor(LmControlStatus.Selected);

                        backColor = LmCor.Bc_Dgv_CellNormal;// LmPaint.BackColor.GridView.CellNormal(_Tema);
                    }
                    else if (!Enabled)
                    {
                        foreColor = corHead.GetForeColor(LmControlStatus.Disabled);

                        backColor = LmCor.Bc_Btn_Disabled;// LmPaint.BackColor.Button.Disabled(_Tema);
                    }

                    e.Graphics.Clear(backColor);
                    TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, foreColor, backColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                }
            }

            #endregion

            #region Mouse Methods

            protected override void OnMouseEnter(EventArgs e)
            {
                isHovered = true;
                Invalidate();
                //Top -= 3;
                base.OnMouseEnter(e);
            }

            protected override void OnMouseDown(MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    isPressed = true;
                    Invalidate();
                }

                base.OnMouseDown(e);
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
                isPressed = false;
                Invalidate();

                base.OnMouseUp(e);
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                isHovered = false;
                Invalidate();
                //Top += 3;

                base.OnMouseLeave(e);
            }

            #endregion
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LmSingleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "LmSingleForm";
            this.ResumeLayout(false);

        }
    }
}
