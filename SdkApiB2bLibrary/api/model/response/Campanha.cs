using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.model.response
{
    public class Campanha
    {
        [JsonProperty("idCampanha")]
        public int IdCampanha { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("dataInicio")]
        public DateTime DataInicio { get; set; }

        [JsonProperty("dataFim")]
        public DateTime DataFim { get; set; }

        [JsonProperty("idTipoCampanha")]
        public int IdTipoCampanha { get; set; }

        [JsonProperty("tipoCampanha")]
        public string TipoCampanha { get; set; }

        [JsonProperty("cnpjContrato")]
        public string CnpjContrato { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("entregaTipos")]
        public List<EntregaTipos> EntregaTipos { get; set; }
    }
}
