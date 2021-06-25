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
    public class FormaPagamentoApiTest
    {
        private readonly FormaPagamentoApi api = new();

        [TestMethod]
        public async Task TestGetOpcoesParcelamentoSucess()
        {
            var dto = await api.GetOpcoesParcelamentoAsync("1", "5940", "57.822.975/0001-12", "1000");
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine($"Response:{JsonSerializer.Serialize(dto, options)}");
            Assert.IsNotNull(dto);
            Assert.AreEqual(1000.0D, dto.Data[0].ValorParcela);
        }

        [TestMethod]
        public async Task TestGetOpcoesParcelamentoFail()
        {
            var dto = await api.GetOpcoesParcelamentoAsync("8", "5940", "57.822.975/0001-12", "1000");
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine($"Response:{JsonSerializer.Serialize(dto, options)}");
            Assert.IsNotNull(dto);
            Assert.IsTrue(!dto.Data.Any());
            Assert.IsTrue(dto.Error.Code == null);
        }


    }
}
