

using System.Collections.Generic;

namespace SdkApiB2bLibrary.api.model.response
{
    public class Entrega
    {
		
	public double CodigoEntrega  { get; set; } 		
	public string PrevisaoEntrega  { get; set; } 		
	public string DataEntrega { get; set; }		
	public string DataPrevisao { get; set; }		
	public string DataEmissaoNotaFiscal { get; set; }		
	public int IdNotaFiscal { get; set; }		
	public string ChaveAcesso { get; set; }		
	public List<TrackingEntrega> TrackingEntrega  { get; set; }
	public List<ProdutoEntrega> ProdutoEntrega { get; set; }
	public string RastreioEntrega { get; set; }		
	public string NomeTransportadora { get; set; }	
	public string LinkNotaFiscalPDF { get; set; }		
	public string ListNotaFiscalXML { get; set; }		
	public bool Estorno { get; set; }		
	public string Origem { get; set; }		
	public Motivo Motivo { get; set; }}
}
