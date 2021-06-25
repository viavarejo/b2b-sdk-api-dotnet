using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.model.response
{
    public class EntregaTipos
    {

        [JsonProperty("idEntregaTipo")]
        public int IdEntregaTipo { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("habilitado")]
        public bool Habilitado { get; set; }
    }
}
