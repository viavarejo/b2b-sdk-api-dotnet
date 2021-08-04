using SdkApiB2bLibrary.api.client;
using SdkApiB2bLibrary.api.model.request;
using SdkApiB2bLibrary.api.model.response;
using SdkApiB2bLibrary.model.request;
using SdkApiB2bLibrary.model.response;
using SdkApiB2bLibrary.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api
{
    public class PedidoApi
    {
        public RequestUtil<PedidoCarrinho, CalculoCarrinho> RequestUtilPedidoCarrinho { get; }

        public RequestUtil<string, PedidoParceiroData> RequestUtilPedidoParceiro { get; }

        public RequestUtil<ConfirmacaoReqDTO, ConfirmacaoDTO> RequestUtilConfirmacaoReqDTO { get; }

        public RequestUtil<String, String> RequestUtilNotaFiscalPedido { get; }

        public RequestUtil<CriacaoPedidoRequest, CriacaoPedidoDTO> RequestUtilCriacaoPedido { get; }

        public PedidoApi()
        {
            RequestUtilPedidoCarrinho = new RequestUtil<PedidoCarrinho, CalculoCarrinho>();
            RequestUtilPedidoParceiro = new RequestUtil<string, PedidoParceiroData>();
            RequestUtilConfirmacaoReqDTO = new RequestUtil<ConfirmacaoReqDTO, ConfirmacaoDTO>();
            RequestUtilNotaFiscalPedido = new RequestUtil<String, String>();
            RequestUtilCriacaoPedido = new RequestUtil<CriacaoPedidoRequest, CriacaoPedidoDTO>();
        }

        public async Task<CalculoCarrinho> PostCalcularCarrinho(PedidoCarrinho pedidosCarrinho)
        {
            // verify the required parameter
            if (pedidosCarrinho == null)
            {
                throw new ApiException(400,
                        "Missing the required parameter 'pedidosCarrinho' when calling postPedidosCarrinho");
            }

            // create path and map variables
            String path = "/pedidos/carrinho";

            return await RequestUtilPedidoCarrinho.DoPostAsync(path, pedidosCarrinho);
        }

        public async Task<PedidoParceiroData> GetDadosPedidoParceiro(Dictionary<String, String> pathParams, Dictionary<String, String> queryParams)

        {
            // verify the required parameter
            if (pathParams == null)
            {
                throw new ApiException(400, "Missing the required parameter 'pathParams'");
            }

            // create path and map variables
            String path = string.Format("/pedidos/{0}", pathParams["idCompra"]);

            return await RequestUtilPedidoParceiro.GetAsync(path, queryParams);
        }

        public async Task<ConfirmacaoDTO> PatchPedidosCancelamentoOrConfirmacao(ConfirmacaoReqDTO confirmacaoPedido,
                Dictionary<String, String> variableParams)

        {
            // verify the required parameter
            if (variableParams == null)
            {
                throw new ApiException(400, "Missing the required parameter 'variableParams'");
            }

            // verify the required parameter
            if (confirmacaoPedido == null)
            {
                throw new ApiException(400,
                        "Missing the required parameter 'confirmacaoPedido' when calling pathPedidosCancelamentoOrConfirmacao");
            }

            // create path and map variables
            String path = String.Format("/pedidos/{0}", variableParams["idCompra"]);

            return await RequestUtilConfirmacaoReqDTO.DoPatchPostAsync(path, confirmacaoPedido);
        }

        public async Task<String> GetNotaFiscalPedido(Dictionary<String, String> pathParams)
        {
            // verify the required parameter
            if (pathParams == null)
            {
                throw new ApiException(400, "Missing the required parameter 'pathParams'");
            }
            // create path and map variables
            String path = String.Format("/pedidos/{0}/entregas/{1}/nfe/{2}", pathParams["idCompra"],
                        pathParams["idCompraEntrega"], pathParams["formato"]);

            HttpResponseMessage response = await RequestUtilNotaFiscalPedido.GetDownLoadAsync(path);
            byte[] content = response.Content.ReadAsByteArrayAsync().Result;

            String outFile = "";
            if (content.Length > 0)
            {
                DateTime now = DateTime.Now;
                if (string.Equals(pathParams["formato"].ToLower(), "pdf", StringComparison.OrdinalIgnoreCase))
                {
                    outFile = "NF_" + now.ToFileTime() + ".PDF";
                }
                else
                {
                    outFile = "NF_" + now.ToFileTime() + ".XML";
                }
                File.WriteAllBytes(outFile, content);
            }
            return outFile;
        }

        public async Task<CriacaoPedidoDTO> PostCriarPedido(CriacaoPedidoRequest pedido)
        {
            // verify the required parameter
            if (pedido == null)
            {
                throw new ApiException(400,
                        "Missing the required parameter 'pedido'");
            }

            // create path and map variables
            String path = "/pedidos";

            return await RequestUtilCriacaoPedido.DoPostAsync(path, pedido);
        }

    }
}
