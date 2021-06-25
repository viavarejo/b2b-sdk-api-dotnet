using System;
using System.Collections.Generic;
using System.Text;

namespace SdkApiB2bLibrary.model.response
{
    public class ProdutoDadosEntrega
    {
        public int IdEntregaTipo { get; set; }
        public Boolean Disponibilidade { get; set; }
        public List<Frete> Fretes { get; set; }
    }
}
