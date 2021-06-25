using SdkApiB2bLibrary.api.model.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.response
{
    public class PedidoParceiroDTO
    {
        public PedidoParceiro Pedido { get; set; }
        public EnderecoCobrancaDto Endereco { get; set; }
        public Destinatario Destinatario { get; set; }
        public List<Entrega> Entregas { get; set; }
    }
}
