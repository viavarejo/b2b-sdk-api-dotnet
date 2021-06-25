using Microsoft.VisualStudio.TestTools.UnitTesting;
using SdkApiLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SdkApiB2bTest
{
    [TestClass]
    public class CampanhaApiTest
    {
        private readonly CampanhaApi api = new();

        [TestMethod]
        public async Task TestGetCampanhaSucess()
        {
            var dto = await api.GetCampanhasAsync("2019-08-04", "2100-08-04");
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine($"Response:{JsonSerializer.Serialize(dto, options)}");
            Assert.IsNotNull(dto);
            Assert.AreEqual("57.822.975/0001-12", dto.Data[0].CnpjContrato);
        }

        [TestMethod]
        public async Task TestGetCampanhaFail()
        {
            var dto = await api.GetCampanhasAsync("2019-08-04", null);
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine($"Response:{JsonSerializer.Serialize(dto, options)}");
            Assert.IsNotNull(dto);
            Assert.AreEqual("400", dto.Error.Code);
            Assert.AreEqual("Request inválido\r\nA dataFim é um parâmetro obrigatório.", dto.Error.Message);
        }

        [TestMethod]
        public async Task TestGetFormasPagamentoSucess()
        {
            var dto = await api.GetOpcoesPagamentoAsync("5940", "57.822.975/0001-12");
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine($"Response:{JsonSerializer.Serialize(dto, options)}");
            Assert.IsNotNull(dto);
            Assert.AreEqual(1, dto.Data[0].IdFormaPagamento);
            Assert.AreEqual("Cartão de Crédito Visa ", dto.Data[0].Nome);
        }

        [TestMethod]
        public async Task TestGetFormasPagamentoFail()
        {
            var dto = await api.GetOpcoesPagamentoAsync("590", "57.822.975/0001-12");
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine($"Response:{JsonSerializer.Serialize(dto, options)}");
            Assert.IsNotNull(dto);
            Assert.IsTrue(!dto.Data.Any());
            Assert.IsTrue(dto.Error.Code == null);

        }


    }
}
