using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
// bibliotecas para XML
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
// bibliotecas para PDF
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.RtfRendering;
// Classes nativas
using WindowsFormsApplication1;
using TabelaElementos;

namespace RelatorioPDF
{
    public static class RelatorioTabelas
    {
        #region Variáveis de formatação
        static private int espacoAposHeaderClasse = 20;
        static private int espacoAposHeaderTabela = 20;
        static private int espacoVertElementosTabela = 20;

        #endregion

        public static void GerarHeader(XDocument[] xmldoc, Section secao, Font fonteHeaderClasse, Font fonteHeaderTabela, Font fonteItensTabela)
        {
            List<TabelaElementos.Header> headers = ColetaDados.ListaHeaders(xmldoc);

            Paragraph paragrafo = secao.AddParagraph();
            paragrafo.Format.Font = fonteHeaderClasse;
            paragrafo.AddText("Informações Gerais");
            
            paragrafo = secao.AddParagraph();
            paragrafo.Format.Font = fonteHeaderTabela;
            paragrafo.AddText("Data");
                        
            
        }


        public static void GerarCotas(XDocument[] xmldoc, Section secao, Font fonteHeaderClasse, Font fonteHeaderTabela, Font fonteItensTabela)
        {
            List<TabelaElementos.Cotas> cotas = WindowsFormsApplication1.ColetaDados.ListaCotas(xmldoc);

            
        }
    }
}