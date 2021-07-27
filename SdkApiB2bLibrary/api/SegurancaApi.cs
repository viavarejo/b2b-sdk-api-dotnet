using SdkApiB2bLibrary.model.response;
using SdkApiB2bLibrary.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiLibraries
{
    public class SegurancaApi
    {
        private readonly RequestUtil<String, ChaveDTO> requestProduto = new();

        public async Task<ChaveDTO> GetChave()
        { 
            return await requestProduto.GetAsync("/seguranca/chaves", null);
        }
    }
}
