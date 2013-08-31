using System;

namespace TabelaElementos
{
    /// <summary>
    /// Classe Acoes
    /// </summary>
    public class Acoes
    {
        /// <summary>
        /// CodAtivo: Código do ativo - tag codativo
        /// </summary>
        public string CodAtivo { get; set; }
        public string ClasseOperacao { get; set; }
        public string DataEmissao { get; set; }
        public string Disponivel { get; set; }
        public string Garantia { get; set; }
        public string PU { get; set; }
        public string ValorBruto { get; set; }
        public string Impostos { get; set; }
        public string ValorLiquido { get; set; }
    }
}