using System;
using System.Collections.Generic;
using System.Text;

namespace SdkApiB2bLibrary.model.response
{
    public class ListaProdutos
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public int Categoria { get; set; }

        public decimal Valor { get; set; }

        public decimal ValorDe { get; set; }

        public Boolean Disponibilidade { get; set; }

        public Boolean ForaDeLinha { get; set; }

        public int IdLojista { get; set; }

        public List<ProdutoDadosEntrega> DadosEntrega { get; set; }
    }
}
