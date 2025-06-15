namespace CodeWearApi.Models
{
    public class ComentarioModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Texto { get; set; } = null!;

    }
}
