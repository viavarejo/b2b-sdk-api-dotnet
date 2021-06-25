using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.client
{
	public class Encryptor
	{
		public string ChavePublica { get; set; }

		public Encryptor(String chavePublica)
		{
			this.ChavePublica = chavePublica;
		}
		public string Encript(String texto)
		{
			//var objChave = new System.Security.Cryptography.X509Certificates.X509Certificate2();
			//objChave.Import(Encoding.UTF8.GetBytes(ChavePublica));
			//var rsa = (RSACryptoServiceProvider)objChave.PublicKey.Key;

			RSACryptoServiceProvider rsa = new();
			RSAParameters RSAKeyInfo = rsa.ExportParameters(false);			
			RSAKeyInfo.Modulus = Encoding.UTF8.GetBytes(ChavePublica);		
			rsa.ImportParameters(RSAKeyInfo);

			var textoEncriptado = rsa.Encrypt(Encoding.UTF8.GetBytes(texto), false);
			string outputData = Convert.ToBase64String(textoEncriptado);
			return outputData;
		}
	}
}
