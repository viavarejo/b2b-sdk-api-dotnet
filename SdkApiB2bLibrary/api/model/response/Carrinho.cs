using SdkApiB2bLibrary.api.model.response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SdkApiB2bLibrary.model.response
{
    public class Carrinho
    {
        public double ValorFrete { get; set; }
        public double ValorImpostos { get; set; }
        public double ValorTotaldosProdutos { get; set; }
        public double ValorTotaldoPedido { get; set; }
        public List<ProdutoCarrinho> Produtos { get; set; }
    }
}
