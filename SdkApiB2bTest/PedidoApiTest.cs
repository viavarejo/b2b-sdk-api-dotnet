using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SdkApiB2bLibrary.api;
using SdkApiB2bLibrary.api.client;
using SdkApiB2bLibrary.api.model.request;
using SdkApiB2bLibrary.api.model.response;
using SdkApiB2bLibrary.model.request;
using SdkApiB2bLibrary.model.response;
using SdkApiB2bTest.model;
using SdkApiLibraries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SdkApiB2bTest
{
    /// <summary>
    /// Classe de testes para as URI's dos Pedidos do B2B.</br>
    /// É importante que os metodos sejam executados na ordem estabelecida, pois</br>
    /// alguns metodos de testes possuem dependencia dos resultados dos anteriores.
    /// <summary>

    [TestClass]
    public class PedidoApiTest
    {
        /** Instancia do client API. */
        private PedidoApi pedidoApi;

        /** Host do servico do Extra. */
        //private const string HOST_EXTRA = "http://api-integracao-extra.hlg-b2b.net";

        /** Host do servico das Casas Bahia. */
        // private const String HOST_CASAS_BAHIA = "";

        /** Host do servico do Ponto Frio. */
        // private const String HOST_PONTO = "";

        /** CEP padrao dos testes */
        private const string CEP = "01525000";

        /** Id Lojista padrao dos testes. */
        private const int ID_LOJISTA = 15;

        /** CPF FICTICIO PARA TESTES */
        private const string CPF_DESTINATARIO = "435.375.660-50";

        /** CNPJ padrao dos testes. */
        private const string CNPJ = "57.822.975/0001-12";

        /** Id Campanha padrao dos testes. */
        private const int ID_CAMPANHA = 5940;

        /** Atributo do Id Sku para criacao do primeiro Pedido. */
        private const int ID_SKU_CRIACAO_PEDIDO = 8935731;

        /** Atributo do Id Sku para criacao do segundo Pedido com cartao de credito. */
        private const int ID_SKU_CRIACAO_PEDIDO_COM_CARTAO = 9342200;

        /** Tipo de Forma de pagamento cartão Visa. */
        //private static final int CARTAO_VISA = 2;

        /** Tipo de Forma de pagamento cartão Master. */
        private const int CARTAO_MASTER = 3;

        /** Numero de cartao de credito Master mascarado. */
        private const string NUMERO_CARTAO_MASTER_MASCARADO = "515590XXXXXX0001";

        /** Numero de cartao de credito Master ficticio. */
        private const string NUMERO_CARTAO_MASTER = "5155901222280001";

        /** Codigo verificador do cartao de credito Master ficticio. */
        private const string CODIGO_VERIFICADOR = "1234";

        /** Ano de validade do cartao de credito Master ficticio. */
        private const string ANO_VALIDADE = "2045";

        /** Mes de validade cartao de credito Master ficticio. */
        private const string MES_VALIDADE = "12";

        /**
         * Atributo global utilizado para guardar o primeiro pedido criado para ser
         * utilizado nos demais testes.
         */
        private static DadosPedidoHelper pedidoHelper;

        /**
         * Atributo global utilizado para guardar o segundo pedido criado com Cartao
         * Credito para ser utilizado nos demais testes.
         */
        private static DadosPedidoHelper pedidoHelperComCartao;

        /**
         * Chave pública 2048 bits utilizada para criptografia dos dados do cartão.</br>
         * Pode ser obtida pelo URI Rest abaixo.
         * 
         * http://api-integracao-casasbahia.hlg-b2b.net/swagger/ui/index#!/Seguranca/Seguranca_ObterChave
         * 
         */
        private const string CHAVE_PUBLICA_DEFAULT = "MIIENTCCAx2gAwIBAgIJAJ5ApEGl2oaIMA0GCSqGSIb3DQEBBQUAMIGwMQswCQYDVQQGEwJCUjELMAkGA1UECAwCU1AxFDASBgNVBAcMC1NBTyBDQUVUQU5PMRMwEQYDVQQKDApWSUEgVkFSRUpPMSAwHgYDVQQLDBdTRUdVUkFOQ0EgREEgSU5GT1JNQUNBTzEOMAwGA1UEAwwFUFJPWFkxNzA1BgkqhkiG9w0BCQEWKHRpLnNlZ3VyYW5jYS5pbmZvcm1hY2FvQHZpYXZhcmVqby5jb20uYnIwHhcNMTgwODE2MTIzNjQ2WhcNMjEwODE1MTIzNjQ2WjCBsDELMAkGA1UEBhMCQlIxCzAJBgNVBAgMAlNQMRQwEgYDVQQHDAtTQU8gQ0FFVEFOTzETMBEGA1UECgwKVklBIFZBUkVKTzEgMB4GA1UECwwXU0VHVVJBTkNBIERBIElORk9STUFDQU8xDjAMBgNVBAMMBVBST1hZMTcwNQYJKoZIhvcNAQkBFih0aS5zZWd1cmFuY2EuaW5mb3JtYWNhb0B2aWF2YXJlam8uY29tLmJyMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAqObNb7KAP09WsV9h76Dw3tj2qa3l97K+slfzLkOBvi0xjacuKCnvsMSGEBosvWY/qNmSLE1YaoyFt7ZaeOiALKh2AFckJRM+/zvQzqi6cPnW0cGsEE/9WO48Fgh894pKjHpukATFb9tBYGTBEW46AH2WiAR735KEnDfFAHG//pkLKriPWEZBr9tf4gdNvyJ/ybs5JrBRU1RKE9MM7qnMkCouKTPwY/lS/2Xb1IYkyZulCf3Uyl7zpB6hQUhprS1R5meRocpGgHJCFfiWD/uXa5nREuGuQxcImwzvf+enwT6CooRoM2rN6IQWSY+uQ64dhSt4FMajZFmHVpLfUIOjEwIDAQABo1AwTjAdBgNVHQ4EFgQUZ22K62aMm/lI5LfblgINPvz8ae8wHwYDVR0jBBgwFoAUZ22K62aMm/lI5LfblgINPvz8ae8wDAYDVR0TBAUwAwEB/zANBgkqhkiG9w0BAQUFAAOCAQEAj23IDXLPkQpFDbgAtgKuO9N66o61edbJ1+BMjdSsfO0vMVpmBDlKdinxlh509/qJm/WLYswKkKOi7VHojBSV5HyrO5YGCSJFvVGJqF4JUxy7GrWTHqgwcylmX5B5lNd5aMIxwG6AF4o2cp6IPe+Uwaroa8kLTrtM0eRgAInHbQA7MXbvOZY+pzE4s6jFbA1O321zVg4C4Y3C4e30yf9YJNK5XjUP26duvwGqQrZg49ZU3W/t6GYY1kQhSeBG0FPg2GOIHX03WPZpaJ7i1uCv6Ial07pxDxqcT8oCJalY9tW9sv7zBJRaJgTIf5oz5jElb9kWd2D6XwaGB5PJfD6CTQ==";

        /** Atributo auxiliar para os testes de criacao de pedido. */
        private DadosCartaoHelper dadosCartaoHelper;

        [TestInitialize]
        public void Init()
        {
            //Obtem a chave public de um servico
            Task<string> publicKey = GetChaveAsync();
            pedidoApi = new PedidoApi();

            dadosCartaoHelper = new DadosCartaoHelper(new Encryptor(publicKey.Result), "Jose da Silva", NUMERO_CARTAO_MASTER,
               CODIGO_VERIFICADOR,
                ANO_VALIDADE,
                MES_VALIDADE);
        }

        [TestMethod]
        public async Task A_TestPostCalcularCarrinhoParaCriacaoPedido()
        {
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

            CalculoCarrinho calculoCarrinho;

            calculoCarrinho = await pedidoApi.PostCalcularCarrinho(pedidoCarrinho);

            Console.WriteLine($"Response: {Json(calculoCarrinho)}");
            Assert.IsTrue(calculoCarrinho.Data.ValorFrete > 0.0);
            Assert.IsTrue(calculoCarrinho.Data.ValorTotaldoPedido > 0.0);
            Assert.IsTrue(calculoCarrinho.Data.Produtos[0].ValorTotalFrete > 0.0);

            // preparacao do objeto que sera utilizado nos demais testes
            pedidoHelper = PreparePedido(calculoCarrinho);
        }

        [TestMethod]
        public async Task B_TestPostCalcularCarrinhoParaCriacaoPedidoComCartao()
        {
            Produtos produto = new();
            produto.Codigo = ID_SKU_CRIACAO_PEDIDO_COM_CARTAO;
            produto.Quantidade = 1;
            produto.IdLojista = ID_LOJISTA;

            PedidoCarrinho pedidoCarrinho = new();

            pedidoCarrinho.IdCampanha = ID_CAMPANHA;
            pedidoCarrinho.Cnpj = CNPJ;
            pedidoCarrinho.Cep = CEP;
            pedidoCarrinho.Produtos = new List<Produtos>
                        {
                            produto
                        };

            CalculoCarrinho calculoCarrinho;

            calculoCarrinho = await pedidoApi.PostCalcularCarrinho(pedidoCarrinho);

            Console.WriteLine($"Response: {Json(calculoCarrinho)}");
            Assert.IsTrue(calculoCarrinho.Data.ValorFrete > 0.0);
            Assert.IsTrue(calculoCarrinho.Data.ValorTotaldoPedido > 0.0);
            Assert.IsTrue(calculoCarrinho.Data.Produtos[0].ValorTotalFrete > 0.0);

            // preparacao do objeto que sera utilizado nos demais testes
            pedidoHelperComCartao = PreparePedido(calculoCarrinho);
        }


        [TestMethod]
        public async Task C_TestPostCriarPedido()
        {
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

            Console.WriteLine($"Response: {Json(criacaoPedidoDTO)}");

            double expectedValue = pedidoHelper.GetTotalPedido();
            Assert.AreEqual(expectedValue, criacaoPedidoDTO.Data.ValorTotalPedido, 0.01);

            // complementa dados do Pedido para utilizar nos outros metodos
            pedidoHelper.IdPedido = criacaoPedidoDTO.Data.CodigoPedido;
            pedidoHelper.IdPedidoParceiro = criacaoPedidoDTO.Data.PedidoParceiro;
        }

        [TestMethod]
        public async Task D_TestPostCriarPedidoPagCartao()
        {
            // Produto
            PedidoProdutoDto produto = new();
            produto.IdLojista = ID_LOJISTA;
            produto.Codigo = pedidoHelperComCartao.IdSku;
            produto.Quantidade = 1;
            produto.PrecoVenda = pedidoHelperComCartao.PrecoVenda;
            List<PedidoProdutoDto> produtos = new();
            produtos.Add(produto);

            // endereco Entrega
            EnderecoEntregaDto enderecoEntrega = new();
            enderecoEntrega.Cep = CEP;
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

            // pedido
            CriacaoPedidoRequest pedido = new();
            pedido.Campanha = ID_CAMPANHA;
            pedido.Cnpj = CNPJ;
            pedido.PedidoParceiro = GeraPedidoParceiroId();
            pedido.ValorFrete = pedidoHelperComCartao.ValorFrete;
            pedido.AguardarConfirmacao = true;
            pedido.OptantePeloSimples = true;
            pedido.PossuiPagtoComplementar = true;

            // pagamentos complementares
            PagamentoComplementarDto pagamentoComplementarDto = new();
            pagamentoComplementarDto.IdFormaPagamento = CARTAO_MASTER; // 2-Visa 3-Master

            // dados cartao credito
            CartaoCreditoDadosDto cartaoCreditoDadosDto = new();
            cartaoCreditoDadosDto.Nome = dadosCartaoHelper.GetEncryptedName();
            cartaoCreditoDadosDto.Numero = dadosCartaoHelper.GetEncryptedNumber();
            cartaoCreditoDadosDto.CodigoVerificador = dadosCartaoHelper.GetEncryptedVerifyCode();
            cartaoCreditoDadosDto.ValidadeAno = dadosCartaoHelper.GetEncryptedValidateYear();
            cartaoCreditoDadosDto.ValidadeMes = dadosCartaoHelper.GetEncryptedValidateMonth();
            cartaoCreditoDadosDto.QuantidadeParcelas = 1;

            pagamentoComplementarDto.DadosCartaoCredito = cartaoCreditoDadosDto;

            // dados Cartao Credito Validacao
            CartaoCreditoDadosValidacaoDto cartaoCreditoDadosValidacaoDto = new();
            cartaoCreditoDadosValidacaoDto.Nome = dadosCartaoHelper.Nome;
            cartaoCreditoDadosValidacaoDto.NumeroMascarado = NUMERO_CARTAO_MASTER_MASCARADO;

            cartaoCreditoDadosValidacaoDto.QtCaracteresCodigoVerificador = "4";
            cartaoCreditoDadosValidacaoDto.ValidadeAno = dadosCartaoHelper.AnoValidade;
            cartaoCreditoDadosValidacaoDto.ValidadeMes = dadosCartaoHelper.MesValidade;

            pagamentoComplementarDto.DadosCartaoCreditoValidacao = cartaoCreditoDadosValidacaoDto;

            // pagamento complementar
            pagamentoComplementarDto.ValorComplementar = 30.0;
            pagamentoComplementarDto.ValorComplementarComJuros = 30.0;

            // dados entrega
            EntregaDadosDto dadosEntrega = new();
            dadosEntrega.ValorFrete = pedidoHelperComCartao.ValorFrete;

            // endereco cobranca
            EnderecoCobrancaDto enderecoCobranca = new();
            enderecoCobranca.Cep = "01546090";
            enderecoCobranca.Estado = "SP";
            enderecoCobranca.Logradouro = "Rua Rodrigues Bastista";
            enderecoCobranca.Cidade = "São Paulo";
            enderecoCobranca.Numero = 63;
            enderecoCobranca.Referencia = "teste";
            enderecoCobranca.Bairro = "Vila Teodoro";
            enderecoCobranca.Complemento = "teste";
            enderecoCobranca.Telefone = "22333333";
            enderecoCobranca.Telefone2 = "22333335";
            enderecoCobranca.Telefone3 = "22333336";

            pedido.Produtos = produtos;
            pedido.EnderecoEntrega = enderecoEntrega;
            pedido.Destinatario = destinatario;
            pedido.DadosEntrega = dadosEntrega;
            pedido.EnderecoCobranca = enderecoCobranca;

            List<PagamentoComplementarDto> PagamentoComplementarDtoList = new();
            PagamentoComplementarDtoList.Add(pagamentoComplementarDto);
            pedido.PagtosComplementares = PagamentoComplementarDtoList;

            pedido.ValorTotalPedido = pedidoHelperComCartao.GetTotalPedido();
            pedido.ValorTotalComplementar = 30.0;
            pedido.ValorTotalComplementarComJuros = 30.0;

            CriacaoPedidoDTO criacaoPedidoDTO;
            criacaoPedidoDTO = await pedidoApi.PostCriarPedido(pedido);

            Console.WriteLine($"Response: {Json(criacaoPedidoDTO)}");

            double valueExpected = pedidoHelperComCartao.GetTotalPedido();
            Assert.AreEqual(valueExpected, criacaoPedidoDTO.Data.ValorTotalPedido, 0);

            // complementa dados do Pedido para utilizar nos outros metodos
            pedidoHelperComCartao.IdPedido = criacaoPedidoDTO.Data.CodigoPedido;
            pedidoHelperComCartao.IdPedidoParceiro = criacaoPedidoDTO.Data.PedidoParceiro;
        }

        [TestMethod]
        public async Task E_TestPatchPedidosCancelamento()
        {
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

            Console.WriteLine($"Response: {Json(confirmacaoDto)}");

            Assert.IsTrue(confirmacaoDto.Data.PedidoCancelado);
        }

        [TestMethod]
        public async Task F_TestPatchPedidosConfirmacao()
        {
            Dictionary<String, String> variableParams = new();
            variableParams.Add("idCompra", pedidoHelperComCartao.IdPedido.ToString());

            ConfirmacaoReqDTO dto = new();
            dto.IdCampanha = ID_CAMPANHA;
            dto.IdPedidoParceiro = pedidoHelperComCartao.IdPedidoParceiro;
            dto.Confirmado = true;

            ConfirmacaoDTO confirmacaoDto = await pedidoApi.PatchPedidosCancelamentoOrConfirmacao(dto, variableParams);

            Console.WriteLine($"Response: {Json(confirmacaoDto)}");

            Assert.IsTrue(confirmacaoDto.Data.PedidoConfirmado);
        }

        [TestMethod]
        public async Task G_TestGetDadosPedidoParceiro()
        {
            Dictionary<String, String> pathParams = new();
            pathParams.Add("idCompra", pedidoHelper.IdPedido.ToString());

            Dictionary<String, String> queryParams = new();
            queryParams.Add("request.idCompra", pedidoHelper.IdPedido.ToString());
            queryParams.Add("request.cnpj", CNPJ);
            queryParams.Add("request.idCampanha", ID_CAMPANHA.ToString());
            queryParams.Add("request.idPedidoParceiro", pedidoHelper.IdPedidoParceiro.ToString());

            PedidoParceiroData pedido;

            pedido = await pedidoApi.GetDadosPedidoParceiro(pathParams, queryParams);

            Console.WriteLine($"Response: {Json(pedido)}");

            Assert.AreEqual(pedidoHelper.IdPedido, pedido.Data.Pedido.CodigoPedido);
        }


        [TestMethod]
        public async Task H_TestGetNotaFiscalPedidoPdf()
        {
            Dictionary<String, String> pathParams = new();
            pathParams.Add("idCompra", "247473612");
            pathParams.Add("idCompraEntrega", "91712686");
            pathParams.Add("formato", "PDF");

            String nomeArquivo = await pedidoApi.GetNotaFiscalPedido(pathParams);
            Assert.IsNotNull(nomeArquivo);
            Assert.IsTrue(File.Exists(nomeArquivo));
        }

        [TestMethod]
        [ExpectedException(typeof(ApiException))]
        public async Task I_TestGetDadosPedidoParceiroFail()
        {
            Dictionary<String, String> queryParams = new();
            queryParams.Add("request.idCompra", pedidoHelper.IdPedido.ToString());
            queryParams.Add("request.cnpj", CNPJ);
            queryParams.Add("request.idCampanha", ID_CAMPANHA.ToString());
            queryParams.Add("request.idPedidoParceiro", pedidoHelper.IdPedidoParceiro.ToString());

            await pedidoApi.GetDadosPedidoParceiro(null, queryParams);

        }

        [TestMethod]
        [ExpectedException(typeof(ApiException))]
        public async Task J_TestPostCalcularCarrinhoParaCriacaoPedidoFail()
        {
            await pedidoApi.PostCalcularCarrinho(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ApiException))]
        public async Task K_TestPatchPedidosCancelamentoFail()
        {
            ConfirmacaoReqDTO dto = new();
            dto.IdCampanha = ID_CAMPANHA;
            dto.IdPedidoParceiro = pedidoHelper.IdPedidoParceiro;
            dto.Cancelado = true;
            dto.Confirmado = false;
            dto.IdPedidoMktplc = "1-01";
            dto.MotivoCancelamento = "teste";
            dto.Parceiro = "BANCO INTER";

            await pedidoApi.PatchPedidosCancelamentoOrConfirmacao(dto, null);

        }

        [TestMethod]
        [ExpectedException(typeof(ApiException))]
        public async Task L_TestPatchPedidosConfirmacaoFail()
        {
            Dictionary<String, String> variableParams = new();
            variableParams.Add("idCompra", pedidoHelperComCartao.IdPedido.ToString());

            await pedidoApi.PatchPedidosCancelamentoOrConfirmacao(null, variableParams);
        }

        [TestMethod]
        [ExpectedException(typeof(ApiException))]
        public async Task M_TestGetNotaFiscalPedidoPdfFail()
        {
            await pedidoApi.GetNotaFiscalPedido(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ApiException))]
        public async Task N_TestPostCriarPedidoFail()
        {
            await pedidoApi.PostCriarPedido(null);
        }

        public async Task O_TestGetNotaFiscalPedidoXml()
        {
            Dictionary<String, String> pathParams = new();
            pathParams.Add("idCompra", "247473612");
            pathParams.Add("idCompraEntrega", "91712686");
            pathParams.Add("formato", "xml");

            String nomeArquivo = await pedidoApi.GetNotaFiscalPedido(pathParams);
            Assert.IsNotNull(nomeArquivo);
            Assert.IsTrue(File.Exists(nomeArquivo));
        }

        private static String Json(Object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented);
        }

        private static DadosPedidoHelper PreparePedido(CalculoCarrinho calculoCarrinho)
        {
            DadosPedidoHelper pedidoHelper = new()
            {
                IdSku = calculoCarrinho.Data.Produtos[0].IdSku,
                PrecoVenda = calculoCarrinho.Data.Produtos[0].ValorUnitario,
                ValorFrete = calculoCarrinho.Data.Produtos[0].ValorTotalFrete
            };
            return pedidoHelper;
        }

        private static int GeraPedidoParceiroId()
        {
            return new Random().Next(1, int.MaxValue);
        }

        private static async Task<string> GetChaveAsync()
        {
            SegurancaApi api = new();

            ChaveDTO dto = await api.GetChave();
            if (dto.Data != null)
            {
                return dto.Data.ChavePublica;
            }

            return CHAVE_PUBLICA_DEFAULT;

        }

    }
}
