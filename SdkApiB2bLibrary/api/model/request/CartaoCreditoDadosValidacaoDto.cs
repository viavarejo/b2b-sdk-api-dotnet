using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.request
{
    public class CartaoCreditoDadosValidacaoDto
    {
        public string Nome { get; set; }
        public string NumeroMascarado { get; set; }
        public string QtCaracteresCodigoVerificador { get; set; }
        public string ValidadeAno { get; set; }
        public string ValidadeMes { get; set; }
    }
}
