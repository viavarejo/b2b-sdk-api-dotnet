using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bTest.model
{
    /// <summary>
    /// Classe auxiliar para dados do pedido.
    /// <summary>
    class DadosPedidoHelper
    {
        public int IdPedido { get; set; }
        public int IdPedidoParceiro { get; set; }
        public int IdSku { get; set; }
        public double ValorFrete { get; set; }
        public double PrecoVenda { get; set; }

        public double GetTotalPedido()
        {
            return ValorFrete + PrecoVenda;
        }
    }
}
