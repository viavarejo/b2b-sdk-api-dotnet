using SdkApiB2bLibrary.model.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.response
{
    public class CriacaoPedidoDTO
    {
         public CriacaoPedido Data { get; set; }

        public Error Error { get; set; }
    }
}
