using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.model.response
{
    public class ProdutoDTO
    {
        public ListaProdutos Data { get; set; }
        public Error Error { get; set; }
    }

    
}
