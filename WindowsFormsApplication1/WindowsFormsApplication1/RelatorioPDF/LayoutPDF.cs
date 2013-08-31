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
// Classes nativas
using WindowsFormsApplication1;
using TabelaElementos;

namespace RelatorioPDF
{

    public class LayoutPDF
    {
        public void GerarRelatorio()
        {
            // Acessa dados
             string pastaXML = "..\\..\\..\\..\\XML_files";
            DirectoryInfo DirInfo = new DirectoryInfo(pastaXML);
            FileInfo[] ListaArquivos = DirInfo.GetFiles("*.xml");

            XDocument[] xmldoc = WindowsFormsApplication1.CarregaChecaXML.XMLdocs(ListaArquivos);
            List<TabelaElementos.Cotas> cotas = WindowsFormsApplication1.ColetaDados.ListaCotas(xmldoc);

            // Estilos do PDF
            PdfDocument docPDF = new PdfDocument();
            PdfPage pag = docPDF.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(pag);
            XFont fonteHeaderPagina = new XFont("Verdana", 16, XFontStyle.Bold);
            XFont fonteHeaderTabela = new XFont("Verdana", 12, XFontStyle.Bold);
            XFont fonteItensTabela = new XFont("Times New Roman", 8);

            int posX = 50;
            int posY = 50;
            gfx.DrawString("ISIN", fonteHeaderTabela, XBrushes.DarkBlue, posX, posY);
            posY += 20;
            foreach(TabelaElementos.Cotas cota in cotas){
                gfx.DrawString(cota.ISIN, fonteItensTabela, XBrushes.Black, posX, posY);
                posY += 20;
            }

            // Save the document...
            const string filename = "RelatorioTeste.pdf";
            docPDF.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }
    }
}