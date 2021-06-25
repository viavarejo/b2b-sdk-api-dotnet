using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.response
{
    public class ProdutoCarrinho
    {
        public int IdSku { get; set; }
        public string PrevisaoEntrega { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal { get; set; }
        public double ValorTotalFrete { get; set; }
        public double ValorTotalImpostos { get; set; }
        public bool Erro { get; set; }
        public string MensagemDeErro { get; set; }
        public string CodigoDoErro { get; set; }
    }
}
