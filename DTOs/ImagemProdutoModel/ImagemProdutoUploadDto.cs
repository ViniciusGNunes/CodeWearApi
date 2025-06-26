namespace CodeWearApi.DTOs.ImagemProdutoModel
{
    public class ImagemProdutoUploadDto
    {
        public IFormFile Imagem { get; set; }
        public string Descricao { get; set; }
        public int ProdutoId { get; set; }
    }

}
