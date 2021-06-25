using SdkApiB2bLibrary.model.response;
using SdkApiB2bLibrary.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiLibrary
{
    public class CampanhaApi
    {
        private readonly RequestUtil<String, CampanhaDTO> requestCampanha = new();
        private readonly RequestUtil<String, FormasPagamentoDTO> requestFormasPagamento = new();

        public async Task<CampanhaDTO> GetCampanhasAsync(String dtInicio, String dtFim)
        {
            Dictionary<String, String> queryParams = new()
            {
                { "dataInicio", dtInicio },
                { "dataFim", dtFim }
            };
            CampanhaDTO response = await requestCampanha.DoGetAsync("/campanhas", queryParams);
            return response;
        }


        public async Task<FormasPagamentoDTO> GetOpcoesPagamentoAsync(String idCampanha, String cnpj)
        {
            Dictionary<String, String> queryParams = new()
            {
                { "cnpj", cnpj }
            };

            FormasPagamentoDTO response = await requestFormasPagamento.DoGetAsync("/campanhas/" + idCampanha + "/formas-pagamento/opcoes-parcelamento", queryParams);
            return response;
        }


    }
}
