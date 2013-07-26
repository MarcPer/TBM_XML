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
            string carteira;
            int teste_resposta;



            #endregion

            teste_resposta = ManipulaDados_Header.getResposta();

            try
            {

                #region Levantamento dos dados XML

                //Abre arquivo
                foreach (FileInfo ArquivosXML in VGlobal.ListaArquivos)
                {
                    #region Header
                    carteira = ManipulaDados_Header.getCarteira(ArquivosXML, 1);
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
            return "false";
            #endregion



        }
    }
}

