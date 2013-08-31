using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//meus
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
//PDF
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;


namespace WindowsFormsApplication1
{
    class ManipulaDados
    {
        public string Dados()
        {
            // Localiza arquivos XML na pasta 'pastaXML'
            //string pastaXML = @"C:\Users\MarceloP\Documents\Visual Studio 2012\Projects\XML_files";
            string pastaXML = "..\\..\\..\\..\\XML_files";
            DirectoryInfo DirInfo = new DirectoryInfo(pastaXML);
            FileInfo[] ListaArquivos = DirInfo.GetFiles("*.xml");

            XDocument[] xmldoc = CarregaChecaXML.XMLdocs(ListaArquivos);
            List<TabelaElementos.Header> headers = ColetaDados.ListaHeaders(xmldoc);
            List<TabelaElementos.TitPublico> titPublicos = ColetaDados.TitulosPublicos(xmldoc);
            List<TabelaElementos.CreditoPrivado> credPrivado = ColetaDados.CreditoPrivado(xmldoc);
            List<TabelaElementos.Acoes> acoes = ColetaDados.Acoes(xmldoc);
            List<TabelaElementos.Cotas> cotas = ColetaDados.ListaCotas(xmldoc);

            RelatorioPDF.LayoutPDF.GerarRelatorio();

            #region Variaveis
            //Variaveis Gerais
            int i = 0;
            string Retorno = "false";
            string stErro = null;
            string[] carteira;



            #endregion

            try
            {

                #region Levantamento dos dados XML

                //Abre arquivo
                foreach (FileInfo ArquivosXML in VGlobal.ListaArquivos)
                {
                    #region Header
                    carteira = ManipulaDados_Header.cnpjcpf(ArquivosXML);
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

