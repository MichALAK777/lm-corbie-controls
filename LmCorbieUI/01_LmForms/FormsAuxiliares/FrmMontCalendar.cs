using LmCorbieUI.Native;
using System;
using System.Windows.Forms;

namespace LmCorbieUI
{
    public partial class FrmMontCalendar : Form
    {
        MouseHook mh;

        public DateTime date = DateTime.Now;

        public FrmMontCalendar(DateTime data)
        {
            InitializeComponent();

            monthCalendar1.SetDate(data);
            date = data;
        }

        private void FrmMontCalendar_Load(object sender, EventArgs e)
        {
            mh = new MouseHook();
            mh.SetHook();
            mh.MouseClickEvent += Mh_MouseClickEvent;
        }

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            date = monthCalendar1.SelectionStart;
            mh.UnHook();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FrmMontCalendar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                mh.UnHook();
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void Mh_MouseClickEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Rectangle clirec = this.RectangleToClient(ClientRectangle);
                if (e.X < Left || e.X > Left + Width || e.Y < Top || e.Y > Top + Height)
                {
                    mh.UnHook();
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
        }

        private void FrmMontCalendar_FormClosed(object sender, FormClosedEventArgs e)
        {
            mh.UnHook();
        }
    }
}
