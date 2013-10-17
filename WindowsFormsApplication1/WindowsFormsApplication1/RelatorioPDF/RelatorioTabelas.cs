using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Globalization;
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
            style.Font.Color = Colors.Tomato;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 6;

            style = docPDF.Styles["Heading3"];
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.Font.Color = Colors.DarkBlue;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 3;

            style = docPDF.Styles.AddStyle("ItemTabela","Normal");
            style.Font.Size = 8;
            style.Font.Bold = false;
            style.Font.Italic = false;
            style.ParagraphFormat.SpaceBefore = 3;
            style.ParagraphFormat.SpaceAfter = 3;

            style = docPDF.Styles.AddStyle("ItemTabelaMaior", "Normal");
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Italic = false;
            style.Font.Color = Colors.White;
            style.ParagraphFormat.SpaceBefore = 3;
            style.ParagraphFormat.SpaceAfter = 3;
        }

        public static void GerarHeader(XDocument[] xmldoc, Section secao)
        {
            List<TabelaElementos.Header> headers = ColetaDados.ListaHeaders(xmldoc);

            Paragraph paragrafo = secao.AddParagraph("Informações Gerais", "Heading2");
            
            Table table = new Table();
            table.Borders.Width = 0.75;

            Column column = table.AddColumn(Unit.FromCentimeter(5));
            column.Format.Alignment = ParagraphAlignment.Right;
            column.Borders.Visible = false;
            column = table.AddColumn(Unit.FromCentimeter(4));
            column.Format.Alignment = ParagraphAlignment.Center;
            column.Borders.Visible = false;
            column = table.AddColumn(Unit.FromCentimeter(2));
            column.Format.Alignment = ParagraphAlignment.Center;
            column.Borders.Visible = false;
            column = table.AddColumn(Unit.FromCentimeter(1));
            column.Format.Alignment = ParagraphAlignment.Center;
            column = table.AddColumn(Unit.FromCentimeter(8));
            column.Format.Alignment = ParagraphAlignment.Center;
            column = table.AddColumn(Unit.FromCentimeter(4));
            column.Format.Alignment = ParagraphAlignment.Right;

            Row row = table.AddRow();
            Cell cell = row.Cells[0];
            cell.Shading.Color = Colors.CadetBlue;
            Paragraph pgf = cell.AddParagraph();
            pgf.AddFormattedText("Data da Posição", "ItemTabelaMaior");
            cell = row.Cells[1];
            cell.VerticalAlignment = VerticalAlignment.Center;
            pgf = cell.AddParagraph();
            pgf.AddFormattedText(ColetaDados.DataDaUltimaPosicao(headers), "ItemTabela");
            cell = row.Cells[2];
            cell.Borders.Visible = false;
            cell = row.Cells[3];
            cell.Shading.Color = Colors.CadetBlue;
            pgf = cell.AddParagraph();
            pgf.AddFormattedText("Item");
            cell = row.Cells[4];
            cell.Shading.Color = Colors.CadetBlue;
            pgf = cell.AddParagraph();
            pgf.AddFormattedText("Nome");
            cell = row.Cells[5];
            cell.Shading.Color = Colors.CadetBlue;
            cell.Format.Alignment = ParagraphAlignment.Center;
            pgf = cell.AddParagraph();
            pgf.AddFormattedText("Patrimônio Líquido");

            int numRows = 1;
            float patLiqTotal = 0f;
            foreach (TabelaElementos.Header item in headers)
            {
                numRows++;
                row = table.AddRow();
                cell = row.Cells[3];
                cell.Format.Alignment = ParagraphAlignment.Center;
                Paragraph par = cell.AddParagraph();
                par.AddFormattedText(item.Item.ToString(), "ItemTabela");
                cell = row.Cells[4];
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(item.Nome.ToString(), "ItemTabela");
                cell = row.Cells[5];
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.PatLiquido), "ItemTabela");
                patLiqTotal += float.Parse(item.PatLiquido);
            }

            while (numRows < 5)
            {
                numRows++;
                row = table.AddRow();
                row.Borders.Visible = false;
            }
            row = table.Rows[2];
            cell = row.Cells[0];
            cell.Shading.Color = Colors.CadetBlue;
            pgf = cell.AddParagraph();
            pgf.AddFormattedText("Nº de arquivos - Entrada", "ItemTabelaMaior");
            cell = row.Cells[1];
            cell.VerticalAlignment = VerticalAlignment.Center;
            pgf = cell.AddParagraph();
            pgf.AddFormattedText(xmldoc.Length.ToString(), "ItemTabela");
            row = table.Rows[4];
            cell = row.Cells[0];
            cell.Shading.Color = Colors.CadetBlue;
            pgf = cell.AddParagraph();
            pgf.AddFormattedText("Patrimônio Total", "ItemTabelaMaior");
            cell = row.Cells[1];
            cell.VerticalAlignment = VerticalAlignment.Center;
            pgf = cell.AddParagraph();
            pgf.AddFormattedText(formataValorMonetario(patLiqTotal.ToString()), "ItemTabela");
            //table.SetEdge(0, 0, 2, 3, Edge.Box, BorderStyle.Single, 1.5, Colors.Black);
            secao.Add(table);
        }


        public static void GerarCotas(XDocument[] xmldoc, Section secao)
        {
            List<TabelaElementos.Cotas> cotas = WindowsFormsApplication1.ColetaDados.ListaCotas(xmldoc);

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
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Classe");
            cell = row.Cells[1];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Nome do Fundo");
            cell = row.Cells[2];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Código ISIN do Fundo");
            cell = row.Cells[3];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Quantidade de cotas");
            cell = row.Cells[4];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Valor da Cota");
            cell = row.Cells[5];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Valor Bruto");
            cell = row.Cells[6];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Impostos");
            cell = row.Cells[7];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Valor Líquido");

            foreach (TabelaElementos.Cotas item in cotas)
            {
                row = table.AddRow();
                cell = row.Cells[0];
                cell.Format.Alignment = ParagraphAlignment.Center;
                Paragraph par = cell.AddParagraph();
                par.AddFormattedText("Classe", "ItemTabela");
                cell = row.Cells[1];
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText("Nome", "ItemTabela");
                cell = row.Cells[2];
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(item.ISIN, "ItemTabela");
                cell = row.Cells[3];
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(item.QtCotas, "ItemTabela");
                cell = row.Cells[4];
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.PU), "ItemTabela");
                cell = row.Cells[5];
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.ValorBruto),"ItemTabela");
                cell = row.Cells[6];
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.Impostos), "ItemTabela");
                cell = row.Cells[7];
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.ValorLiquido), "ItemTabela");
            }

            secao.Add(table);

        }

        public static void GerarCreditoPrivado(XDocument[] xmldoc, Section secao)
        {
            List<TabelaElementos.CreditoPrivado> credPriv = WindowsFormsApplication1.ColetaDados.CreditoPrivado(xmldoc);

            Paragraph paragrafo = secao.AddParagraph("Crédito Privado", "Heading3");

            Table table = new Table();
            table.Borders.Width = 0.75;

            Column column = table.AddColumn(Unit.FromCentimeter(2));
            column.Format.Alignment = ParagraphAlignment.Center;

            table.AddColumn();
            table.AddColumn();
            table.AddColumn(Unit.FromCentimeter(1.7));
            table.AddColumn(Unit.FromCentimeter(2));
            table.AddColumn(Unit.FromCentimeter(1.7));
            table.AddColumn(Unit.FromCentimeter(1.7));
            table.AddColumn(Unit.FromCentimeter(1.7));
            table.AddColumn(Unit.FromCentimeter(1.7));
            table.AddColumn(Unit.FromCentimeter(1.7));
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();

            Row row = table.AddRow();
            Cell cell = row.Cells[0];
            cell.Borders.Visible = false;
            cell.MergeRight = 4;
            cell = row.Cells[5];
            cell.Shading.Color = Colors.CadetBlue;
            cell.MergeRight = 2;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Data");
            cell = row.Cells[8];
            cell.Shading.Color = Colors.CadetBlue;
            cell.MergeRight = 2;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Quantidades");
            cell = row.Cells[11];
            cell.Borders.Visible = false;
            cell.MergeRight = 2;

            row = table.AddRow();
            row.Shading.Color = Colors.CadetBlue;
            cell = row.Cells[0];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Código do Ativo");
            cell = row.Cells[1];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Código ISIN do Papel");
            cell = row.Cells[2];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Emissor");
            cell = row.Cells[3];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Indexador");
            cell = row.Cells[4];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Cupom");
            cell = row.Cells[5];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Emissão");
            cell = row.Cells[6];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Compra");
            cell = row.Cells[7];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Vencimento");
            cell = row.Cells[8];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Disponível");
            cell = row.Cells[9];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Garantia");
            cell = row.Cells[10];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("PU");
            cell = row.Cells[11];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Valor Bruto");
            cell = row.Cells[12];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Impostos");
            cell = row.Cells[13];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Valor Líquido");

            foreach (TabelaElementos.CreditoPrivado item in credPriv)
            {
                row = table.AddRow();
                cell = row.Cells[0];
                cell.Format.Alignment = ParagraphAlignment.Center;
                Paragraph par = cell.AddParagraph();
                par.AddFormattedText(item.CodAtivo.ToString(), "ItemTabela");
                cell = row.Cells[1];
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(item.ISIN.ToString(), "ItemTabela");
                cell = row.Cells[2];
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(item.Emissor.ToString(), "ItemTabela");
                cell = row.Cells[3];
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(item.Indexador.ToString(), "ItemTabela");
                cell = row.Cells[4];
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.Cupom.ToString()), "ItemTabela");
                cell = row.Cells[5];
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(formataData(item.DataEmissao.ToString()), "ItemTabela");
                cell = row.Cells[6];
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(formataData(item.DataCompra.ToString()), "ItemTabela");
                cell = row.Cells[7];
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(formataData(item.DataVencimento.ToString()), "ItemTabela");
                cell = row.Cells[8];
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(item.Disponivel.ToString(), "ItemTabela");
                cell = row.Cells[9];
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(item.Garantia.ToString(), "ItemTabela");
                cell = row.Cells[10];
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.PU.ToString()), "ItemTabela");
                cell = row.Cells[11];
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.ValorBruto.ToString()), "ItemTabela");
                cell = row.Cells[12];
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.Impostos.ToString()), "ItemTabela");
                cell = row.Cells[13];
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.ValorLiquido.ToString()), "ItemTabela");
            }

            secao.Add(table);

        }

        public static void GerarTitulosPublicos(XDocument[] xmldoc, Section secao)
        {
            List<TabelaElementos.TitPublico> titPubl = WindowsFormsApplication1.ColetaDados.TitulosPublicos(xmldoc);

            Paragraph paragrafo = secao.AddParagraph("Títulos Públicos", "Heading3");

            Table table = new Table();
            table.Borders.Width = 0.75;

            Column column = table.AddColumn(Unit.FromCentimeter(2));
            column.Format.Alignment = ParagraphAlignment.Center;

            table.AddColumn();
            table.AddColumn(Unit.FromCentimeter(1.7));
            table.AddColumn(Unit.FromCentimeter(2));
            table.AddColumn(Unit.FromCentimeter(1.7));
            table.AddColumn(Unit.FromCentimeter(1.7));
            table.AddColumn(Unit.FromCentimeter(1.7));
            table.AddColumn(Unit.FromCentimeter(1.7));
            table.AddColumn(Unit.FromCentimeter(1.7));
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();

            Row row = table.AddRow();
            Cell cell = row.Cells[0];
            cell.Borders.Visible = false;
            cell.MergeRight = 3;
            cell = row.Cells[4];
            cell.Shading.Color = Colors.CadetBlue;
            cell.MergeRight = 2;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Data");
            cell = row.Cells[7];
            cell.Shading.Color = Colors.CadetBlue;
            cell.MergeRight = 2;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Quantidades");
            cell = row.Cells[10];
            cell.Borders.Visible = false;
            cell.MergeRight = 2;

            row = table.AddRow();
            row.Shading.Color = Colors.CadetBlue;
            cell = row.Cells[0];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Código do Ativo");
            cell = row.Cells[1];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Código ISIN do Papel");
            cell = row.Cells[2];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Indexador");
            cell = row.Cells[3];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Cupom");
            cell = row.Cells[4];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Emissão");
            cell = row.Cells[5];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Compra");
            cell = row.Cells[6];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Vencimento");
            cell = row.Cells[7];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Disponível");
            cell = row.Cells[8];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Garantia");
            cell = row.Cells[9];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("PU");
            cell = row.Cells[10];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Valor Bruto");
            cell = row.Cells[11];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Impostos");
            cell = row.Cells[12];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Valor Líquido");

            foreach (TabelaElementos.TitPublico item in titPubl)
            {
                int i = 0;
                row = table.AddRow();
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Center;
                Paragraph par = cell.AddParagraph();
                par.AddFormattedText(item.CodAtivo.ToString(), "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(item.ISIN.ToString(), "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(item.Indexador.ToString(), "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.Cupom.ToString()), "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(formataData(item.DataEmissao.ToString()), "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(formataData(item.DataCompra.ToString()), "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(formataData(item.DataVencimento.ToString()), "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(item.Disponivel.ToString(), "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(item.Garantia.ToString(), "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.PU.ToString()), "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.ValorBruto.ToString()), "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.Impostos.ToString()), "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Right;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.ValorLiquido.ToString()), "ItemTabela");
            }

            secao.Add(table);

        }

        public static void GerarAcoes(XDocument[] xmldoc, Section secao)
        {
            List<TabelaElementos.Acoes> acoes = WindowsFormsApplication1.ColetaDados.Acoes(xmldoc);

            Paragraph paragrafo = secao.AddParagraph("Ações", "Heading3");

            if (acoes.Count == 0){
                
                return;
                }
            
            Table table = new Table();
            table.Borders.Width = 0.75;

            Column column = table.AddColumn(Unit.FromCentimeter(2));
            column.Format.Alignment = ParagraphAlignment.Center;

            table.AddColumn();
            table.AddColumn();
            table.AddColumn(Unit.FromCentimeter(2));
            table.AddColumn(Unit.FromCentimeter(1.7));
            table.AddColumn(Unit.FromCentimeter(1.7));
            table.AddColumn();
            table.AddColumn();
            table.AddColumn();

            Row row = table.AddRow();
            Cell cell = row.Cells[0];
            cell.Borders.Visible = false;
            cell.MergeRight = 2;
            cell = row.Cells[3];
            cell.Shading.Color = Colors.CadetBlue;
            cell.MergeRight = 1;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Quantidade");
            cell = row.Cells[5];
            cell.Borders.Visible = false;
            cell.MergeRight = 3;

            row = table.AddRow();
            row.Shading.Color = Colors.CadetBlue;
            cell = row.Cells[0];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Código do Ativo");
            cell = row.Cells[1];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Emissor");
            cell = row.Cells[2];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Emissão");
            cell = row.Cells[3];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Disponível");
            cell = row.Cells[4];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Garantia");
            cell = row.Cells[5];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("PU");
            cell = row.Cells[6];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Valor Bruto");
            cell = row.Cells[7];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Impostos");
            cell = row.Cells[8];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Valor Líquido");

            foreach (TabelaElementos.Acoes item in acoes)
            {
                int i = 0;
                row = table.AddRow();
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Center;
                Paragraph par = cell.AddParagraph();
                par.AddFormattedText(item.CodAtivo, "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(item.ClasseOperacao, "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(item.DataEmissao, "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(item.Disponivel, "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(item.Garantia, "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(item.PU, "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.ValorBruto), "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.Impostos), "ItemTabela");
                cell = row.Cells[i]; i++;
                cell.Format.Alignment = ParagraphAlignment.Center;
                par = cell.AddParagraph();
                par.AddFormattedText(formataValorMonetario(item.ValorLiquido), "ItemTabela");
            }

            secao.Add(table);

        }

        private static String formataValorMonetario(String valor)
        {
            Double valorFloat = Double.Parse(valor, CultureInfo.InvariantCulture);
            //valor = valorFloat.ToString("0.00");
            //Regex regex = new Regex("\\.");
            //String valorFormatado = regex.Replace(valor, ",");
            String valorFormatado = "R$ " + String.Format(CultureInfo.GetCultureInfo("de-DE"), "{0:N}", valorFloat);
            //regex = new Regex("[^0-9,]");
            //valorFormatado = "R$ " + regex.Replace(valorFormatado, "");
            return valorFormatado;
        }

        private static String formataData(String data)
        {
            Regex regex = new Regex("(\\d{4})(\\d\\d)(\\d\\d)");
            String dataFormatada = regex.Replace(data, "$3/$2/$1");
            
            return dataFormatada;
        }
    }
}