using SdkApiB2bLibrary.api.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bTest.model
{
    /// <summary>
    /// Classe auxiliar para dados do cartao credito.
    /// <summary>
    class DadosCartaoHelper
    {
        public Encryptor Encryptor { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string CodigoVerificador { get; set; }
        public string AnoValidade { get; set; }
        public string MesValidade { get; set; }

        public DadosCartaoHelper(Encryptor encryptor, String nome, String numero, String codigoVerificador,
               String anoValidade, String mesValidade)
        {
            this.Encryptor = encryptor;
            this.Nome = nome;
            this.Numero = numero;
            this.CodigoVerificador = codigoVerificador;
            this.AnoValidade = anoValidade;
            this.MesValidade = mesValidade;
        }

        public String GetEncryptedName()
        {
            return Encryptor.Encript(Nome);
        }

        public String GetEncryptedNumber()
        {
            return Encryptor.Encript(Numero);
        }

        public String GetEncryptedVerifyCode()
        {
            return Encryptor.Encript(CodigoVerificador);
        }

        public String GetEncryptedValidateYear()
        {
            return Encryptor.Encript(AnoValidade);
        }

        public String GetEncryptedValidateMonth()
        {
            return Encryptor.Encript(MesValidade);
        }
    }
}
