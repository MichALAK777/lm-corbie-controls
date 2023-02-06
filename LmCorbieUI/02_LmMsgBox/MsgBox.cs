using LmCorbieUI.Design;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LmCorbieUI
{
    public class MsgBox
    {
        public enum RetornoMsgBox
        {
            [System.ComponentModel.Description("Selecionado Opção 1")]
            Opcao1 = 1,
            [System.ComponentModel.Description("Selecionado Opção 2")]
            Opcao2 = 2,
            [System.ComponentModel.Description("Selecionado Opção 3")]
            Opcao3 = 3,
            SemRetorno = 99
        }

        /// <summary>
        /// Mostrar Caixa de Mensagem Personalizada
        /// </summary>
        /// <param name="texto">Texto para Exibição</param>
        /// <param name="titulo">Título da mensagem</param>
        /// <param name="msgBoxButtons">Escolha Botões</param>
        /// <param name="msgBoxIcon">Escolha Icone</param>
        /// <returns></returns>
        [STAThreadAttribute]
        public static DialogResult Show(string texto, string titulo = "",
            MessageBoxButtons msgBoxButtons = MessageBoxButtons.OK,
            MessageBoxIcon msgBoxIcon = MessageBoxIcon.None,
            ContentAlignment alinhamentoTitulo = ContentAlignment.MiddleCenter, ContentAlignment alinhamentoCorpo = ContentAlignment.MiddleLeft,
            string textoBotao1 = "", string textoBotao2 = "", string textoBotao3 = "")
        {
            try
            {
                CloseWaitMessage();

                DialogResult result = DialogResult.None;

                LmMsgBox frm = new LmMsgBox(texto, titulo, msgBoxButtons, msgBoxIcon, alinhamentoTitulo, alinhamentoCorpo,
                    textoBotao1, textoBotao2, textoBotao3);
                result = frm.ShowDialog();

                return result;
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Erro não visivel pelo Usuario", true);
                return DialogResult.Abort;
            }
        }

        public static RetornoMsgBox Show(string texto, string titulo, MessageBoxIcon msgBoxIcon,
            string textoBotao1, string textoBotao2 = "", string textoBotao3 = "",
            Image iconButton1 = null,
            Image iconButton2 = null,
            Image iconButton3 = null)
        {
            try
            {
                CloseWaitMessage();

                LmMsgBoxCustom frm = new LmMsgBoxCustom(texto, titulo, msgBoxIcon,
                    textoBotao1, textoBotao2, textoBotao3,
                    iconButton1, iconButton2, iconButton3);
                frm.ShowDialog();

                return
                    frm.DialogResult == DialogResult.OK ? RetornoMsgBox.Opcao1
                    : frm.DialogResult == DialogResult.No ? RetornoMsgBox.Opcao2
                    : frm.DialogResult == DialogResult.Cancel ? RetornoMsgBox.Opcao3
                    : RetornoMsgBox.SemRetorno;
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Erro não visivel pelo Usuario", true);
                return RetornoMsgBox.SemRetorno;
            }
        }

        [STAThreadAttribute]
        public static void ShowToolTip(Control control, string texto, string titulo = "", int tempoExibicao = 0)
        {
            try
            {
                CloseWaitMessage();

                if (control != null && control.Parent != null)
                {
                    Control _owner = control.Parent;

                    LmMsgToolTip _msgToolTip = new LmMsgToolTip(texto, titulo, tempoExibicao);

                    _msgToolTip.Size = new Size(1, 1);

                    _msgToolTip.TopLevel = false;

                    _owner.Controls.Add(_msgToolTip);

                    _msgToolTip.Show();

                    _msgToolTip.Location = new Point(_owner.Controls[control.Name].Left, _owner.Controls[control.Name].Top + control.Height + 1);

                    if (_msgToolTip.Left + _msgToolTip.Width > _owner.Width)
                        _msgToolTip.Left = _owner.Width - _msgToolTip.Width - 1;

                    if (_msgToolTip.Top + _msgToolTip.Height > _owner.Height)
                        _msgToolTip.Top = _owner.Height - _msgToolTip.Height - 1;

                    if (control.Parent is FlowLayoutPanel)
                        _msgToolTip.SendToBack();
                    else
                        _msgToolTip.BringToFront();
                }
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Erro não visivel pelo Usuario", true);
            }
        }

        [STAThreadAttribute]
        public static void ShowToolTipPerson(Control control, string texto)
        {
            try
            {
                if (control != null && control.Parent != null)
                {
                    Control _owner = control.Parent;

                    LmMsgToolTipPerson frm = new LmMsgToolTipPerson(texto);
                    Rectangle areaTrabalho = Screen.GetWorkingArea(_owner);

                    var ptScreen = control.PointToScreen(Point.Empty);
                    ptScreen.Y += control.Height;

                    bool paraBaixo = areaTrabalho.Bottom - ptScreen.Y < ptScreen.Y ? false : true;

                    int ladoMaior = (areaTrabalho.Bottom - ptScreen.Y) < ptScreen.Y ? ptScreen.Y : areaTrabalho.Bottom - ptScreen.Y;
                    int ladoMenor = ladoMaior == ptScreen.Y ? areaTrabalho.Bottom - ptScreen.Y : ptScreen.Y;

                    ladoMaior -= 50;

                    int posX = ptScreen.X;
                    int posY = ptScreen.Y;

                    if (paraBaixo || (!paraBaixo && ladoMenor > frm.Height))
                    {
                        posY -= control.Height;
                    }
                    else if (!paraBaixo)
                    {
                        posY -= frm.Height;
                    }

                    frm.Location = new Point(posX, posY);

                    frm.ShowDialog();

                    if (control.Parent is FlowLayoutPanel)
                        frm.SendToBack();
                    else
                        frm.BringToFront();
                }
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Erro não visivel pelo Usuario", true);
            }
        }

        public static void ShowWaitMessage(string texto = "Aguarde...")
        {
            try
            {
                CloseWaitMessage();

                string pastaTemp = "C:\\Temp\\";
                if (!System.IO.Directory.Exists(pastaTemp))
                    System.IO.Directory.CreateDirectory(pastaTemp);

                string fileName = pastaTemp + "MessageWait.lmmsg";

                File.WriteAllText(fileName, texto, Encoding.GetEncoding("UTF-8"));

                System.Diagnostics.Process.Start(Application.StartupPath + "\\LmCorbieMsgBox.exe");
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Erro não visivel pelo Usuario", true);
            }
        }

        public static void CloseWaitMessage()
        {
            try
            {
                var processes = System.Diagnostics.Process.GetProcessesByName("LmCorbieMsgBox");
                foreach (var p in processes)
                    try
                    {
                        p.Kill();
                    }
                    catch (Exception)
                    {
                    }

                string fileName = "C:\\Temp\\MessageWait.lmcorbie";
                if (System.IO.File.Exists(fileName))
                    System.IO.File.Delete(fileName);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                GC.Collect();
            }
        }

        public static string ImputBox(string message = "", string titulo = "", string textoImputPadrao = "",
            LmValueType lmValueType = LmValueType.Alfanumerico, bool textoLongo = false, bool CentralizarForm = false)
        {
            LmImputBox frm = new LmImputBox(message, titulo, textoImputPadrao, lmValueType, textoLongo, CentralizarForm);
            if (frm.ShowDialog() == DialogResult.OK)
                return frm.txt.Text;
            else
                return string.Empty;
        }
        public static string ImputBox(out DialogResult dialogResult, string message = "", string titulo = "", string textoImputPadrao = "",
             LmValueType lmValueType = LmValueType.Alfanumerico, bool textoLongo = false, bool CentralizarForm = false)
        {
            LmImputBox frm = new LmImputBox(message, titulo, textoImputPadrao, lmValueType, textoLongo, CentralizarForm);

            dialogResult = frm.ShowDialog();

            if (dialogResult == DialogResult.OK)
                return frm.txt.Text;
            else
                return string.Empty;
        }

    }
}
