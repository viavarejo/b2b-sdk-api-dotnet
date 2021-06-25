using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.model.response
{
    public class Chave
    {
        [JsonProperty("chavePublica")]
        public string ChavePublica { get; set; }

        [JsonProperty("dataCadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonProperty("dataExpiracao")]
        public DateTime DataExpiracao { get; set; }

        [JsonProperty("dataAtualizacao")]
        public DateTime DataAtualizacao { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }
}
