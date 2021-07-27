using SdkApiB2bLibrary.model.response;
using SdkApiB2bLibrary.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiLibrary
{
    public class ProdutoApi
    {
        private readonly RequestUtil<String, ProdutoDTO> requestProduto = new();
        private readonly RequestUtil<String, ProdutosDTO> requestProdutos = new();

        public async Task<ProdutoDTO> GetDadosProduto(String idLogista, String idSKu)
        {
            ProdutoDTO dto = await requestProduto.GetAsync("/lojistas/" + idLogista + "/produtos/" + idSKu, null);
            return dto;
        }

        public async Task<ProdutosDTO> GetListaProdutos(String idLogista, List<String> idSKu)
        {
            var queryParams = ArrayQueryParamBuilder(idSKu, nameof(idSKu));
            ProdutosDTO dto = await requestProdutos.GetAsync("/lojistas/" + idLogista + "/produtos" + queryParams, null);
            return dto;
        }

        public async Task<ProdutoDTO> GetDadosProdutoCampanha(String idCampanha, String idSKu, String cnpj, String idLojista)
        {
            Dictionary<String, String> queryParams = new()
            {
                { "idLojista", idLojista },
                { "cnpj", cnpj }
            };
            ProdutoDTO dto = await requestProduto.GetAsync("/campanhas/" + idCampanha + "/produtos/" + idSKu, queryParams);
            return dto;
        }


        private static String ArrayQueryParamBuilder(List<String> idSKu, String paramName)
        {

            StringBuilder sb = new();
            foreach (var param in idSKu)
            {
                if(param != null)
                {
                    if (sb.Length == 0)
                    {
                        sb.Append('?');
                    }
                    else
                    {
                        sb.Append('&');
                    }
                    sb.Append(paramName).Append('=').Append(param);
                }
            }
            return sb.ToString();
        }


    }
}
