using System.Data;

namespace CodeWearApi.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }

        public int RoleId { get; set; }


    }
}

