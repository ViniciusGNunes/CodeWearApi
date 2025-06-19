namespace CodeWearApi.DTOs.Usuario
{
    public class UsuarioReadDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string NomeCompleto { get; set; }
        public int RoleId { get; set; }
        public string RoleNome { get; set; }
    }

}
