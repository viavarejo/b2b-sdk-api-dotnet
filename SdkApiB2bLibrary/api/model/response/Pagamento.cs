using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.model.response
{
    public class Pagamento
    {
     
    public string CodigoDoErro { get; set; }
     
    public double ValorComplementar { get; set; }
    
    public int QuantidadeParcelas { get; set; }
   
    public double ValorParcela { get; set; }
     
    public int IdFormaPagamento { get; set; }
     
    public bool Erro { get; set; }
     
    public string MensagemDeErro { get; set; }
    
    public string Url { get; set; }
    }
}
