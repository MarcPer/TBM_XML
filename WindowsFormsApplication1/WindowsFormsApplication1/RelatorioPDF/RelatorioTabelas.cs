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
using MigraDoc.DocumentObjectModel.Tables;
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

        public static void DefinirEstilos(Document docPDF)
        {
            Style style = docPDF.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 8;

            // Heading1 to Heading9 are predefined styles with an outline level. An outline level
            // other than OutlineLevel.BodyText automatically creates the outline (or bookmarks) 
            // in PDF.
            style = docPDF.Styles["Heading1"];
            style.Font.Name = "Tahoma";
            style.Font.Size = 14;
            style.Font.Bold = true;
            style.Font.Color = Colors.DarkBlue;
            style.ParagraphFormat.PageBreakBefore = true;
            style.ParagraphFormat.SpaceAfter = 6;

            style = docPDF.Styles["Heading2"];
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 6;

            style = docPDF.Styles["Heading3"];
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 3;
        }

        public static void GerarHeader(XDocument[] xmldoc, Document docPDF)
        {
            List<TabelaElementos.Header> headers = ColetaDados.ListaHeaders(xmldoc);

            Section secao = docPDF.AddSection();
            Paragraph paragrafo = secao.AddParagraph("Informações Gerais", "Heading3");
            
            paragrafo = secao.AddParagraph();
            paragrafo.AddText("Data");

            Table table = new Table();
            table.Borders.Width = 0.75;

            Column column = table.AddColumn(Unit.FromCentimeter(2));
            column.Format.Alignment = ParagraphAlignment.Center;

            table.AddColumn(Unit.FromCentimeter(5));
            table.AddColumn(Unit.FromCentimeter(5));

            Row row = table.AddRow();
            row.Shading.Color = Colors.CadetBlue;
            Cell cell = row.Cells[0];
            cell.AddParagraph("Item");
            cell = row.Cells[1];
            cell.AddParagraph("Nome");
            cell = row.Cells[2];
            cell.AddParagraph("Patrimônio Líquido");

            foreach (TabelaElementos.Header item in headers)
            {
                row = table.AddRow();
                cell = row.Cells[0];
                cell.AddParagraph(item.Item.ToString());
                cell = row.Cells[1];
                cell.AddParagraph(item.Nome.ToString());
                cell = row.Cells[2];
                cell.AddParagraph(item.PatLiquido.ToString());
            }

            //table.SetEdge(0, 0, 2, 3, Edge.Box, BorderStyle.Single, 1.5, Colors.Black);
            secao.Add(table);
        }


        public static void GerarCotas(XDocument[] xmldoc, Document docPDF)
        {
            List<TabelaElementos.Cotas> cotas = WindowsFormsApplication1.ColetaDados.ListaCotas(xmldoc);

            Section secao = docPDF.AddSection();
            Paragraph paragrafo = secao.AddParagraph("Fundos de Investimento", "Heading3");
            
            Table table = new Table();
            table.Borders.Width = 0.75;
                        
            Column column = table.AddColumn(Unit.FromCentimeter(2));
            column.Format.Alignment = ParagraphAlignment.Center;

            table.AddColumn();
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();

            Row row = table.AddRow();
            row.Shading.Color = Colors.CadetBlue;
            Cell cell = row.Cells[0];
            cell.AddParagraph("Classe");
            cell = row.Cells[1];
            cell.AddParagraph("Nome do Fundo");
            cell = row.Cells[2];
            cell.AddParagraph("Código ISIN do Fundo");
            cell = row.Cells[3];
            cell.AddParagraph("Quantidade de cotas");
            cell = row.Cells[4];
            cell.AddParagraph("Valor da Cota");
            cell = row.Cells[5];
            cell.AddParagraph("Valor Bruto");
            cell = row.Cells[6];
            cell.AddParagraph("Impostos");
            cell = row.Cells[7];
            cell.AddParagraph("Valor Líquido");

            foreach (TabelaElementos.Cotas item in cotas)
            {
                row = table.AddRow();
                cell = row.Cells[0];
                cell.AddParagraph("Classe");
                cell = row.Cells[1];
                cell.AddParagraph("Nome");
                cell = row.Cells[2];
                cell.AddParagraph(item.ISIN.ToString());
                cell = row.Cells[3];
                cell.AddParagraph(item.QtCotas.ToString());
                cell = row.Cells[4];
                cell.AddParagraph(item.PU.ToString());
                cell = row.Cells[5];
                cell.AddParagraph(item.ValorBruto.ToString());
                cell = row.Cells[6];
                cell.AddParagraph(item.Impostos.ToString());
                cell = row.Cells[7];
                cell.AddParagraph(item.ValorLiquido.ToString());
            }

            secao.Add(table);

        }
    }
}