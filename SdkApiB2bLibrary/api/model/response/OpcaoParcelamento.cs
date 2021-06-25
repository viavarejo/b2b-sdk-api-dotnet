using System;
using System.Collections.Generic;
using System.Text;

namespace SdkApiB2bLibrary.model.response
{
    public class OpcaoParcelamento
    {
        public int IdFormaPagamento { get; set; }
        public int QuantidadeParcelas { get; set; }
        public double TaxaJurosAoMes { get; set; }
        public double ValorParcela { get; set; }
        public double ValorTotal { get; set; }
    }
}
