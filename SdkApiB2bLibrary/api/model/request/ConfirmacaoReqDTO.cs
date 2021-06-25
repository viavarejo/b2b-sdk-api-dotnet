using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.request
{
    public class ConfirmacaoReqDTO
    {
        public int IdCampanha { get; set; }

        public int IdPedidoParceiro { get; set; }

        public bool Confirmado { get; set; }

        public string IdPedidoMktplc { get; set; }

        public bool? Cancelado { get; set; }

        public string MotivoCancelamento { get; set; }

        public string Parceiro { get; set; }
    }
}
