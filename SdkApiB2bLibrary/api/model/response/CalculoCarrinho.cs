using SdkApiB2bLibrary.model.response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SdkApiB2bLibrary.model.response
{
    public class CalculoCarrinho
    {
        public Carrinho Data { get; set; }

        public Error Error { get; set; }
    }
}
