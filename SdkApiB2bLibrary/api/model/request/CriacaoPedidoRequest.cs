using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.request
{
    public class CriacaoPedidoRequest
    {
		public List<PedidoProdutoDto> Produtos{ get; set; }
		public EnderecoEntregaDto EnderecoEntrega{ get; set; }
		public DestinatarioDto Destinatario{ get; set; }
		public int Campanha{ get; set; }
		public string Cnpj{ get; set; }
		public int PedidoParceiro{ get; set; }
		public string IdPedidoMktplc{ get; set; }
		public string SenhaAtendimento{ get; set; }
		public string Apolice{ get; set; }
		public int? Administrador { get; set; }
		public string ParametrosExtras{ get; set; }
		public double ValorFrete{ get; set; }
		public bool AguardarConfirmacao{ get; set; }
		public bool OptantePeloSimples{ get; set; }
		public bool PossuiPagtoComplementar{ get; set; }
		public List<PagamentoComplementarDto> PagtosComplementares{ get; set; }
		public EntregaDadosDto DadosEntrega{ get; set; }
		public EnderecoCobrancaDto EnderecoCobranca{ get; set; }
		public double ValorTotalPedido{ get; set; }
		public double ValorTotalComplementar{ get; set; }
		public double ValorTotalComplementarComJuros{ get; set; }
	}
}
