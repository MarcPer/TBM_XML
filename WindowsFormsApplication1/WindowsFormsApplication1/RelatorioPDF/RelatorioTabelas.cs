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
    public static class RelatorioTabelas
    {
        public static void GerarHeader(XDocument[] xmldoc, XGraphics gfx, XFont fonteHeaderClasse, XFont fonteHeaderTabela, XFont fonteItensTabela, int posX, ref int posY)
        {
            List<TabelaElementos.Header> headers = ColetaDados.ListaHeaders(xmldoc);
                        
            gfx.DrawString("Informações Gerais", fonteHeaderClasse, XBrushes.DarkRed, posX, posY);
            posY += 20;
            int posY0 = posY;

            gfx.DrawString("Data", fonteHeaderTabela, XBrushes.Black, posX, posY);
            posY += 20;
            foreach (TabelaElementos.Header header in headers)
            {
                gfx.DrawString(header.Data, fonteItensTabela, XBrushes.Black, posX, posY);
                posY += 20;
            }

            posY = posY0;
            posX += 50;
            gfx.DrawString("Nome", fonteHeaderTabela, XBrushes.Black, posX, posY);
            posY += 20;
            foreach (TabelaElementos.Header header in headers)
            {
                gfx.DrawString(header.Nome, fonteItensTabela, XBrushes.Black, posX, posY);
                posY += 20;
            }

            posY = posY0;
            posX += 200;
            gfx.DrawString("Patrimônio Líquido", fonteHeaderTabela, XBrushes.Black, posX, posY);
            posY += 20;
            foreach (TabelaElementos.Header header in headers)
            {
                gfx.DrawString(header.PatLiquido, fonteItensTabela, XBrushes.Black, posX, posY);
                posY += 20;
            }

            posY += 20;
        }


        public static void GerarCotas(XDocument[] xmldoc, XGraphics gfx, XFont fonteHeaderClasse, XFont fonteHeaderTabela, XFont fonteItensTabela, int posX, ref int posY)
        {
            List<TabelaElementos.Cotas> cotas = WindowsFormsApplication1.ColetaDados.ListaCotas(xmldoc);

            gfx.DrawString("ISIN", fonteHeaderTabela, XBrushes.DarkBlue, posX, posY);
            posY += 20;
            foreach (TabelaElementos.Cotas cota in cotas)
            {
                gfx.DrawString(cota.ISIN, fonteItensTabela, XBrushes.Black, posX, posY);
                posY += 20;
            }
        }
    }
}