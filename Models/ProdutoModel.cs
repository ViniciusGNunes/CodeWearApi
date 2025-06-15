namespace CodeWearApi.Models
{
    public class ProdutoModel
    {

            public int Id { get; set; }
            public string Nome { get; set; } = null!;
            public string TipoProduto { get; set; } = null!;
            public decimal Preco { get; set; }
            public string Tamanho { get; set; } = null!;

            public ICollection<ItemCarrinhoModel>? ItensCarrinho { get; set; }


    }
}
