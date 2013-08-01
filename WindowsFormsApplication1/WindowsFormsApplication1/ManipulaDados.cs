using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//meus
using System.Xml;
using System.IO;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    class ManipulaDados
    {
        public string Dados()
        {

            #region Variaveis
            //Variaveis Gerais
            int i = 0;
            string Retorno = "false";
            string stErro = null;




            #endregion

            try
            {

                #region Levantamento dos dados XML

                //Abre arquivo
                foreach (FileInfo ArquivosXML in VGlobal.ListaArquivos)
                {
                    #region Header
                    SubManipulaDados_Header ManipHeader = new SubManipulaDados_Header();
                    if (ManipHeader.Sub_Header(ArquivosXML,i) != "false")
                    {
                        DialogResult dialogResult = MessageBox.Show("Encontrado erro na manipulação do Header do XML. Favor verificar LOG!", "ERROR", MessageBoxButtons.OK);
                        goto SaiFuncao;
                    }
                    #endregion


                    i++; //passa para proximo arquivo
                }
                #endregion

                #region Processamento dos dados XML


                #endregion

            }
            catch (Exception MsgErro)
            {
                stErro = Convert.ToString(MsgErro);
                Retorno = "true";
                VGlobal.rtLOG.Text += stErro;
                goto SaiFuncao;
            }

        SaiFuncao:

            #region Retorno
            VGlobal.rtLOG.Text += "===========================================================================\r\n";//Separação de arquivos XML no LOG.
            VGlobal.rtLOG.Text += "Fim do levantamento do XML. Funcao ManipulaDaods.Dados retornou: " + Retorno + "\r\n";
            VGlobal.rtLOG.Text += "===========================================================================\r\n";//Separação de arquivos XML no LOG.
            return Retorno;
            #endregion



        }
    }
}

