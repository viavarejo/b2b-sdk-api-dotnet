using System;
using System.Collections.Generic;
using System.Text;

namespace SdkApiB2bLibrary.model.response
{
    public class OpcoesParcelamentoDTO
    {
        public List<OpcaoParcelamento> Data { get; set; }
        public Error Error { get; set; }
    }
}
