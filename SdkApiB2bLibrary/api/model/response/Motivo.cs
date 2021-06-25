using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SdkApiB2bLibrary.api.model.response
{
    public class Motivo
    {		
	public string Categoria { get; set; }		
	public string Assunto { get; set; }

        private string motivo;

        public string GetMotivo()
        {
            return motivo;
        }

        public void SetMotivo(string value)
        {
            motivo = value;
        }

        public string Observacao { get; set; }
	}
}
