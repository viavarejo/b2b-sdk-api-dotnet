using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.response
{
    public class DadosEntrega
    {
        public string PrevisaoDeEntrega { get; set; }
        public double ValorFrete { get; set; }
        public int IdEntregaTipo { get; set; }
        public int IdEnderecoLojaFisica { get; set; }
        public int? IdUnidadeNegocio { get; set; }
    }
}
