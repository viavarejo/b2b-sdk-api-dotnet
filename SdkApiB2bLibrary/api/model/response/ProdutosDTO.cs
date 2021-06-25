using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.model.response
{
    public class ProdutosDTO
    {
        public List<ListaProdutos> Data { get; set; }
        public Error Error { get; set; }
    }

    
}
