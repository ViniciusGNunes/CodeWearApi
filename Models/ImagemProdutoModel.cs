namespace CodeWearApi.Models
{
    public class ImagemProdutoModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Caminho { get; set; }

        public int ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; }
    }
}
