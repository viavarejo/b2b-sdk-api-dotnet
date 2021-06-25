using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.request
{
    public class DestinatarioDto
    {
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Email { get; set; }
        public int Administrador { get; set; }
    }
}
