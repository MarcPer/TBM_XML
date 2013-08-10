using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//meus
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Procura e extrai conteúdo de etiquetas específicas de arquivos XML.
    /// </summary>
    public static class ColetaDados
    {
        // Variáveis
        private static int iarq = 0;

        public static List<Ativos.TitPublico> TitulosPublicos(XDocument[] xmldoc)
        {
            List<Ativos.TitPublico> TitulosPublicos = new List<Ativos.TitPublico>();

            foreach (XDocument doc in xmldoc)
            {
                var titPublicoQuery =
                    from titpublico in doc.Root.Descendants("titpublico")
                    orderby titpublico.Element("isin").Value
                    select titpublico;
                foreach (var xel in titPublicoQuery)
                {
                    Ativos.TitPublico tp = new Ativos.TitPublico();
                    if (xel.Element("codativo").Value != null) { tp.CodAtivo = xel.Element("codativo").Value; }
                    if (xel.Element("isin").Value != null) { tp.ISIN = xel.Element("isin").Value; }
                    if (xel.Element("indexador").Value != null) { tp.Indexador = xel.Element("indexador").Value; }
                    if (xel.Element("coupom").Value != null) { tp.Cupom = xel.Element("coupom").Value; }
                    if (xel.Element("dtemissao").Value != null) { tp.DataEmissao = xel.Element("dtemissao").Value; }
                    if (xel.Element("dtoperacao").Value != null) { tp.DataCompra = xel.Element("dtoperacao").Value; }
                    if (xel.Element("dtvencimento").Value != null) { tp.DataVencimento = xel.Element("dtvencimento").Value; }
                    if (xel.Element("qtdisponivel").Value != null) { tp.Disponivel = xel.Element("qtdisponivel").Value; }
                    if (xel.Element("qtgarantia").Value != null) { tp.Garantia = xel.Element("qtgarantia").Value; }
                    if (xel.Element("puposicao").Value != null) { tp.PU = xel.Element("puposicao").Value; }
                    if (xel.Element("tributos").Value != null) { tp.Impostos = xel.Element("tributos").Value; }

                    if (tp.Disponivel != null && tp.PU != null)
                    {
                        Double disp = Double.Parse(tp.Disponivel, CultureInfo.InvariantCulture);
                        Double pu = Double.Parse(tp.PU, CultureInfo.InvariantCulture);
                        tp.ValorBruto = (pu * disp).ToString("#.#0", CultureInfo.InvariantCulture);
                    }

                    if (tp.Disponivel != null && tp.PU != null && tp.Impostos != null)
                    {
                        Double disp = Double.Parse(tp.Disponivel, CultureInfo.InvariantCulture);
                        Double pu = Double.Parse(tp.PU, CultureInfo.InvariantCulture);
                        Double imp = Double.Parse(tp.Impostos, CultureInfo.InvariantCulture);
                        tp.ValorLiquido = (pu * disp - imp).ToString("#.#0", CultureInfo.InvariantCulture);
                    }

                    TitulosPublicos.Add(tp);
                }
            }
            return TitulosPublicos;
        }

    }
}
