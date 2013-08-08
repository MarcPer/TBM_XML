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
       
        public string[] AbreTXT(string EnderecoArquivo)
        {

            #region Variaveis Locais
            //Variaveis
            string[] LinhasArquivo = null;
            #endregion

            #region Carrega Arquivo
            //Carrega Arquivo
            if (File.Exists(EnderecoArquivo))
            {
                try
                {
                    LinhasArquivo = File.ReadAllLines(EnderecoArquivo);
                }
                catch (Exception Error)
                {
                    VGlobal.LogLocal.Text += "Abre arquivo Texto: FALHA!\r\n";
                    VGlobal.LogLocal.Text += Convert.ToString(Error);
                    DialogResult dialogResult = MessageBox.Show("Encontrado erro na estrutura do texto. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                }
                finally
                {
                    VGlobal.LogLocal.Text += "Abre arquivo Texto: OK\r\n";
                    VGlobal.LogLocal.Text += "Quantidade de linhas detectadas: " + LinhasArquivo.Length + "\r\n";
                }
            }
            else
            {
                VGlobal.LogLocal.Text += "Arquivo texto nao existe!\r\n";
                VGlobal.RetornoFalha = true;
            }
            return LinhasArquivo;
            #endregion

        }

    }
}
