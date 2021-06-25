using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.request
{
    public class PedidoProdutoDto
    {
        public int IdLojista{ get; set; }
        public int Codigo{ get; set; }
        public int Quantidade{ get; set; }
        public int Premio{ get; set; }
        public double PrecoVenda{ get; set; }
    }
}
