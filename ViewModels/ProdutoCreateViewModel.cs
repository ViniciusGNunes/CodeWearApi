namespace CodeWearApi.ViewModels
{
    public class ProdutoCreateViewModel
    {

        public string Nome { get; set; } = null!;
        public string TipoProduto { get; set; } = null!;
        public decimal Preco { get; set; }
        public string Tamanho { get; set; } = null!;

    }
}
