using LmCorbieUI.Design;
using LmCorbieUI.LmForms;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LmCorbieUI
{
    public partial class LmMsgBoxCustom : LmSingleForm
    {
        Color clrDeft = Color.FromArgb(241, 241, 241);
        Color clrInfo = Color.FromArgb(221, 242, 249);
        Color clrQues = Color.FromArgb(209, 236, 242);
        Color clrWarn = Color.FromArgb(255, 243, 205);
        Color clrErro = Color.FromArgb(248, 215, 218);

        Color clrDeftBC = Color.FromArgb(143, 143, 143);
        Color clrInfoBC = Color.FromArgb(29, 166, 211);
        Color clrQuesBC = Color.FromArgb(60, 176, 118);
        Color clrWarnBC = Color.FromArgb(217, 171, 13);
        Color clrErroBC = Color.FromArgb(230, 66, 79);

        Color clrDeftFC = Color.FromArgb(82, 87, 90);
        Color clrInfoFC = Color.FromArgb(63, 115, 171);
        Color clrQuesFC = Color.FromArgb(73, 128, 86);
        Color clrWarnFC = Color.FromArgb(144, 114, 38);
        Color clrErroFC = Color.FromArgb(139, 62, 69);

        Color clrDeftBorder = Color.FromArgb(82, 87, 90);

        string textoMensagem = "", textoTitulo = "";
        MessageBoxIcon _icon = MessageBoxIcon.None;

        string _textoBotao1 = string.Empty;
        string _textoBotao2 = string.Empty;
        string _textoBotao3 = string.Empty;
        Image _iconButton1 = null;
        Image _iconButton2 = null;
        Image _iconButton3 = null;

        public LmMsgBoxCustom(string Texto, string Titulo, MessageBoxIcon msgBoxIcon,
            string textoBotao1, string textoBotao2, string textoBotao3,
            Image iconButton1, Image iconButton2, Image iconButton3)
        {
            InitializeComponent();

            Text = Titulo;// Texto;

            _textoBotao1 = $" {textoBotao1}";
            _textoBotao2 = $" {textoBotao2}";
            _textoBotao3 = $" {textoBotao3}";
            _iconButton1 = iconButton1;
            _iconButton2 = iconButton2;
            _iconButton3 = iconButton3;

            textoMensagem = Texto;
            textoTitulo = Titulo;
            _icon = msgBoxIcon;
            AtribuirValores();
        }

        private void AtribuirValores()
        {
            try
            {
                lblTitulo.Text = textoTitulo;

                lblTexto.Text = textoMensagem.Replace("\t", "        ");

                switch (_icon)
                {
                    case MessageBoxIcon.Information:
                        {
                            clrDeftBorder = clrInfoBC;
                            ptbIcone.Image = Properties.Resources.information.ApplyColor(clrDeftBorder);
                            pnlPrincipal.BackColor = lblTexto.BackColor = clrInfo;
                            lblTexto.ForeColor = lblTitulo.ForeColor = clrInfoFC;

                            btnOpcao1.Style = btnOpcao2.Style = btnOpcao3.Style = ButtonStyle.Information;

                            break;
                        }
                    case MessageBoxIcon.Warning:
                        {
                            clrDeftBorder = clrWarnBC;
                            ptbIcone.Image = Properties.Resources.warning.ApplyColor(clrDeftBorder);
                            pnlPrincipal.BackColor = lblTexto.BackColor = clrWarn;
                            lblTexto.ForeColor = lblTitulo.ForeColor = clrWarnFC;

                            btnOpcao1.Style = btnOpcao2.Style = btnOpcao3.Style = ButtonStyle.Warning;

                            break;
                        }
                    case MessageBoxIcon.Question:
                        {
                            clrDeftBorder = clrQuesBC;
                            ptbIcone.Image = Properties.Resources.question.ApplyColor(clrDeftBorder);
                            pnlPrincipal.BackColor = lblTexto.BackColor = clrQues;
                            lblTexto.ForeColor = lblTitulo.ForeColor = clrQuesFC;

                            btnOpcao1.Style = btnOpcao2.Style = btnOpcao3.Style = ButtonStyle.Question;

                            break;
                        }
                    case MessageBoxIcon.Error:
                        {
                            clrDeftBorder = clrErroBC;
                            ptbIcone.Image = Properties.Resources.error.ApplyColor(clrDeftBorder);
                            pnlPrincipal.BackColor = lblTexto.BackColor = clrErro;
                            lblTexto.ForeColor = lblTitulo.ForeColor = clrErroFC;

                            btnOpcao1.Style = btnOpcao2.Style = btnOpcao3.Style = ButtonStyle.Error;

                            break;
                        }
                    case MessageBoxIcon.None:
                        {
                            clrDeftBorder = clrDeftBC;
                            pnlPrincipal.BackColor = lblTexto.BackColor = clrDeft;
                            lblTexto.ForeColor = lblTitulo.ForeColor = clrDeftFC;
                            pnlPrincipal.Controls.RemoveByKey(ptbIcone.Name);

                            btnOpcao1.Style = btnOpcao2.Style = btnOpcao3.Style = ButtonStyle.Gray;

                            break;
                        }
                    default:
                        {
                            clrDeftBorder = clrDeftBC;
                            pnlPrincipal.BackColor = lblTexto.BackColor = clrDeft;
                            lblTexto.ForeColor = lblTitulo.ForeColor = clrDeftFC;
                            pnlPrincipal.Controls.RemoveByKey(ptbIcone.Name);

                            btnOpcao1.Style = btnOpcao2.Style = btnOpcao3.Style = ButtonStyle.Gray;

                            break;
                        }
                }

                btnOpcao1.AplicarStilo();
                btnOpcao2.AplicarStilo();
                btnOpcao3.AplicarStilo();

                flpBotoes.BackColor = Color.FromArgb(
                    pnlPrincipal.BackColor.R - 5, pnlPrincipal.BackColor.G - 5, pnlPrincipal.BackColor.B - 5);

                var sep = pnlPrincipal.Controls.ContainsKey(ptbIcone.Name)
                    ? Environment.NewLine + string.Empty.PadRight(67, '_') + Environment.NewLine
                    : Environment.NewLine + string.Empty.PadRight(77, '_') + Environment.NewLine;

                lblTexto.Text = lblTexto.Text
                    .Replace("<sep>", "<SEP>")
                    .Replace("<sEp>", "<SEP>")
                    .Replace("<seP>", "<SEP>")
                    .Replace("<sEP>", "<SEP>")
                    .Replace("<Sep>", "<SEP>")
                    .Replace("<SEp>", "<SEP>")
                    .Replace("<SeP>", "<SEP>")
                    .Replace("<SEP>", sep);

                FormatarBotoes();
                PosicionarRedimencionarForm();

                lblTexto.Select();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void FormatarBotoes()
        {
            if (string.IsNullOrEmpty(_textoBotao2))
                btnOpcao2.Visible = false;
            if (string.IsNullOrEmpty(_textoBotao3))
                btnOpcao3.Visible = false;

            var tamanhoTexto = _textoBotao1.Length;

            if (tamanhoTexto < _textoBotao2.Length)
                tamanhoTexto = _textoBotao2.Length;
            if (tamanhoTexto < _textoBotao3.Length)
                tamanhoTexto = _textoBotao3.Length;

            if (tamanhoTexto > 20)
                btnOpcao1.Width = btnOpcao2.Width = btnOpcao3.Width = 190;
            else if (tamanhoTexto > 15)
                btnOpcao1.Width = btnOpcao2.Width = btnOpcao3.Width = 160;
            else if (tamanhoTexto > 10)
                btnOpcao1.Width = btnOpcao2.Width = btnOpcao3.Width = 130;
            else
                btnOpcao1.Width = btnOpcao2.Width = btnOpcao3.Width = 100;

            btnOpcao1.Text = " " + _textoBotao1;
            btnOpcao2.Text = " " + _textoBotao2;
            btnOpcao3.Text = " " + _textoBotao3;

            if (_iconButton1 != null)
                btnOpcao1.Image = _iconButton1;
            else
                btnOpcao1.ImageAlign = ContentAlignment.MiddleCenter;

            if (_iconButton2 != null)
                btnOpcao2.Image = _iconButton2;
            else
                btnOpcao2.ImageAlign = ContentAlignment.MiddleCenter;

            if (_iconButton3 != null)
                btnOpcao3.Image = _iconButton3;
            else
                btnOpcao3.ImageAlign = ContentAlignment.MiddleCenter;
        }

        private void PosicionarRedimencionarForm()
        {
            try
            {
                lblTexto.MaximumSize = new Size(lblTitulo.Width, 2000);
                lblTexto.MinimumSize = new Size(lblTitulo.Width, 10);

                Height = lblTitulo.Height + flpBotoes.Height + lblTexto.Height + 2;

                if (Height > 700)
                {
                    System.Diagnostics.Debug.Print($"Scroll Ativado, tamanho calculado: {Height} - alterado para: 700");

                    Height = 700;
                }

            }
            catch (Exception)
            {
            }
        }

        private void LmMsgBoxCustom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.None;
                Close();
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                Clipboard.SetText(lblTexto.Text);
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, (int)Native.WinApi.Messages.WM_NCLBUTTONDOWN, (int)Native.WinApi.Messages.WM_DESTROY, 0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            this.BackColor =  clrDeftBorder;
            ptbIcone.Image= ptbIcone.Image.ApplyColor(clrDeftBorder);

            using (Pen p = new Pen(clrDeftBorder))
            {
                p.Width = 1;
                e.Graphics.DrawRectangle(p, new Rectangle(0, 0, Width - 1, Height - 1));
            }
        }
    }
}
