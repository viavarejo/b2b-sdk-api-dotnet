using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.response
{
    public class Produto
    {
        public int IdLojista { get; set; }
        public int Codigo { get; set; }
        public int Quantidade { get; set; }
        public int Premio { get; set; }
        public double PrecoVenda { get; set; }
    }
}
