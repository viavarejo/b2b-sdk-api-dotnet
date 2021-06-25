using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.response
{
    public class ProdutoEntrega
    {
        
        public int Codigo{ get; set; }     
        public string Nome{ get; set; }        
        public int Quantidade{ get; set; }
        public double Valor{ get; set; }
        public double Frete{ get; set; }
        public double ValorAdicional{ get; set; }
        public double ValorTotal{ get; set; }
        public double IdLojista{ get; set; } // deveria ser int, verificar com o time de B2B
    }
}
