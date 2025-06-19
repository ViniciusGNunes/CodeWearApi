namespace CodeWearApi.Models
{
    public class ComentarioModel
    {
        public int Id { get; set; }
        public string Texto { get; set; }

        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
    }
}
