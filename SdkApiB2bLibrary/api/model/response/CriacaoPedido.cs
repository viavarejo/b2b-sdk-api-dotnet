using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.response
{
    public class CriacaoPedido
    {
        public double ValorProduto { get; set; }

        public double ValorTotalPedido { get; set; }

        public int CodigoPedido { get; set; }

        public int PedidoParceiro { get; set; }

        public string IdPedidoMktplc { get; set; }

        public List<Produto> Produtos { get; set; }

        public string ParametrosExtras { get; set; }

        public bool AguardandoConfirmacao { get; set; }

        public DadosEntrega DadosEntrega { get; set; }

        public DadosPagamentoComplementar DadosPagamentoComplementar { get; set; }
    }
}
