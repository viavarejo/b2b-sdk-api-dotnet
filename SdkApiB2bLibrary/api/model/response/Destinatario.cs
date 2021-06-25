using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.response
{
    public class Destinatario
    {
      
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Email { get; set; }
    }
}
