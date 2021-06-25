using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.model.response
{
    public class ChaveDTO
    {

        [JsonProperty("data")]
        public Chave Data { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}
