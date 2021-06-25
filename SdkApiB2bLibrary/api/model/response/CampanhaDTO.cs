using Newtonsoft.Json;
using System.Collections.Generic;

namespace SdkApiB2bLibrary.model.response
{
    public class CampanhaDTO
    {

        [JsonProperty("data")]
        public List<Campanha> Data { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}
