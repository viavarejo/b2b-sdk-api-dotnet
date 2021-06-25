namespace SdkApiB2bLibrary.api.model.request
{
    public class CartaoCreditoDadosDto
    {
		public string Nome { get; set; }
		public string Numero { get; set; }
		public string CodigoVerificador { get; set; }
		public string ValidadeAno { get; set; }
		public string ValidadeMes { get; set; }
		public string ValidadeAnoMes { get; set; }
		public int QuantidadeParcelas { get; set; }
	}
}