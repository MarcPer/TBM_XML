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

        public static List<Header.Header> ListaHeaders(XDocument[] xmldoc)
        {
            List<Header.Header> ListaHeaders = new List<Header.Header>();
            int itemNum = 1;
            foreach (XDocument doc in xmldoc)
            {
                var headerQuery =
               from header in doc.Descendants("header")
               select header;

                Header.Header head = new Header.Header();
                foreach (var xel in headerQuery)
                {
                    Header.Header hd = new Header.Header();
                    hd.Item = itemNum++; 
                    if (xel.Element("dtposicao") != null) { hd.Data = xel.Element("dtposicao").Value; }
                    if (xel.Element("nome") != null) { hd.Nome = xel.Element("nome").Value; }
                    if (xel.Element("patliq") != null) { hd.PatLiquido = xel.Element("patliq").Value; }

                    ListaHeaders.Add(hd);
                }
                
            }
            return ListaHeaders;
        }

        /// <summary>
        /// Retorna lista de cotas consolidadas por ISIN
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <returns></returns>
        public static List<Cotas.Cotas> ListaCotas(XDocument[] xmldoc)
        {
            List<Cotas.Cotas> ListaCotas = new List<Cotas.Cotas>();

            /// Combina carteiras dos diferentes XMLs
            List<XElement> list = new List<XElement>();
            IEnumerable<XElement> xdocCombinado = list;
            foreach (XDocument doc in xmldoc)
            {
                xdocCombinado = xdocCombinado.Concat(doc.Root.Descendants("carteira")).Concat(doc.Root.Descendants("fundo"));
            }

            var cotasQuery =
                from cota in xdocCombinado.Descendants("cotas")
                group cota by cota.Element("isin").Value;

            if (cotasQuery != null)
            {
                foreach (var grupoCotas in cotasQuery)
                {
                    Cotas.Cotas ct = new Cotas.Cotas();
                    if (grupoCotas.Key != null) { ct.ISIN = (string)grupoCotas.Key; }

                    // Consolidar: somar valores de um mesmo ISIN
                    Double somaQtCotas = 0;
                    Double somaVlrCotas = 0;
                    Double somaVlrBruto = 0;
                    Double somaImpostos = 0;
                    Double somaVlrLiquido = 0;
                    foreach (var cota in grupoCotas)
                    {
                        Double disp = (cota.Element("qtdisponivel") != null ?
                            Double.Parse(cota.Element("qtdisponivel").Value, CultureInfo.InvariantCulture) : 0.0);
                        Double valor = (cota.Element("puposicao") != null ?
                            Double.Parse(cota.Element("puposicao").Value, CultureInfo.InvariantCulture) : 0.0);
                        Double imposto = (cota.Element("tributos") != null ?
                            Double.Parse(cota.Element("tributos").Value, CultureInfo.InvariantCulture) : 0.0);
                        somaQtCotas += disp;
                        somaVlrCotas += valor;
                        somaVlrBruto += disp * valor;
                        somaImpostos += imposto;
                        somaVlrLiquido += somaVlrBruto - imposto;
                    }
                    ct.QtCotas = somaQtCotas.ToString("0.#0", CultureInfo.InvariantCulture);
                    ct.PU = somaVlrCotas.ToString("0.#0", CultureInfo.InvariantCulture);
                    ct.ValorBruto = somaVlrBruto.ToString("0.#0", CultureInfo.InvariantCulture);
                    ct.Impostos = somaImpostos.ToString("0.#0", CultureInfo.InvariantCulture);
                    ct.ValorLiquido = somaVlrLiquido.ToString("0.#0", CultureInfo.InvariantCulture);

                    ListaCotas.Add(ct);
                }
            }

            return ListaCotas;
        }

        /// <summary>
        /// Retorna lista de titulos Publicos
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <returns></returns>
        public static List<Ativos.TitPublico> TitulosPublicos(XDocument[] xmldoc)
        {
            List<Ativos.TitPublico> TitulosPublicos = new List<Ativos.TitPublico>();

            /// Combina carteiras dos diferentes XMLs
            List<XElement> list = new List<XElement>();
            IEnumerable<XElement> xdocCombinado = list;
            foreach (XDocument doc in xmldoc)
            {
                xdocCombinado = xdocCombinado.Concat(doc.Root.Descendants("carteira")).Concat(doc.Root.Descendants("fundo"));
            }

            var titPublicoQuery =
                from titpublico in xdocCombinado.Descendants("titpublico")
                orderby titpublico.Element("isin").Value
                select titpublico;

            if (titPublicoQuery != null)
            {
                foreach (var xel in titPublicoQuery)
                {
                    Ativos.TitPublico tp = new Ativos.TitPublico();
                    if (xel.Element("codativo") != null) { tp.CodAtivo = xel.Element("codativo").Value; }
                    if (xel.Element("isin") != null) { tp.ISIN = xel.Element("isin").Value; }
                    if (xel.Element("indexador") != null) { tp.Indexador = xel.Element("indexador").Value; }
                    if (xel.Element("coupom") != null) { tp.Cupom = xel.Element("coupom").Value; }
                    if (xel.Element("dtemissao") != null) { tp.DataEmissao = xel.Element("dtemissao").Value; }
                    if (xel.Element("dtoperacao") != null) { tp.DataCompra = xel.Element("dtoperacao").Value; }
                    if (xel.Element("dtvencimento") != null) { tp.DataVencimento = xel.Element("dtvencimento").Value; }
                    if (xel.Element("qtdisponivel") != null) { tp.Disponivel = xel.Element("qtdisponivel").Value; }
                    if (xel.Element("qtgarantia") != null) { tp.Garantia = xel.Element("qtgarantia").Value; }
                    if (xel.Element("puposicao") != null) { tp.PU = xel.Element("puposicao").Value; }
                    if (xel.Element("tributos") != null) { tp.Impostos = xel.Element("tributos").Value; }

                    if (tp.Disponivel != null && tp.PU != null)
                    {
                        Double disp = Double.Parse(tp.Disponivel, CultureInfo.InvariantCulture);
                        Double pu = Double.Parse(tp.PU, CultureInfo.InvariantCulture);
                        tp.ValorBruto = (pu * disp).ToString("0.#0", CultureInfo.InvariantCulture);
                    }

                    if (tp.Disponivel != null && tp.PU != null && tp.Impostos != null)
                    {
                        Double disp = Double.Parse(tp.Disponivel, CultureInfo.InvariantCulture);
                        Double pu = Double.Parse(tp.PU, CultureInfo.InvariantCulture);
                        Double imp = Double.Parse(tp.Impostos, CultureInfo.InvariantCulture);
                        tp.ValorLiquido = (pu * disp - imp).ToString("0.#0", CultureInfo.InvariantCulture);
                    }

                    TitulosPublicos.Add(tp);
                }
            }

            return TitulosPublicos;
        }

        /// <summary>
        /// Retorna lista de ativos privados
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <returns></returns>
        public static List<Ativos.CreditoPrivado> CreditoPrivado(XDocument[] xmldoc)
        {
            List<Ativos.CreditoPrivado> CreditoPrivado = new List<Ativos.CreditoPrivado>();

            /// Combina carteiras dos diferentes XMLs
            List<XElement> list = new List<XElement>();
            IEnumerable<XElement> xdocCombinado = list;
            foreach (XDocument doc in xmldoc)
            {
                xdocCombinado = xdocCombinado.Concat(doc.Root.Descendants("carteira")).Concat(doc.Root.Descendants("fundo"));
            }

            var credPrivadoQuery =
                from credPrivado in xdocCombinado.Descendants("titprivado")
                orderby credPrivado.Element("isin").Value
                select credPrivado;

            if (credPrivadoQuery != null)
            {
                foreach (var xel in credPrivadoQuery)
                {
                    Ativos.CreditoPrivado cp = new Ativos.CreditoPrivado();
                    if (xel.Element("codativo") != null) { cp.CodAtivo = xel.Element("codativo").Value; }
                    if (xel.Element("isin") != null) { cp.ISIN = xel.Element("isin").Value; }
                    if (xel.Element("cnpjemissor") != null) { cp.Emissor = xel.Element("cnpjemissor").Value; }
                    if (xel.Element("indexador") != null) { cp.Indexador = xel.Element("indexador").Value; }
                    if (xel.Element("coupom") != null) { cp.Cupom = xel.Element("coupom").Value; }
                    if (xel.Element("dtemissao") != null) { cp.DataEmissao = xel.Element("dtemissao").Value; }
                    if (xel.Element("dtoperacao") != null) { cp.DataCompra = xel.Element("dtoperacao").Value; }
                    if (xel.Element("dtvencimento") != null) { cp.DataVencimento = xel.Element("dtvencimento").Value; }
                    if (xel.Element("qtdisponivel") != null) { cp.Disponivel = xel.Element("qtdisponivel").Value; }
                    if (xel.Element("qtgarantia") != null) { cp.Garantia = xel.Element("qtgarantia").Value; }
                    if (xel.Element("puposicao") != null) { cp.PU = xel.Element("puposicao").Value; }
                    if (xel.Element("tributos") != null) { cp.Impostos = xel.Element("tributos").Value; }

                    if (cp.Disponivel != null && cp.PU != null)
                    {
                        Double disp = Double.Parse(cp.Disponivel, CultureInfo.InvariantCulture);
                        Double pu = Double.Parse(cp.PU, CultureInfo.InvariantCulture);
                        cp.ValorBruto = (pu * disp).ToString("0.#0", CultureInfo.InvariantCulture);
                    }

                    if (cp.Disponivel != null && cp.PU != null && cp.Impostos != null)
                    {
                        Double disp = Double.Parse(cp.Disponivel, CultureInfo.InvariantCulture);
                        Double pu = Double.Parse(cp.PU, CultureInfo.InvariantCulture);
                        Double imp = Double.Parse(cp.Impostos, CultureInfo.InvariantCulture);
                        cp.ValorLiquido = (pu * disp - imp).ToString("0.#0", CultureInfo.InvariantCulture);
                    }

                    CreditoPrivado.Add(cp);
                }
            }
            return CreditoPrivado;
        }

        /// <summary>
        /// Retorna lista de ações
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <returns></returns>
        public static List<Ativos.Acoes> Acoes(XDocument[] xmldoc)
        {
            List<Ativos.Acoes> Acoes = new List<Ativos.Acoes>();

            /// Combina carteiras dos diferentes XMLs
            List<XElement> list = new List<XElement>();
            IEnumerable<XElement> xdocCombinado = list;
            foreach (XDocument doc in xmldoc)
            {
                xdocCombinado = xdocCombinado.Concat(doc.Root.Descendants("carteira")).Concat(doc.Root.Descendants("fundo"));
            }

            var acoesQuery =
                from acao in xdocCombinado.Descendants("acoes")
                orderby acao.Element("isin").Value
                select acao;

            if (acoesQuery != null)
            {
                foreach (var xel in acoesQuery)
                {
                    Ativos.Acoes ac = new Ativos.Acoes();
                    if (xel.Element("codativo") != null) { ac.CodAtivo = xel.Element("codativo").Value; }
                    if (xel.Element("classeoperacao") != null) { ac.ClasseOperacao = xel.Element("classeoperacao").Value; }
                    if (xel.Element("dtemissao") != null) { ac.DataEmissao = xel.Element("dtemissao").Value; }
                    if (xel.Element("qtdisponivel") != null) { ac.Disponivel = xel.Element("qtdisponivel").Value; }
                    if (xel.Element("qtgarantia") != null) { ac.Garantia = xel.Element("qtgarantia").Value; }
                    if (xel.Element("puposicao") != null) { ac.PU = xel.Element("puposicao").Value; }
                    if (xel.Element("tributos") != null) { ac.Impostos = xel.Element("tributos").Value; }

                    /// Converte sigla da Classe de Operação seguindo a convenção
                    /// C: Comprado
                    /// D: Doado
                    /// T: Tomado
                    /// V: Vendido
                    switch (ac.ClasseOperacao)
                    {
                        case "C":
                            ac.ClasseOperacao = "Comprado";
                            break;
                        case "D":
                            ac.ClasseOperacao = "Doado";
                            break;
                        case "T":
                            ac.ClasseOperacao = "Tomado";
                            break;
                        case "V":
                            ac.ClasseOperacao = "Vendido";
                            break;
                    }

                    if (ac.Disponivel != null && ac.PU != null)
                    {
                        Double disp = Double.Parse(ac.Disponivel, CultureInfo.InvariantCulture);
                        Double pu = Double.Parse(ac.PU, CultureInfo.InvariantCulture);
                        ac.ValorBruto = (pu * disp).ToString("0.#0", CultureInfo.InvariantCulture);
                    }

                    if (ac.Disponivel != null && ac.PU != null && ac.Impostos != null)
                    {
                        Double disp = Double.Parse(ac.Disponivel, CultureInfo.InvariantCulture);
                        Double pu = Double.Parse(ac.PU, CultureInfo.InvariantCulture);
                        Double imp = Double.Parse(ac.Impostos, CultureInfo.InvariantCulture);
                        ac.ValorLiquido = (pu * disp - imp).ToString("0.#0", CultureInfo.InvariantCulture);
                    }

                    Acoes.Add(ac);
                }
            }
            return Acoes;
        }

        
    }
}
