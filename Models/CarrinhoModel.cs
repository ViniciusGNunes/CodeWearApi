namespace CodeWearApi.Models
{
    public class CarrinhoModel
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public int UsuarioId { get; set; } // apenas o ID

        public ICollection<ItemCarrinhoModel>? ItensCarrinho { get; set; }
    }

}
