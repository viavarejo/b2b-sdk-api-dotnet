# sdk-csharp
Projet

# SDK dotnet para API B2B

Provê os componentes para o uso da API B2B, disponibilizado pela VIA, facilitando a integração com as documentações relacionadas:

| Swagger |
| ------ | 
| http://api-integracao-pontofrio.hlg-b2b.net/swagger/ui/index#/ |
| http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#/| 
| http://api-integracao-extra.hlg-b2b.net/swagger/ui/index#/ |

## Configurando o SDK
 Dentro do namespace [SdkApiB2bLibrary.api.utils] se encontra a classe reponsavel pelas requisições, a qual deve ser configurada duas propriedades: 
 - BASE_PATH  (end-point utilizado).
 - token (token de acesso).
 
## APIs Disponíveis

O namespace [SdkApiLibrary.api] contem as classes:
* CampanhaApi.cs
* FormaPagamentoApi.cs
* PedidoApi.cs
* ProdutoApi.cs
* SegurancaApi.cs

Estas compõe a camada de acesso para os serviços disponibilizados pelo B2B, alguns exemplos de como utiliza-lá estão disponíveis nos testes unitarios

A seguir, são apresentadas as APIs e exemplos com as as principais operações do B2B.

- ## Campanha
    Api Utilizada para operações de campanha
    ## Obtém todas as campanhas vinculadas ao parceiro: 
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#/Campanha/Campanha_ListarCampanhaAsync 
    - http://api-integracao-pontofrio.hlg-b2b.net/swagger/ui/index#/Campanha/Campanha_ListarCampanhaAsync 
    - http://api-integracao-extra.hlg-b2b.net/swagger/ui/index#/Campanha/Campanha_ListarCampanhaAsync 

    ```csharp
	    CampanhaApi api = new();
	    var dto = await api.GetCampanhasAsync("2019-08-04", "2100-08-04");
    ```
    
	***
    
    ## Obtém todas as opções de pagamento para uma determinada campanha: 
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Campanha/Campanha_ListarOpcoesParcelamentoAsync 
    - http://api-integracao-pontofrio.hlg-b2b.net/swagger/ui/index#/Campanha/Campanha_ListarOpcoesParcelamentoAsync 
    - http://api-integracao-extra.hlg-b2b.net/swagger/ui/index#/Campanha/Campanha_ListarOpcoesParcelamentoAsync 
    
    ```csharp
    CampanhaApi api = new();
    var dto = await api.GetOpcoesPagamentoAsync("5940", "57.822.975/0001-12");
    ```
    
***

