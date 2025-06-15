namespace CodeWearApi.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string NomeCompleto { get; set; } = null!;
        public string? Password { get; set; }
        public int RoleId {  get; set; }

        public ICollection<ComentarioModel>? Comentarios { get; set; }
    }
}
