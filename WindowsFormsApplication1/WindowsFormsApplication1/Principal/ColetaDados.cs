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

        /// <summary>
        /// Titulos Publicos
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <returns></returns>
        public static List<Ativos.TitPublico> TitulosPublicos(XDocument[] xmldoc)
        {
            List<Ativos.TitPublico> TitulosPublicos = new List<Ativos.TitPublico>();

            foreach (XDocument doc in xmldoc)
            {
                var titPublicoQuery =
                    from titpublico in doc.Root.Descendants("titpublico")
                    orderby titpublico.Element("isin").Value
                    select titpublico;

                if (titPublicoQuery != null)
                {
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
            }
            return TitulosPublicos;
        }

        public static List<Ativos.CreditoPrivado> CreditoPrivado(XDocument[] xmldoc)
        {
            List<Ativos.CreditoPrivado> CreditoPrivado = new List<Ativos.CreditoPrivado>();

            foreach (XDocument doc in xmldoc)
            {
                var credPrivadoQuery =
                    from credPrivado in doc.Root.Descendants("titprivado")
                    orderby credPrivado.Element("isin").Value
                    select credPrivado;

                if (credPrivadoQuery != null)
                {
                    foreach (var xel in credPrivadoQuery)
                    {
                        Ativos.CreditoPrivado cp = new Ativos.CreditoPrivado();
                        if (xel.Element("codativo").Value != null) { cp.CodAtivo = xel.Element("codativo").Value; }
                        if (xel.Element("isin").Value != null) { cp.ISIN = xel.Element("isin").Value; }
                        if (xel.Element("cnpjemissor").Value != null) { cp.Emissor = xel.Element("cnpjemissor").Value; }
                        if (xel.Element("indexador").Value != null) { cp.Indexador = xel.Element("indexador").Value; }
                        if (xel.Element("coupom").Value != null) { cp.Cupom = xel.Element("coupom").Value; }
                        if (xel.Element("dtemissao").Value != null) { cp.DataEmissao = xel.Element("dtemissao").Value; }
                        if (xel.Element("dtoperacao").Value != null) { cp.DataCompra = xel.Element("dtoperacao").Value; }
                        if (xel.Element("dtvencimento").Value != null) { cp.DataVencimento = xel.Element("dtvencimento").Value; }
                        if (xel.Element("qtdisponivel").Value != null) { cp.Disponivel = xel.Element("qtdisponivel").Value; }
                        if (xel.Element("qtgarantia").Value != null) { cp.Garantia = xel.Element("qtgarantia").Value; }
                        if (xel.Element("puposicao").Value != null) { cp.PU = xel.Element("puposicao").Value; }
                        if (xel.Element("tributos").Value != null) { cp.Impostos = xel.Element("tributos").Value; }

                        if (cp.Disponivel != null && cp.PU != null)
                        {
                            Double disp = Double.Parse(cp.Disponivel, CultureInfo.InvariantCulture);
                            Double pu = Double.Parse(cp.PU, CultureInfo.InvariantCulture);
                            cp.ValorBruto = (pu * disp).ToString("#.#0", CultureInfo.InvariantCulture);
                        }

                        if (cp.Disponivel != null && cp.PU != null && cp.Impostos != null)
                        {
                            Double disp = Double.Parse(cp.Disponivel, CultureInfo.InvariantCulture);
                            Double pu = Double.Parse(cp.PU, CultureInfo.InvariantCulture);
                            Double imp = Double.Parse(cp.Impostos, CultureInfo.InvariantCulture);
                            cp.ValorLiquido = (pu * disp - imp).ToString("#.#0", CultureInfo.InvariantCulture);
                        }

                        CreditoPrivado.Add(cp);
                    }
                }
            }
            return CreditoPrivado;
        }

        public static List<Ativos.Acoes> Acoes(XDocument[] xmldoc)
        {
            List<Ativos.Acoes> Acoes = new List<Ativos.Acoes>();

            foreach (XDocument doc in xmldoc)
            {
                var acoesQuery =
                    from acao in doc.Root.Descendants("acoes")
                    orderby acao.Element("isin").Value
                    select acao;

                if (acoesQuery != null)
                {
                    foreach (var xel in acoesQuery)
                    {
                        Ativos.Acoes ac = new Ativos.Acoes();
                        if (xel.Element("codativo").Value != null) { ac.CodAtivo = xel.Element("codativo").Value; }
                        if (xel.Element("indexador").Value != null) { ac.Indexador = xel.Element("indexador").Value; }
                        if (xel.Element("dtemissao").Value != null) { ac.DataEmissao = xel.Element("dtemissao").Value; }
                        if (xel.Element("qtdisponivel").Value != null) { ac.Disponivel = xel.Element("qtdisponivel").Value; }
                        if (xel.Element("qtgarantia").Value != null) { ac.Garantia = xel.Element("qtgarantia").Value; }
                        if (xel.Element("puposicao").Value != null) { ac.PU = xel.Element("puposicao").Value; }
                        if (xel.Element("tributos").Value != null) { ac.Impostos = xel.Element("tributos").Value; }

                        if (ac.Disponivel != null && ac.PU != null)
                        {
                            Double disp = Double.Parse(ac.Disponivel, CultureInfo.InvariantCulture);
                            Double pu = Double.Parse(ac.PU, CultureInfo.InvariantCulture);
                            ac.ValorBruto = (pu * disp).ToString("#.#0", CultureInfo.InvariantCulture);
                        }

                        if (ac.Disponivel != null && ac.PU != null && ac.Impostos != null)
                        {
                            Double disp = Double.Parse(ac.Disponivel, CultureInfo.InvariantCulture);
                            Double pu = Double.Parse(ac.PU, CultureInfo.InvariantCulture);
                            Double imp = Double.Parse(ac.Impostos, CultureInfo.InvariantCulture);
                            ac.ValorLiquido = (pu * disp - imp).ToString("#.#0", CultureInfo.InvariantCulture);
                        }

                        Acoes.Add(ac);
                    }
                }
            }
            return Acoes;
        }

    }
}
