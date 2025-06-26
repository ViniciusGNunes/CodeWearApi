namespace CodeWearApi.Models
{
    public class ImagemProdutoModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
        public string? TipoMime { get; set; }
        public int ProdutoId { get; set; }
    }

}
