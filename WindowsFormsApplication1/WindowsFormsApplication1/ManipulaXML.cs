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
    class ManipulaXML
    {

        public string Arquivo()
        {
            #region Variaveis
            //Variáveis
            string Retorno = "false";
            string stErro = null;

            //Pega Lista de Arquivos da pasta
            DirectoryInfo DirInfo = new DirectoryInfo(VGlobal.CaminhoXML);
            VGlobal.ListaArquivos = DirInfo.GetFiles("*.xml");

            //Lista tamanho de cada elemento de cada arquivo
            VGlobal.TamArquivoposicao_4_01 = new int[VGlobal.ListaArquivos.Length];
            VGlobal.TamCarteira = new int[VGlobal.ListaArquivos.Length];
            VGlobal.TamFundo = new int[VGlobal.ListaArquivos.Length];
            VGlobal.TamHeader = new int[VGlobal.ListaArquivos.Length];
            VGlobal.TamPartplanprev = new int[VGlobal.ListaArquivos.Length];
            VGlobal.TamTitprivado = new int[VGlobal.ListaArquivos.Length];
            VGlobal.TamTitpublico = new int[VGlobal.ListaArquivos.Length];
            VGlobal.TamDebenture = new int[VGlobal.ListaArquivos.Length];
            VGlobal.TamCaixa = new int[VGlobal.ListaArquivos.Length];
            VGlobal.TamCotas = new int[VGlobal.ListaArquivos.Length];
            VGlobal.TamDespesas = new int[VGlobal.ListaArquivos.Length];
            VGlobal.TamAcoes = new int[VGlobal.ListaArquivos.Length];
            VGlobal.TamProvisao = new int[VGlobal.ListaArquivos.Length];
            VGlobal.TamCorretagem = new int[VGlobal.ListaArquivos.Length];

            //Inicializa totais para contagem
            VGlobal.TamTotFundo = 0;
            VGlobal.TamTotCarteira = 0;
            VGlobal.TamTotHeader = 0;
            VGlobal.TamTotPartplanprev = 0;
            VGlobal.TamTotTitprivado = 0;
            VGlobal.TamTotTitpublico = 0;
            VGlobal.TamTotDebenture = 0;
            VGlobal.TamTotCaixa = 0;
            VGlobal.TamTotCotas = 0;
            VGlobal.TamTotDespesas = 0;
            VGlobal.TamTotAcoes = 0;
            VGlobal.TamTotProvisao = 0;
            VGlobal.TamTotCorretagem = 0;
            #endregion

            try
            {
                #region Lê XML e faz levantamento de elementos

                //Declara Elemento XML
                int i = 0;
                string auxData = null;

                //Abre arquivo
                foreach (FileInfo ArquivosXML in VGlobal.ListaArquivos)
                {

                    #region Inicializa XML
                    XmlDocument xmldoc = new XmlDocument();

                    VGlobal.rtLOG.Text += "Iniciando processamento do arquivo " + ArquivosXML.Name + "\r\n";
                    xmldoc.Load(ArquivosXML.FullName);

                    

                    #endregion

                    #region Processamentos da data do Arquivo XML
                    //Processamentos do nome do Arquivo XML
                    //Processar tipos e datas
                    VGlobal.xmlnode = xmldoc.GetElementsByTagName("dtposicao");

                    if (auxData == null)
                    {
                        auxData = VGlobal.xmlnode[0].InnerText;
                        VGlobal.rtLOG.Text += "Data padrao sera: " + VGlobal.xmlnode[0].InnerText + "\r\n";
                    }

                    else if (auxData == VGlobal.xmlnode[0].InnerText)
                    {
                        VGlobal.rtLOG.Text += "Data do arquivo verificada!: " + VGlobal.xmlnode[0].InnerText + "\r\n";
                    }

                    else
                    {
                        VGlobal.rtLOG.Text += "Data do arquivo esta diferente!" + VGlobal.xmlnode[0].InnerText + "\r\n ";
                        DialogResult dialogResult = MessageBox.Show("Data do Arquivo: \r\n" + ArquivosXML.Name + "\r\né " + VGlobal.xmlnode[0].InnerText + " e está diferente da data padrao " + auxData + ", deseja continuar?\r\n", "Confirmacao", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //nada
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //pula
                            VGlobal.rtLOG.Text += "Processo abortado pelo Usuario!\r\n";
                            Retorno = "true";
                            goto SaiFuncao;
                        }

                    }

                    #endregion

                    #region Processamentos Internos do XML (versão XML e levantamento de elementos)
                    //Testa se é a versão 4_01
                    VGlobal.xmlnode = xmldoc.GetElementsByTagName("arquivoposicao_4_01");
                    if (VGlobal.xmlnode.Count != 1)
                    {
                        VGlobal.rtLOG.Text += ArquivosXML.Name + ": \r\nVersao do XML diferente da 4_01 \r\n";
                        MessageBox.Show(ArquivosXML.Name + ": \r\nVersão do XML diferente da 4_01\r\nO processamento será abortado!\r\n");
                        VGlobal.rtLOG.Text += "Processo abortado pelo Usuario!\r\n";
                        Retorno = "true";
                        goto SaiFuncao;
                    }

                    //Se for a versão correta, faz o levantamento dos elementos de cada XML
                    else
                    {
                        VGlobal.xmlnode = xmldoc.GetElementsByTagName("fundo");
                        VGlobal.TamFundo[i] = VGlobal.xmlnode.Count;
                        VGlobal.TamTotFundo += VGlobal.xmlnode.Count;
                        VGlobal.rtLOG.Text += "Fundo: " + VGlobal.TamFundo[i] + "\r\n";
                        VGlobal.xmlnode = xmldoc.GetElementsByTagName("carteira");
                        VGlobal.TamCarteira[i] = VGlobal.xmlnode.Count;
                        VGlobal.TamTotCarteira += VGlobal.xmlnode.Count;
                        VGlobal.rtLOG.Text += "Carteira: " + VGlobal.TamCarteira[i] + "\r\n";
                        VGlobal.xmlnode = xmldoc.GetElementsByTagName("header");
                        VGlobal.TamHeader[i] = VGlobal.xmlnode.Count;
                        VGlobal.TamTotHeader += VGlobal.xmlnode.Count;
                        VGlobal.rtLOG.Text += "Header: " + VGlobal.TamHeader[i] + "\r\n";
                        VGlobal.xmlnode = xmldoc.GetElementsByTagName("partplanprev");
                        VGlobal.TamPartplanprev[i] = VGlobal.xmlnode.Count;
                        VGlobal.TamTotPartplanprev += VGlobal.xmlnode.Count;
                        VGlobal.rtLOG.Text += "Partplanprev: " + VGlobal.TamPartplanprev[i] + "\r\n";
                        VGlobal.xmlnode = xmldoc.GetElementsByTagName("titprivado");
                        VGlobal.TamTitprivado[i] = VGlobal.xmlnode.Count;
                        VGlobal.TamTotTitprivado += VGlobal.xmlnode.Count;
                        VGlobal.rtLOG.Text += "Titprivado: " + VGlobal.TamTitprivado[i] + "\r\n";
                        VGlobal.xmlnode = xmldoc.GetElementsByTagName("titpublico");
                        VGlobal.TamTitpublico[i] = VGlobal.xmlnode.Count;
                        VGlobal.TamTotTitpublico += VGlobal.xmlnode.Count;
                        VGlobal.rtLOG.Text += "Titpublico: " + VGlobal.TamTitpublico[i] + "\r\n";
                        VGlobal.xmlnode = xmldoc.GetElementsByTagName("debenture");
                        VGlobal.TamDebenture[i] = VGlobal.xmlnode.Count;
                        VGlobal.TamTotDebenture += VGlobal.xmlnode.Count;
                        VGlobal.rtLOG.Text += "Debenture: " + VGlobal.TamDebenture[i] + "\r\n";
                        VGlobal.xmlnode = xmldoc.GetElementsByTagName("caixa");
                        VGlobal.TamCaixa[i] = VGlobal.xmlnode.Count;
                        VGlobal.TamTotCaixa += VGlobal.xmlnode.Count;
                        VGlobal.rtLOG.Text += "Caixa: " + VGlobal.TamCaixa[i] + "\r\n";
                        VGlobal.xmlnode = xmldoc.GetElementsByTagName("cotas");
                        VGlobal.TamCotas[i] = VGlobal.xmlnode.Count;
                        VGlobal.TamTotCotas += VGlobal.xmlnode.Count;
                        VGlobal.rtLOG.Text += "Cotas: " + VGlobal.TamCotas[i] + "\r\n";
                        VGlobal.xmlnode = xmldoc.GetElementsByTagName("despesas");
                        VGlobal.TamDespesas[i] = VGlobal.xmlnode.Count;
                        VGlobal.TamTotDespesas += VGlobal.xmlnode.Count;
                        VGlobal.rtLOG.Text += "Despesas: " + VGlobal.TamDespesas[i] + "\r\n";
                        VGlobal.xmlnode = xmldoc.GetElementsByTagName("acoes");
                        VGlobal.TamAcoes[i] = VGlobal.xmlnode.Count;
                        VGlobal.TamTotAcoes += VGlobal.xmlnode.Count;
                        VGlobal.rtLOG.Text += "Acoes: " + VGlobal.TamAcoes[i] + "\r\n";
                        VGlobal.xmlnode = xmldoc.GetElementsByTagName("provisao");
                        VGlobal.TamProvisao[i] = VGlobal.xmlnode.Count;
                        VGlobal.TamTotProvisao += VGlobal.xmlnode.Count;
                        VGlobal.rtLOG.Text += "Provisao: " + VGlobal.TamProvisao[i] + "\r\n";
                        VGlobal.xmlnode = xmldoc.GetElementsByTagName("corretagem");
                        VGlobal.TamCorretagem[i] = VGlobal.xmlnode.Count;
                        VGlobal.TamTotCorretagem += VGlobal.xmlnode.Count;
                        VGlobal.rtLOG.Text += "Corretagem: " + VGlobal.TamCorretagem[i] + "\r\n";
                        //xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                        //str = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                        //MessageBox.Show(str);
                        //Finaliza processamento de um arquivo e para passar para o próximo
                        VGlobal.rtLOG.Text += "===========================================================================\r\n";//Separação de arquivos XML no LOG.
                        i++;
                    }
                    #endregion

                }
                #endregion

                #region Mostra Totais no LOG
                VGlobal.rtLOG.Text += "Quantidades totais de itens:\r\n";
                VGlobal.rtLOG.Text += "Fundo: " + VGlobal.TamTotFundo + "\r\n";
                VGlobal.rtLOG.Text += "Carteira: " + VGlobal.TamTotCarteira + "\r\n";
                VGlobal.rtLOG.Text += "Header: " + VGlobal.TamTotHeader + "\r\n";
                VGlobal.rtLOG.Text += "Partplanprev: " + VGlobal.TamTotPartplanprev + "\r\n";
                VGlobal.rtLOG.Text += "Titprivado: " + VGlobal.TamTotTitprivado + "\r\n";
                VGlobal.rtLOG.Text += "Titpublico: " + VGlobal.TamTotTitpublico + "\r\n";
                VGlobal.rtLOG.Text += "Debenture: " + VGlobal.TamTotDebenture + "\r\n";
                VGlobal.rtLOG.Text += "Caixa: " + VGlobal.TamTotCaixa + "\r\n";
                VGlobal.rtLOG.Text += "Cotas: " + VGlobal.TamTotCotas + "\r\n";
                VGlobal.rtLOG.Text += "Despesas: " + VGlobal.TamTotDespesas + "\r\n";
                VGlobal.rtLOG.Text += "Acoes: " + VGlobal.TamTotAcoes + "\r\n";
                VGlobal.rtLOG.Text += "Provisao: " + VGlobal.TamTotProvisao + "\r\n";
                VGlobal.rtLOG.Text += "Corretagem: " + VGlobal.TamTotCorretagem + "\r\n";
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
            VGlobal.rtLOG.Text += "Fim da contagem do topicos XML. Funcao ManipulaXML.Arquivo retornou: " + Retorno + "\r\n";
            VGlobal.rtLOG.Text += "===========================================================================\r\n";//Separação de arquivos XML no LOG.
            return Retorno;
            #endregion

        }
    }
}
