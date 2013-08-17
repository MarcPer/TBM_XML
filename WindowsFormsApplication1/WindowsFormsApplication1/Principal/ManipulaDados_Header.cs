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
    /// <summary>
    /// Retira informações do Header
    /// </summary>
    /// <remarks>
    /// Função tem como entrada um arquivo XML e métodos definidos para extrair informações dos nós 'Header'.
    /// </remarks>
    public static class ManipulaDados_Header
    {
        

        //static string Sub_Header(FileInfo ArquivosXML, int i)
        //{

        //    #region Variaveis
        //    //Variaveis Gerais
        //    string Retorno = "false";
        //    string stErro = null;

        //    //Variáveis do Header
        //    int iHeaderCarteira = 0;
        //    int iHeaderFundo = 0;
        //    int iHeaderInformacoes = 0;
        //    decimal TesteSoma = 0;
        //    VGlobal.stInformacoesGerais[] rlInformacoesGerais = new VGlobal.stInformacoesGerais[VGlobal.TamTotHeader];
        //    VGlobal.stHeaderCarteira401[] HeaderCarteira401 = new VGlobal.stHeaderCarteira401[VGlobal.TamHeader[i]];
        //    VGlobal.stHeaderFundo401[] HeaderFundo401 = new VGlobal.stHeaderFundo401[VGlobal.TamHeader[i]];

        //    #endregion

        //    try
        //    {
        //        XmlDocument xmldoc = new XmlDocument();
        //        xmldoc.Load(ArquivosXML.FullName);

        //        #region Header
                
        //        #region HeaderCarteira
        //        if (VGlobal.TamCarteira[i] == 1 && VGlobal.TamFundo[i] == 0)
        //        {

        //            VGlobal.xmlnode = xmldoc.SelectNodes("/arquivoposicao_4_01/carteira/header");
                    
        //            foreach (XmlNode xn in VGlobal.xmlnode)
        //            {
        //                HeaderCarteira401[iHeaderCarteira] = new VGlobal.stHeaderCarteira401();
        //                HeaderCarteira401[iHeaderCarteira].cnpjcpf = xn["cnpjcpf"].InnerText;
        //                HeaderCarteira401[iHeaderCarteira].codcart = xn["codcart"].InnerText;
        //                HeaderCarteira401[iHeaderCarteira].dtposicao = xn["dtposicao"].InnerText;
        //                HeaderCarteira401[iHeaderCarteira].nome = xn["nome"].InnerText;
        //                HeaderCarteira401[iHeaderCarteira].tpcli = xn["tpcli"].InnerText;
        //                HeaderCarteira401[iHeaderCarteira].codcntcor = xn["codcntcor"].InnerText;
        //                HeaderCarteira401[iHeaderCarteira].nomegestor = xn["nomegestor"].InnerText;
        //                HeaderCarteira401[iHeaderCarteira].cnpjgestor = xn["cnpjgestor"].InnerText;
        //                HeaderCarteira401[iHeaderCarteira].nomecustodiante = xn["nomecustodiante"].InnerText;
        //                HeaderCarteira401[iHeaderCarteira].cnpjcustodiante = xn["cnpjcustodiante"].InnerText;
        //                HeaderCarteira401[iHeaderCarteira].patliq = xn["patliq"].InnerText;
        //                HeaderCarteira401[iHeaderCarteira].tributos = xn["tributos"].InnerText;
        //                HeaderCarteira401[iHeaderCarteira].valorativos = xn["valorativos"].InnerText;
        //                HeaderCarteira401[iHeaderCarteira].valorreceber = xn["valorreceber"].InnerText;
        //                HeaderCarteira401[iHeaderCarteira].valorpagar = xn["valorpagar"].InnerText;
        //                //inserido
        //                rlInformacoesGerais[iHeaderInformacoes] = new VGlobal.stInformacoesGerais();
        //                rlInformacoesGerais[iHeaderInformacoes].DataPosicao = HeaderCarteira401[iHeaderCarteira].dtposicao;
        //                VGlobal.rtLOG.Text += "DataPosicao: " + rlInformacoesGerais[iHeaderInformacoes].DataPosicao + "\r\n";
        //                rlInformacoesGerais[iHeaderInformacoes].Item = Convert.ToString(iHeaderInformacoes + 1);
        //                VGlobal.rtLOG.Text += "Item: " + rlInformacoesGerais[iHeaderInformacoes].Item + "\r\n";
        //                rlInformacoesGerais[iHeaderInformacoes].Nome = HeaderCarteira401[iHeaderCarteira].nome;
        //                VGlobal.rtLOG.Text += "Nome: " + rlInformacoesGerais[iHeaderInformacoes].Nome + "\r\n";
        //                rlInformacoesGerais[iHeaderInformacoes].PatrimonioLiquido = HeaderCarteira401[iHeaderCarteira].patliq;
        //                VGlobal.rtLOG.Text += "PatrimonioLiquido: " + rlInformacoesGerais[iHeaderInformacoes].PatrimonioLiquido + "\r\n";
        //                TesteSoma += Convert.ToDecimal(HeaderCarteira401[iHeaderCarteira].patliq);
        //                VGlobal.rtLOG.Text += "PatrimonioLiquidoTotal: " + TesteSoma + "\r\n";
        //                //fim inserido
        //                iHeaderCarteira++;
        //                iHeaderInformacoes++;
        //            }
        //        }
        //        #endregion

        //        #region HeaderFundo
        //        else if (VGlobal.TamCarteira[i] == 0 && VGlobal.TamFundo[i] == 1)
        //        {
        //            VGlobal.xmlnode = xmldoc.SelectNodes("/arquivoposicao_4_01/fundo/header");
                    

        //            foreach (XmlNode xn in VGlobal.xmlnode)
        //            {
        //                HeaderFundo401[iHeaderFundo] = new VGlobal.stHeaderFundo401();
        //                HeaderFundo401[iHeaderFundo].isin = xn["isin"].InnerText;
        //                HeaderFundo401[iHeaderFundo].cnpj = xn["cnpj"].InnerText;
        //                HeaderFundo401[iHeaderFundo].nome = xn["nome"].InnerText;
        //                HeaderFundo401[iHeaderFundo].dtposicao = xn["dtposicao"].InnerText;
        //                HeaderFundo401[iHeaderFundo].nomeadm = xn["nomeadm"].InnerText;
        //                HeaderFundo401[iHeaderFundo].cnpjadm = xn["cnpjadm"].InnerText;
        //                HeaderFundo401[iHeaderFundo].nomegestor = xn["nomegestor"].InnerText;
        //                HeaderFundo401[iHeaderFundo].cnpjgestor = xn["cnpjgestor"].InnerText;
        //                HeaderFundo401[iHeaderFundo].nomecustodiante = xn["nomecustodiante"].InnerText;
        //                HeaderFundo401[iHeaderFundo].cnpjcustodiante = xn["cnpjcustodiante"].InnerText;
        //                HeaderFundo401[iHeaderFundo].valorcota = xn["valorcota"].InnerText;
        //                HeaderFundo401[iHeaderFundo].quantidade = xn["quantidade"].InnerText;
        //                HeaderFundo401[iHeaderFundo].patliq = xn["patliq"].InnerText;
        //                HeaderFundo401[iHeaderFundo].valorativos = xn["valorativos"].InnerText;
        //                HeaderFundo401[iHeaderFundo].valorreceber = xn["valorreceber"].InnerText;
        //                HeaderFundo401[iHeaderFundo].valorpagar = xn["valorpagar"].InnerText;
        //                HeaderFundo401[iHeaderFundo].vlcotasemitir = xn["vlcotasemitir"].InnerText;
        //                HeaderFundo401[iHeaderFundo].vlcotasresgatar = xn["vlcotasresgatar"].InnerText;
        //                HeaderFundo401[iHeaderFundo].codanbid = xn["codanbid"].InnerText;//erro
        //                HeaderFundo401[iHeaderFundo].tipofundo = xn["tipofundo"].InnerText;
        //                HeaderFundo401[iHeaderFundo].nivelrsc = xn["nivelrsc"].InnerText;
        //                //inserido
        //                rlInformacoesGerais[iHeaderInformacoes] = new VGlobal.stInformacoesGerais();
        //                rlInformacoesGerais[iHeaderInformacoes].DataPosicao = HeaderFundo401[iHeaderFundo].dtposicao;
        //                VGlobal.rtLOG.Text += "DataPosicao: " + rlInformacoesGerais[iHeaderInformacoes].DataPosicao + "\r\n";
        //                rlInformacoesGerais[iHeaderInformacoes].Item = Convert.ToString(iHeaderInformacoes + 1);
        //                VGlobal.rtLOG.Text += "Item: " + rlInformacoesGerais[iHeaderInformacoes].Item + "\r\n";
        //                rlInformacoesGerais[iHeaderInformacoes].Nome = HeaderFundo401[iHeaderFundo].nome;
        //                VGlobal.rtLOG.Text += "Nome: " + rlInformacoesGerais[iHeaderInformacoes].Nome + "\r\n";
        //                rlInformacoesGerais[iHeaderInformacoes].PatrimonioLiquido = HeaderFundo401[iHeaderFundo].patliq;
        //                VGlobal.rtLOG.Text += "PatrimonioLiquido: " + rlInformacoesGerais[iHeaderInformacoes].PatrimonioLiquido + "\r\n";
        //                TesteSoma += Convert.ToDecimal(HeaderFundo401[iHeaderFundo].patliq);
        //                VGlobal.rtLOG.Text += "PatrimonioLiquidoTotal: " + TesteSoma + "\r\n";
        //                //fim inserido
        //                iHeaderFundo++;
        //                iHeaderInformacoes++;
        //            }
        //        }
        //        #endregion

        //        #region Header não encontrado!
        //        else
        //        {
        //            VGlobal.rtLOG.Text += ArquivosXML.Name + ": \r\nHeader não encontrado! \r\n";
        //            MessageBox.Show(ArquivosXML.Name + ": \r\nHeader não encontrado!\r\n");
        //            Retorno = "true";
        //            goto SaiFuncao;
        //        }
        //        #endregion

        //        //Necessário para o loop
        //        //iHeaderCarteira = 0; //reseta indice de cada arquivo
        //        //iHeaderFundo = 0; //reseta indice de cada arquivo
        //        #endregion

        //    }
        //    catch (Exception MsgErro)
        //    {
        //        stErro = Convert.ToString(MsgErro);
        //        Retorno = "true";
        //        VGlobal.rtLOG.Text += stErro;
        //        goto SaiFuncao;
        //    }
            
        //    SaiFuncao:
        //    #region Retorno
        //    VGlobal.rtLOG.Text += "===========================================================================\r\n";//Separação de arquivos XML no LOG.
        //    VGlobal.rtLOG.Text += "Fim do levantamento Header do XML. Funcao retornou: " + Retorno + "\r\n";
        //    VGlobal.rtLOG.Text += "===========================================================================\r\n";//Separação de arquivos XML no LOG.
        //    return Retorno;
        //    #endregion

        //}

        /// <summary>
        /// Retorna conteúdo do nó 'cnpjcpf' do arquivo 'ArquivoXML'.
        /// </summary>
        /// <param name="ArquivosXML"></param>
        /// <param name="iFile"></param>
        /// <returns></returns>
        public static string[] cnpjcpf(FileInfo ArquivosXML)
        {
            string[] strOut = {""};
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(ArquivosXML.FullName);
            XmlNodeList nodes = xmldoc.SelectNodes("//header");
            foreach (XmlNode node in nodes)
            {
                strOut[1] = node["cnpjcpf"].InnerText;
            }
            return strOut;
        }
    }
}
