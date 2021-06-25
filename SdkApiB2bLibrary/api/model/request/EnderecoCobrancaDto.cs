using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.request
{
    public class EnderecoCobrancaDto
    {
		public string Cep { get; set; }
		public string Estado { get; set; }
		public string Logradouro { get; set; }
		public string Cidade { get; set; }
		public int Numero { get; set; }
		public string Referencia { get; set; }
		public string Bairro { get; set; }
		public string Complemento { get; set; }
		public string Telefone { get; set; }
		public string Telefone2 { get; set; }
		public string Telefone3 { get; set; }
	}
}
