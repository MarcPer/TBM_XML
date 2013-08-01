using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace XMLBackOffice
{
    class AbreArquivo
    {
        public string[] Emissor(string EnderecoEmissor)
        {

            #region Variaveis Locais
            //Variaveis
            string[] LinhasEmissor= null;
            #endregion

            #region Carrega Arquivo
            //Carrega Arquivo
            if (File.Exists(EnderecoEmissor))
            {
                try
                {
                    LinhasEmissor = File.ReadAllLines(VGlobal.EndEmissor);
                }
                catch (Exception Error)
                {
                    ProcessoEmissor.LogLocal.Text += Convert.ToString(Error);
                    DialogResult dialogResult = MessageBox.Show("Encontrado erro na estrutura do EMISSOR.txt. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                }
                finally
                {
                    //Retorno = "false";
                    ProcessoEmissor.LogLocal.Text += "Abre arquivo Emissor.txt: OK\r\n";
                    ProcessoEmissor.LogLocal.Text += "Quantidade de linhas detectadas: " + LinhasEmissor.Length + "\r\n";
                    //ProcessoEmissor.LogLocal.Text += Retorno;
                }

            }
            else
            {
                ProcessoEmissor.LogLocal.Text += "Arquivo EMISSOR.txt nao existe!";
                VGlobal.RetornoFalha = true;
            }
            return LinhasEmissor;
            #endregion

        }

        public string[] Ativo(string EnderecoAtivo)
        {

            #region Variaveis Locais
            //Variaveis
            string[] LinhasAtivo = null;
            #endregion

            #region Carrega Arquivo
            //Carrega Arquivo
            if (File.Exists(EnderecoAtivo))
            {
                try
                {
                    LinhasAtivo = File.ReadAllLines(VGlobal.EndEmissor);
                }
                catch (Exception Error)
                {
                    ProcessoEmissor.LogLocal.Text += Convert.ToString(Error);
                    DialogResult dialogResult = MessageBox.Show("Encontrado erro na estrutura do EMISSOR.txt. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                }
                finally
                {
                    //Retorno = "false";
                    ProcessoEmissor.LogLocal.Text += "Abre arquivo Emissor.txt: OK\r\n";
                    ProcessoEmissor.LogLocal.Text += "Quantidade de linhas detectadas: " + LinhasAtivo.Length + "\r\n";
                    //ProcessoEmissor.LogLocal.Text += Retorno;
                }

            }
            else
            {
                ProcessoEmissor.LogLocal.Text += "Arquivo EMISSOR.txt nao existe!";
                VGlobal.RetornoFalha = true;
            }
            return LinhasAtivo;
            #endregion

        }

    }
}
