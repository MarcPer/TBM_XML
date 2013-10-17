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
            secao.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Landscape;
            secao.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            secao.PageSetup.PageFormat = PageFormat.A3;
            RelatorioTabelas.DefinirEstilos(docPDF);
            RelatorioTabelas.GerarHeader(xmldoc, secao);
            Paragraph paragraph = secao.AddParagraph();
            AdicionaLinhaHorizontal(secao);
            secao.AddParagraph(); secao.AddParagraph();
            RelatorioTabelas.GerarCotas(xmldoc, secao);
            secao.AddParagraph(); secao.AddParagraph();
            secao.AddParagraph("Ativos da Carteira", "Heading2");
            RelatorioTabelas.GerarCreditoPrivado(xmldoc, secao);
            secao.AddParagraph();
            RelatorioTabelas.GerarTitulosPublicos(xmldoc, secao);
            secao.AddParagraph();
            RelatorioTabelas.GerarAcoes(xmldoc, secao);


            
            // Salva o documento
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false,PdfFontEmbedding.Always);
            pdfRenderer.Document = docPDF;
            pdfRenderer.RenderDocument();
            const string filename = "RelatorioTeste.pdf";
            pdfRenderer.PdfDocument.Save(filename);
            // Mostra no visualizador padrão
            Process.Start(filename);
        }

        public static void AdicionaLinhaHorizontal(Section section)
        {
            Paragraph paragraph = section.AddParagraph();
            Border linhaHorizontal = new Border();
            linhaHorizontal.Color = Colors.Black;
            paragraph.Format.Borders.Bottom = linhaHorizontal;
        }
    }
}