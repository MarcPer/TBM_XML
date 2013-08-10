﻿using System;

namespace Ativos
{

    /// <summary>
    /// Classe Títulos Públicos
    /// </summary>
    public class TitPublico
    {
        public string CodAtivo { get; set; }
        public string ISIN { get; set; }
        public string Indexador { get; set; }
        public string Cupom { get; set; }
        public string DataEmissao { get; set; }
        public string DataCompra { get; set; }
        public string DataVencimento { get; set; }
        public string Disponivel { get; set; }
        public string Garantia { get; set; }
        public string PU { get; set; }
        public string ValorBruto { get; set; }
        public string Impostos { get; set; }
        public string ValorLiquido { get; set; }
    }
}