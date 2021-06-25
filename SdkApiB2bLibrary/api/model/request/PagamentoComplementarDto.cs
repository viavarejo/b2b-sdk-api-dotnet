using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.request
{
    public class PagamentoComplementarDto
    {
        public int IdFormaPagamento { get; set; }
        public CartaoCreditoDadosDto DadosCartaoCredito { get; set; }
        public CartaoCreditoDadosValidacaoDto DadosCartaoCreditoValidacao { get; set; }
        public double ValorComplementarComJuros { get; set; }
        public double ValorComplementar { get; set; }
    }
}
