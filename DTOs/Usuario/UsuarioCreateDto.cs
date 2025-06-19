using System.ComponentModel.DataAnnotations;

namespace CodeWearApi.DTOs.Usuario
{
    public class UsuarioCreateDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string NomeCompleto { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public int RoleId { get; set; }
    }

}
