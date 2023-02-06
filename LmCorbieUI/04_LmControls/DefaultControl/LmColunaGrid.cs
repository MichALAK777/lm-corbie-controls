using LmCorbieUI;
using LmCorbieUI.Design;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LmCorbieUI.Controls
{
    public partial class LmColunaGrid : UserControl
    {
        public delegate void MouseEventArgsCtrl(object sender, MouseEventArgs e);
        public delegate void Click(object sender, EventArgs e);
        public event Click MoverParaOculto;
        public event Click MoverParaVisivel;
        public event MouseEventArgsCtrl MouseDownCtrl;

        public LmColunaGrid(bool colunaVisivel)
        {
            InitializeComponent();

            if (colunaVisivel)
            {
                this.Anchor = AnchorStyles.None;

                this.toolTip1.SetToolTip(this.lnkAddRem, "Mover para Colunas Ocultas");
                lnkAddRem.Dock = DockStyle.Right;
                lnkAddRem.Image = Properties.Resources.avancar;
                lnkAddRem.Click += LnkMoverParaOculto_Click;
            }
            else
            {
                this.Anchor = AnchorStyles.None;

                this.toolTip1.SetToolTip(this.lnkAddRem, "Mover para Colunas Visíveis");
                lnkAddRem.Dock = DockStyle.Left;
                lnkAddRem.Image =Properties.Resources.voltar;
                lnkAddRem.Click += LnkMoverParaVisivel_Click;
            }

            Thread t = new Thread(() => { AplicarTema(); }) { IsBackground = true };
            t.Start();
        }

        private void AplicarTema()
        {
            Color bcColor = LmCor.Bc_Btn_Normal;// LmPaint.BackColor.Button.Normal(Tema);

            lblDescricao.BackColor = bcColor;
            this.Tag = bcColor;
            this.lblDescricao.ForeColor = bcColor.IsDarkColor() ? Color.FromArgb(244, 242, 240) : Color.FromArgb(44, 42, 40);
            if (bcColor.IsDarkColor())
                lnkAddRem.Image = lnkAddRem.Image.ApplyColor(this.lblDescricao.ForeColor);
        }

        private void UcPratosDoDia_Load(object sender, EventArgs e)
        {
        }

        private void LnkExcluir_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void LnkMoverParaOculto_Click(object sender, EventArgs e)
        {
            MoverParaOculto?.Invoke(this, new EventArgs());
        }

        private void LnkMoverParaVisivel_Click(object sender, EventArgs e)
        {
            MoverParaVisivel?.Invoke(this, new EventArgs());
        }

        private void LblDescricao_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownCtrl?.Invoke(this, e);
        }

        private void UcColunaGrid_MouseEnter(object sender, EventArgs e)
        {
            lblDescricao.Font = new Font(lblDescricao.Font, FontStyle.Bold);

            Color bcColor = lblDescricao.BackColor;

            if (bcColor.IsDarkColor())
                lblDescricao.BackColor.Escurecer();
            else
                lblDescricao.BackColor.Clarear();
        }

        private void UcColunaGrid_MouseLeave(object sender, EventArgs e)
        {
            lblDescricao.Font = new Font(lblDescricao.Font, FontStyle.Regular);

            lblDescricao.BackColor = (Color)this.Tag;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

    }
}
