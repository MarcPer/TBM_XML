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

        public static void GerarHeader(XDocument[] xmldoc, XGraphics gfx, XFont fonteHeaderClasse, XFont fonteHeaderTabela, XFont fonteItensTabela, int posX, ref int posY)
        {
            List<TabelaElementos.Header> headers = ColetaDados.ListaHeaders(xmldoc);
            XRect xrect = new XRect(posX, posY, 50, 10);

            gfx.DrawString("Informações Gerais", fonteHeaderClasse, XBrushes.DarkRed, posX, posY);
            xrect.Y += espacoAposHeaderClasse;

            gfx.DrawString("Data", fonteHeaderTabela, XBrushes.Black, xrect, XStringFormats.TopLeft);
            xrect.Y += espacoAposHeaderTabela;
            xrect.Height = espacoVertElementosTabela;
            foreach (TabelaElementos.Header header in headers)
            {
                gfx.DrawString(header.Data, fonteItensTabela, XBrushes.Black, xrect, XStringFormats.TopLeft);
                xrect.Y += espacoVertElementosTabela;
            }

            xrect.Y = posY + espacoAposHeaderClasse;
            xrect.X += xrect.Width;
            gfx.DrawString("Nome", fonteHeaderTabela, XBrushes.Black, xrect, XStringFormats.TopLeft);
            xrect.Y += espacoAposHeaderTabela;
            xrect.Width = 200;
            foreach (TabelaElementos.Header header in headers)
            {
                gfx.DrawString(header.Nome, fonteItensTabela, XBrushes.Black, xrect, XStringFormats.TopLeft);
                xrect.Y += espacoVertElementosTabela;
            }

            xrect.Y = posY + espacoAposHeaderClasse;
            xrect.X += xrect.Width;
            gfx.DrawString("Patrimônio Líquido (R$)", fonteHeaderTabela, XBrushes.Black, xrect, XStringFormats.TopLeft);
            xrect.Y += espacoAposHeaderTabela;
            xrect.Width = 80;
            foreach (TabelaElementos.Header header in headers)
            {
                gfx.DrawString(header.PatLiquido, fonteItensTabela, XBrushes.Black, xrect, XStringFormats.TopLeft);
                xrect.Y += espacoVertElementosTabela;
            }

            posY = (int) xrect.Y + 20;
        }


        public static void GerarCotas(XDocument[] xmldoc, XGraphics gfx, XFont fonteHeaderClasse, XFont fonteHeaderTabela, XFont fonteItensTabela, int posX, ref int posY)
        {
            List<TabelaElementos.Cotas> cotas = WindowsFormsApplication1.ColetaDados.ListaCotas(xmldoc);

            gfx.DrawString("Posição da carteira", fonteHeaderClasse, XBrushes.DarkRed, posX, posY);
            posY += 20;
            int posY0 = posY;

            gfx.DrawString("Código ISIN do fundo", fonteHeaderTabela, XBrushes.DarkBlue, posX, posY);
            posY += 20;
            foreach (TabelaElementos.Cotas cota in cotas)
            {
                gfx.DrawString(cota.ISIN, fonteItensTabela, XBrushes.Black, posX, posY);
                posY += 20;
            }

            posY += 20;
        }
    }
}