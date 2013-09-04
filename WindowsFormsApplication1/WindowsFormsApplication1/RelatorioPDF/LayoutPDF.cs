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

    public static class LayoutPDF
    {
        public static void GerarRelatorio()
        {
            // Acessa dados
            string pastaXML = "..\\..\\..\\..\\XML_files";
            DirectoryInfo DirInfo = new DirectoryInfo(pastaXML);
            FileInfo[] ListaArquivos = DirInfo.GetFiles("*.xml");
            XDocument[] xmldoc = WindowsFormsApplication1.CarregaChecaXML.XMLdocs(ListaArquivos);

            // Estilos do PDF
            Document docPDF = new Document();
            Section secao = docPDF.AddSection();
            Paragraph paragraph = secao.AddParagraph();
            paragraph.Format.Font.Color = Color.FromCmyk(100, 30, 20, 50);
            Font fonteHeaderPagina = new Font("Verdana", 16);
            fonteHeaderPagina.Bold = true;
            Font fonteHeaderClasse = new Font("Verdana", 10);
            fonteHeaderPagina.Bold = true;
            Font fonteHeaderTabela = new Font("Verdana", 8);
            fonteHeaderTabela.Bold = true;
            Font fonteItensTabela = new Font("Times New Roman", 8);

            RelatorioTabelas.GerarHeader(xmldoc, secao, fonteHeaderClasse, fonteHeaderTabela, fonteItensTabela);
            RelatorioTabelas.GerarCotas(xmldoc, secao, fonteHeaderClasse, fonteHeaderTabela, fonteItensTabela);
            
            // Salva o documento
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false,PdfFontEmbedding.Always);
            pdfRenderer.Document = docPDF;
            pdfRenderer.RenderDocument();
            const string filename = "RelatorioTeste.pdf";
            pdfRenderer.PdfDocument.Save(filename);
            // Mostra no visualizador padrão
            Process.Start(filename);
        }
    }
}