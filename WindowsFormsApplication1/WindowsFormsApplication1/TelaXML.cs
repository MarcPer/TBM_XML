using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//meus
using System.Xml;
using System.IO;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Interface gráfica com o usuário.
    /// </summary>
    public partial class TelaXML : Form
    {
        public TelaXML()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Joga o Caminho da barra de endereços na variável global do Endereço
            VGlobal.CaminhoXML = @"C:\Users\MarceloP\Documents\Visual Studio 2012\Projects\TBM_XML\XML_files";
            //string CaminhoAux = Convert.ToString(CaminhoXML.);
            //CaminhoAux = CaminhoAux.Replace("\\", "//"); //está incompleta a tratativa
            //VGlobal.CaminhoXML = CaminhoAux;
                      
            Programa obPrograma = new Programa();
            obPrograma.GerenciaProcesso();

            rtLOG.Text = VGlobal.rtLOG.Text;

            #region Variaveis
        //    //Variáveis
        //    //string PastaXML = "c://input//";

        //    //Pega Lista de Arquivos da pasta
        //    //string[] ListaArquivos = Directory.GetFiles(PastaXML, "*.xml");
        //    DirectoryInfo DirInfo = new DirectoryInfo(PastaXML);
        //    FileInfo[] ListaArquivos = DirInfo.GetFiles("*.xml");

        //    //Lista tamanho de cada elemento de cada arquivo
        //    int[] TamArquivoposicao_4_01 = new int[ListaArquivos.Length];
        //    int[] TamCarteira = new int[ListaArquivos.Length];
        //    int[] TamFundo = new int[ListaArquivos.Length];
        //    int[] TamHeader = new int[ListaArquivos.Length];
        //    int[] TamPartplanprev = new int[ListaArquivos.Length];
        //    int[] TamTitprivado = new int[ListaArquivos.Length];
        //    int[] TamTitpublico = new int[ListaArquivos.Length];
        //    int[] TamDebenture = new int[ListaArquivos.Length];
        //    int[] TamCaixa = new int[ListaArquivos.Length];
        //    int[] TamCotas = new int[ListaArquivos.Length];
        //    int[] TamDespesas = new int[ListaArquivos.Length];
        //    int[] TamAcoes = new int[ListaArquivos.Length];
        //    int[] TamProvisao = new int[ListaArquivos.Length];
        //    int[] TamCorretagem = new int[ListaArquivos.Length];
        //    #endregion

        //    #region Lê XML e faz levantamento de elementos
        //    //Declara Elemento XML
        //    XmlNodeList xmlnode;
        //    int i = 0;
        //    string auxData = null;

        //    //Abre arquivo
        //    foreach (FileInfo ArquivosXML in ListaArquivos)
        //    {

        //        #region Inicializa XML
        //        XmlDocument xmldoc = new XmlDocument();
        //        xmldoc.Load(ArquivosXML.FullName);
        //        rtLOG.Text += "Iniciando processamento do arquivo " + ArquivosXML.Name + "\r\n";

        //        #endregion

        //        #region Processamentos da data do Arquivo XML
        //        //Processamentos do nome do Arquivo XML
        //        //Processar tipos e datas
        //        xmlnode = xmldoc.GetElementsByTagName("dtposicao");

        //        if (auxData == null)
        //        {
        //            auxData = xmlnode[0].InnerText;
        //        }

        //        else if (auxData == xmlnode[0].InnerText)
        //        {
        //            rtLOG.Text += "Data do arquivo verificada!: "+xmlnode[0].InnerText+"\r\n";
        //        }

        //        else
        //        {
        //            rtLOG.Text += "Data do arquivo está diferente!" +xmlnode[0].InnerText+"\r\n ";
        //            DialogResult dialogResult = MessageBox.Show("Data do Arquivo: \r\n " + ArquivosXML.Name + "\r\nDiferente das demais, deseja continuar?\r\n", "Confirmacao", MessageBoxButtons.YesNo);
        //            if (dialogResult == DialogResult.Yes)
        //            {
        //                //nada
        //            }
        //            else if (dialogResult == DialogResult.No)
        //            {
        //                //pula
        //                rtLOG.Text += "Processo abortado pelo Usuario!\r\n";
        //                goto PulaGravaLOG;
        //            }

        //        }

        //        #endregion

        //        #region Processamentos Internos do XML (versão XML e levantamento de elementos)
        //        //Testa se é a versão 4_01
        //        xmlnode = xmldoc.GetElementsByTagName("arquivoposicao_4_01");
        //        if (xmlnode.Count != 1)
        //        {
        //            rtLOG.Text += ArquivosXML.Name + ": \r\nVersao do XML diferente da 4_01 \r\n";
        //            MessageBox.Show(ArquivosXML.Name + ": \r\nVersão do XML diferente da 4_01\r\nO processamento será abortado!\r\n");
        //            rtLOG.Text += "Processo abortado pelo Usuario!\r\n";
        //            goto PulaGravaLOG;
        //        }

        //        //Se for a versão correta, faz o levantamento dos elementos de cada XML
        //        else
        //        {
        //            xmlnode = xmldoc.GetElementsByTagName("fundo");
        //            TamFundo[i] = xmlnode.Count;
        //            rtLOG.Text += "Fundo: " + TamFundo[i] + "\r\n";
        //            xmlnode = xmldoc.GetElementsByTagName("carteira");
        //            TamCarteira[i] = xmlnode.Count;
        //            rtLOG.Text += "Carteira: " + TamCarteira[i] + "\r\n";
        //            xmlnode = xmldoc.GetElementsByTagName("header");
        //            TamHeader[i] = xmlnode.Count;
        //            rtLOG.Text += "Header: " + TamHeader[i] + "\r\n";
        //            xmlnode = xmldoc.GetElementsByTagName("partplanprev");
        //            TamPartplanprev[i] = xmlnode.Count;
        //            rtLOG.Text += "Partplanprev: " + TamPartplanprev[i] + "\r\n";
        //            xmlnode = xmldoc.GetElementsByTagName("titprivado");
        //            TamTitprivado[i] = xmlnode.Count;
        //            rtLOG.Text += "Titprivado: " + TamTitprivado[i] + "\r\n";
        //            xmlnode = xmldoc.GetElementsByTagName("titpublico");
        //            TamTitpublico[i] = xmlnode.Count;
        //            rtLOG.Text += "Titpublico: " + TamTitpublico[i] + "\r\n";
        //            xmlnode = xmldoc.GetElementsByTagName("debenture");
        //            TamDebenture[i] = xmlnode.Count;
        //            rtLOG.Text += "Debenture: " + TamDebenture[i] + "\r\n";
        //            xmlnode = xmldoc.GetElementsByTagName("caixa");
        //            TamCaixa[i] = xmlnode.Count;
        //            rtLOG.Text += "Caixa: " + TamCaixa[i] + "\r\n";
        //            xmlnode = xmldoc.GetElementsByTagName("cotas");
        //            TamCotas[i] = xmlnode.Count;
        //            rtLOG.Text += "Cotas: " + TamCotas[i] + "\r\n";
        //            xmlnode = xmldoc.GetElementsByTagName("despesas");
        //            TamDespesas[i] = xmlnode.Count;
        //            rtLOG.Text += "Despesas: " + TamDespesas[i] + "\r\n";
        //            xmlnode = xmldoc.GetElementsByTagName("acoes");
        //            TamAcoes[i] = xmlnode.Count;
        //            rtLOG.Text += "Acoes: " + TamAcoes[i] + "\r\n";
        //            xmlnode = xmldoc.GetElementsByTagName("provisao");
        //            TamProvisao[i] = xmlnode.Count;
        //            rtLOG.Text += "Provisao: " + TamProvisao[i] + "\r\n";
        //            xmlnode = xmldoc.GetElementsByTagName("corretagem");
        //            TamCorretagem[i] = xmlnode.Count;
        //            rtLOG.Text += "Corretagem: " + TamCorretagem[i] + "\r\n";
        //            //xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
        //            //str = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
        //            //MessageBox.Show(str);
        //        }
        //        #endregion

        //        #region Testes com XML
        //        //regiao para testar funções uteis de xml
        //        //<Names>
        //        //    <Name>
        //        //        <FirstName>John</FirstName>
        //        //        <LastName>Smith</LastName>
        //        //    </Name>
        //        //    <Name>
        //        //        <FirstName>James</FirstName>
        //        //        <LastName>White</LastName>
        //        //    </Name>
        //        //</Names>

        //        //To get all <Name> nodes use XPath expression /Names/Name. The first slash means that the <Names> node must be a root node. SelectNodes method returns collection XmlNodeList which will contain the <Name> nodes. To get value of sub node <FirstName> you can simply index XmlNode with the node name: xmlNode["FirstName"].InnerText. See the example below.
        //        //[C#]

        //        //XmlDocument xml = new XmlDocument();
        //        //xml.LoadXml(ArquivosXML.FullName); // suppose that myXmlString contains "<Names>...</Names>"

        //        //XmlNodeList xnList = xml.SelectNodes("/Names/Name");
        //        //foreach (XmlNode xn in xnList)
        //        //{
        //        //    string firstName = xn["FirstName"].InnerText;
        //        //    string lastName = xn["LastName"].InnerText;
        //        //    Console.WriteLine("Name: {0} {1}", firstName, lastName);
        //        //}


        //        //The output is:

        //        //Name: John Smith
        //        //Name: James White

        //        #region Header
        //        int iHeader = 0;
        //        if (TamCarteira[i] == 1 && TamFundo[i] == 0)
        //        {
        //        #region HeaderCarteira
        //        xmlnode = xmldoc.SelectNodes("/arquivoposicao_4_01/carteira/header");
        //        GerenciaProcessoXML.stHeaderCarteira401[] HeaderCarteira401 = new GerenciaProcessoXML.stHeaderCarteira401[TamHeader[i]];
                
        //        foreach (XmlNode xn in xmlnode)
        //        {
        //            HeaderCarteira401[iHeader] = new GerenciaProcessoXML.stHeaderCarteira401();
        //            HeaderCarteira401[iHeader].cnpjcpf = xn["cnpjcpf"].InnerText;
        //            HeaderCarteira401[iHeader].codcart = xn["codcart"].InnerText;
        //            HeaderCarteira401[iHeader].dtposicao = xn["dtposicao"].InnerText;
        //            HeaderCarteira401[iHeader].nome = xn["nome"].InnerText;
        //            HeaderCarteira401[iHeader].tpcli = xn["tpcli"].InnerText;
        //            HeaderCarteira401[iHeader].codcntcor = xn["codcntcor"].InnerText;
        //            HeaderCarteira401[iHeader].nomegestor = xn["nomegestor"].InnerText;
        //            HeaderCarteira401[iHeader].cnpjgestor = xn["cnpjgestor"].InnerText;
        //            HeaderCarteira401[iHeader].nomecustodiante = xn["nomecustodiante"].InnerText;
        //            HeaderCarteira401[iHeader].cnpjcustodiante = xn["cnpjcustodiante"].InnerText;
        //            HeaderCarteira401[iHeader].patliq = xn["patliq"].InnerText;
        //            HeaderCarteira401[iHeader].tributos = xn["tributos"].InnerText;
        //            HeaderCarteira401[iHeader].valorativos = xn["valorativos"].InnerText;
        //            HeaderCarteira401[iHeader].valorreceber = xn["valorreceber"].InnerText;
        //            HeaderCarteira401[iHeader].valorpagar = xn["valorpagar"].InnerText;
        //            iHeader++;
        //        }
        //        }
        //        #endregion
        //        #region HeaderFundo
        //        else if (TamCarteira[i] == 0 && TamFundo[i] == 1)
        //        {
        //            xmlnode = xmldoc.SelectNodes("/arquivoposicao_4_01/fundo/header");
        //            GerenciaProcessoXML.stHeaderFundo401[] HeaderFundo401 = new GerenciaProcessoXML.stHeaderFundo401[TamHeader[i]];

        //            foreach (XmlNode xn in xmlnode)
        //            {
        //                HeaderFundo401[iHeader] = new GerenciaProcessoXML.stHeaderFundo401();
        //                HeaderFundo401[iHeader].isin = xn["isin"].InnerText;
        //                HeaderFundo401[iHeader].cnpj = xn["cnpj"].InnerText;
        //                HeaderFundo401[iHeader].nome = xn["nome"].InnerText;
        //                HeaderFundo401[iHeader].dtposicao = xn["dtposicao"].InnerText;
        //                HeaderFundo401[iHeader].nomeadm = xn["nomeadm"].InnerText;
        //                HeaderFundo401[iHeader].cnpjadm = xn["cnpjadm"].InnerText;
        //                HeaderFundo401[iHeader].nomegestor = xn["nomegestor"].InnerText;
        //                HeaderFundo401[iHeader].cnpjgestor = xn["cnpjgestor"].InnerText;
        //                HeaderFundo401[iHeader].nomecustodiante = xn["nomecustodiante"].InnerText;
        //                HeaderFundo401[iHeader].cnpjcustodiante = xn["cnpjcustodiante"].InnerText;
        //                HeaderFundo401[iHeader].valorcota = xn["valorcota"].InnerText;
        //                HeaderFundo401[iHeader].quantidade = xn["quantidade"].InnerText;
        //                HeaderFundo401[iHeader].patliq = xn["patliq"].InnerText;
        //                HeaderFundo401[iHeader].valorativos = xn["valorativos"].InnerText;
        //                HeaderFundo401[iHeader].valorreceber = xn["valorreceber"].InnerText;
        //                HeaderFundo401[iHeader].valorpagar = xn["valorpagar"].InnerText;
        //                HeaderFundo401[iHeader].vlcotasemitir = xn["vlcotasemitir"].InnerText;
        //                HeaderFundo401[iHeader].vlcotasresgatar = xn["vlcotasresgatar"].InnerText;
        //                HeaderFundo401[iHeader].codanbid = xn["codanbid"].InnerText;//erro
        //                HeaderFundo401[iHeader].tipofundo = xn["tipofundo"].InnerText;
        //                HeaderFundo401[iHeader].nivelrsc = xn["nivelrsc"].InnerText;
        //                iHeader++;
        //            }
        //        }
        //        #endregion
        //        #region Header não encontrado!
        //        else
        //        {
        //            rtLOG.Text += ArquivosXML.Name + ": \r\nHeader não encontrado! \r\n";
        //            MessageBox.Show(ArquivosXML.Name + ": \r\nHeader não encontrado!\r\n");
        //        }
        //        #endregion
        //        #endregion




        //        #endregion

        //        //Finaliza processamento de um arquivo e para passar para o próximo
        //        rtLOG.Text += "===========================================================================\r\n";//Separação de arquivos XML no LOG.
        //        i++;



        //    }
        //    #endregion



        //PulaGravaLOG: // Em caso de erro grave nos arquivos XML, finaliza programa
        //    #region GravaLOG
        //    ////Grava no LOG textBox
        //    //rtLOG.SaveFile(PastaXML + "LOG.rtf");
        //    Ab (rtLOG, PastaXML + "LOG.rtf");
            #endregion
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void rtLOG_TextChanged(object sender, EventArgs e)
        {

        }


    }

}
