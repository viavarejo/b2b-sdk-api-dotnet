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
    public class ProdutoApiTest
    {
        readonly ProdutoApi api = new();

        [TestMethod]
        public async Task TestGetDadosProdutosSucess()
        {
            var dto = await api.GetDadosProduto("15", "5880205");
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine($"Response:{JsonSerializer.Serialize(dto, options)}");
            Assert.IsNotNull(dto);
            Assert.AreEqual("Bola de Natal Santini Christmas 10cm Transparente - 3 Unidades.", dto.Data.Nome);
            Assert.AreEqual("http://imagens.extra.com.br/Control/ArquivoExibir.aspx?IdArquivo=253172122", dto.Data.Imagem);
            Assert.AreEqual(2868, dto.Data.Categoria);
          // Assert.AreEqual(29.9, dto.Data.Valor);
        }

        [TestMethod]
        public async Task TestGetListaDadosProdutosSucess()
        {
            var dto = await api.GetListaProdutos("15",new List<String> {"5880205","5880206"});
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine($"Response:{JsonSerializer.Serialize(dto, options)}");
            Assert.IsNotNull(dto);
            Assert.AreEqual("Bola de Natal Santini Christmas 10cm Transparente - 3 Unidades.", dto.Data[0].Nome);
            Assert.AreEqual(dto.Data[0].Descricao, "Sua decora&amp;#231;&amp;#227;o de Natal vai ficar moderna e cheia de estilo com o Conjunto de Bolas Santini Christmas - Branco/Transparente. Elas contam com 10 cent&amp;#237;metros de di&amp;#226;metro e s&amp;#227;o feitas em material pl&amp;#225;stico resistente com detalhes em glitter branco.&amp;lt;br&amp;gt;&amp;#13;&amp;#10;Um conjunto para decorar &amp;#225;rvores de Natal, ambientes e outros arranjos. Com os produtos Santini Christmas sua decora&amp;#231;&amp;#227;o de Natal vai ganhar elogios dos convidados!");
            Assert.AreEqual(dto.Data[0].Imagem, "http://imagens.extra.com.br/Control/ArquivoExibir.aspx?IdArquivo=253172122");
            Assert.AreEqual(dto.Data[0].Categoria, 2868);
         //   Assert.AreEqual(dto.Data[0].Valor, 29.9);
        }

        [TestMethod]
        public async Task TestGetDadosProdutoCampanhaSucess()
        {
            var dto = await api.GetDadosProdutoCampanha("5940", "5880205", "57.822.975/0001-12", "15");
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine($"Response:{JsonSerializer.Serialize(dto, options)}");
            Assert.IsNotNull(dto);
            Assert.AreEqual("Bola de Natal Santini Christmas 10cm Transparente - 3 Unidades.", dto.Data.Nome);
            Assert.AreEqual(dto.Data.Imagem, "http://imagens.extra.com.br/Control/ArquivoExibir.aspx?IdArquivo=253172122");
            Assert.AreEqual(dto.Data.Categoria, 2868);
          //  Assert.AreEqual(dto.Data.Valor, 29.9);
         //   Assert.AreEqual(dto.Data.ValorDe, 29.9);
        }

        [TestMethod]
        public async Task TestGetDadosProdutosFail()
        {
            var dto = await api.GetDadosProduto("15", "595959");
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine($"Response:{JsonSerializer.Serialize(dto, options)}");
            Assert.IsNotNull(dto);
            Assert.AreEqual("Produto ou Sku 595959 não encontrado", dto.Error.Message);
            Assert.AreEqual("ProdutoNaoEncontrado", dto.Error.Code);
        }

        [TestMethod]
        public async Task TestGetListaDadosProdutosFail()
        {
            var dto = await api.GetListaProdutos("15", new List<String> { "595959" });
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine($"Response:{JsonSerializer.Serialize(dto, options)}");
            Assert.IsNotNull(dto);
            Assert.AreEqual("Nenhum SKU foi encontrado.(ErroValidacao)", dto.Error.Message);
            Assert.AreEqual("NaoEncontrado", dto.Error.Code);
        }

        //Testar para uma melhor verificação
        [TestMethod]
        public async Task TestGetDadosProdutoCampanhaFail()
        {
            var dto = await api.GetDadosProdutoCampanha("5940", "595959", "2", "2");
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine($"Response:{JsonSerializer.Serialize(dto, options)}");
            Assert.IsNotNull(dto);
            Assert.AreEqual("A campanha não pertence ao cliente informado.(ErroValidacao)", dto.Error.Message);
            Assert.AreEqual("400", dto.Error.Code);

        }
    }
}
