using System.ComponentModel.DataAnnotations;

namespace CodeWearApi.DTOs.Usuario
{
    public class UsuarioUpdateDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string NomeCompleto { get; set; }

        public string Senha { get; set; } 

        [Required]
        public int RoleId { get; set; }
    }

}