- ## Pedido
    Api utilizada para operações de pedidos
     ## Calcular carrinho:
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Pedido/Pedido_CalcularCarrinhoAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Pedido/Pedido_CalcularCarrinhoAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Pedido/Pedido_CalcularCarrinhoAsync
	
        ```csharp
        PedidoApi pedidoApi = new();
		
        Produtos produto = new()
		{
			Codigo = ID_SKU_CRIACAO_PEDIDO,
			Quantidade = 1,
			IdLojista = ID_LOJISTA
		};

		PedidoCarrinho pedidoCarrinho = new()
		{
			IdCampanha = ID_CAMPANHA,
			Cnpj = CNPJ,
			Cep = CEP,
			Produtos = new List<Produtos>()
		};
		pedidoCarrinho.Produtos.Add(produto);
		
		CalculoCarrinho calculoCarrinho = await pedidoApi.PostCalcularCarrinho(pedidoCarrinho);
        ```
		
     ## Obter os dados de pedido do parceiro:
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Pedido/Pedido_ObterPedidoAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Pedido/Pedido_ObterPedidoAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Pedido/Pedido_ObterPedidoAsync
	
        ```csharp
		PedidoApi pedidoApi = new();
		Dictionary<String, String> pathParams = new();
		pathParams.Add("idCompra", pedidoHelper.IdPedido.ToString());

		Dictionary<String, String> queryParams = new();
		queryParams.Add("request.idCompra", pedidoHelper.IdPedido.ToString());
		queryParams.Add("request.cnpj", CNPJ);
		queryParams.Add("request.idCampanha", ID_CAMPANHA.ToString());
		queryParams.Add("request.idPedidoParceiro", pedidoHelper.IdPedidoParceiro.ToString());
		
		PedidoParceiroData pedido = await pedidoApi.GetDadosPedidoParceiro(pathParams, queryParams);
        ```
		
     ## Confirma ou cancela pedidos pendentes de confirmação:
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Pedido/Pedido_ConfirmarPedidoAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Pedido/Pedido_ConfirmarPedidoAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Pedido/Pedido_ConfirmarPedidoAsync
	
        ```csharp
		PedidoApi pedidoApi = new();
		Dictionary<String, String> variableParams = new();
		variableParams.Add("idCompra", pedidoHelper.IdPedido.ToString());

		ConfirmacaoReqDTO dto = new();
		dto.IdCampanha = ID_CAMPANHA;
		dto.IdPedidoParceiro = pedidoHelper.IdPedidoParceiro;
		dto.Cancelado = true;
		dto.Confirmado = false;
		dto.IdPedidoMktplc = "1-01";
		dto.MotivoCancelamento = "teste";
		dto.Parceiro = "BANCO INTER";

		ConfirmacaoDTO confirmacaoDto = await pedidoApi.PatchPedidosCancelamentoOrConfirmacao(dto, variableParams);
        ```
		
     ## Obter nota fiscal do pedido:
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Pedido/Pedido_ObterNFeAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Pedido/Pedido_ObterNFeAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Pedido/Pedido_ObterNFeAsync
	
        ```csharp
		PedidoApi pedidoApi = new PedidoApi();
		Map<String, String> pathParams = new HashMap<>();
		pathParams.put("idCompra", "247473612");
		pathParams.put("idCompraEntrega", "91712686");
		pathParams.put("formato", "PDF");

		String response = pedidoApi.getNotaFiscalPedido(pathParams);
        ```
		
     ## Criar pedido:
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Pedido/Pedido_ObterNFeAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Pedido/Pedido_ObterNFeAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Pedido/Pedido_ObterNFeAsync
	
        ```csharp
		PedidoApi pedidoApi = new();
		// Produto
		PedidoProdutoDto produto = new();
		produto.IdLojista = ID_LOJISTA;
		produto.Codigo = pedidoHelper.IdSku;
		produto.Quantidade = 1;
		produto.Premio = 0;
		produto.PrecoVenda = pedidoHelper.PrecoVenda;
		List<PedidoProdutoDto> produtos = new();
		produtos.Add(produto);

		// endereco Entrega
		EnderecoEntregaDto enderecoEntrega = new();
		enderecoEntrega.Cep = "01525-000";
		enderecoEntrega.Estado = "SP";
		enderecoEntrega.Logradouro = "rua da se";
		enderecoEntrega.Cidade = "São Paulo";
		enderecoEntrega.Numero = 63;
		enderecoEntrega.Referencia = "teste";
		enderecoEntrega.Bairro = "bairro se";
		enderecoEntrega.Complemento = "teste";
		enderecoEntrega.Telefone = "22333333";
		enderecoEntrega.Telefone2 = "22333335";
		enderecoEntrega.Telefone3 = "22333336";

		// destinatario
		DestinatarioDto destinatario = new();
		destinatario.Nome = "teste";
		destinatario.CpfCnpj = CPF_DESTINATARIO;
		destinatario.Email = "teste@teste.com";
		destinatario.Administrador = 1;

		// dados entrega
		EntregaDadosDto dadosEntrega = new();
		dadosEntrega.ValorFrete = pedidoHelper.ValorFrete;

		// pedido
		CriacaoPedidoRequest pedido = new();
		pedido.Produtos = produtos;
		pedido.EnderecoEntrega = enderecoEntrega;
		pedido.Destinatario = destinatario;
		pedido.DadosEntrega = dadosEntrega;
		pedido.Campanha = ID_CAMPANHA;
		pedido.Cnpj = CNPJ;
		pedido.PedidoParceiro = GeraPedidoParceiroId();
		pedido.ValorFrete = pedidoHelper.ValorFrete;
		pedido.AguardarConfirmacao = true;
		pedido.OptantePeloSimples = true;

		CriacaoPedidoDTO criacaoPedidoDTO = await pedidoApi.PostCriarPedido(pedido);
		
        ```
		
		
    
- ## Forma de Pagamento
    Api Utilizada para operações de forma de pagamento
     ## Obter opções de parcelamento:
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/FormaPagamento/FormaPagamento_ListarOpcoesParcelamentoAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/FormaPagamento/FormaPagamento_ListarOpcoesParcelamentoAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/FormaPagamento/FormaPagamento_ListarOpcoesParcelamentoAsync
        ```csharp
        FormaPagamentoApi api = new();
        var dto = await api.GetOpcoesParcelamentoAsync("1", "5940", "57.822.975/0001-12", "1000");
        ```
- ## Produto
    Api Utilizada para operações de produto
     ## Obter dados do produto:
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Produto/Produto_ObterProdutoAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Produto/Produto_ObterProdutoAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Produto/Produto_ObterProdutoAsync
        ```csharp
        ProdutoApi api = new();
        var dto = await api.GetDadosProduto("15", "5880205");
        ```
     ## Obter lista de dados dos produtos:
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Produto/Produto_ListarProdutoAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Produto/Produto_ListarProdutoAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Produto/Produto_ListarProdutoAsync
        ```csharp
        ProdutoApi api = new();
        var dto = await api.GetListaProdutos("15",new List<String> {"5880205","5880206"});
        ```
     ## Obter dados do produto por Campanha:
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Produto/Produto_ObterProdutoPorCampanhaAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Produto/Produto_ObterProdutoPorCampanhaAsync
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Produto/Produto_ObterProdutoPorCampanhaAsync
        ```csharp
        ProdutoApi api = new();
        var dto = await api.GetDadosProdutoCampanha("5940", "5880205", "57.822.975/0001-12", "15");
        ```
- ## Seguranca
    Api Utilizada para operações de seguranca
     ## Obter chave pública 2048 bits utilizada para criptografia dos dados do cartão:
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Seguranca/Seguranca_ObterChave
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Seguranca/Seguranca_ObterChave
    - http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Seguranca/Seguranca_ObterChave
        ```csharp
        SegurancaApi api = new();
        var dto = await api.GetChave();
        ```
       
        
        
