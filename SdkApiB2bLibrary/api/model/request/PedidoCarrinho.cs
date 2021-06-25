using System;
using System.Collections.Generic;
using System.Text;

namespace SdkApiB2bLibrary.model.request
{
    public class PedidoCarrinho
    {
		public int IdCampanha { get; set; }

		public  string Cnpj { get; set; }

		public string Cep { get; set; }

		public List<Produtos> Produtos { get; set; }

	}
}
