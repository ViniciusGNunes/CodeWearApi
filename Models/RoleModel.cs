namespace CodeWearApi.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<UsuarioModel> Usuarios { get; set; }
    }

}
