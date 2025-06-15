using CodeWearApi.Data;
using CodeWearApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeWearApi.Controllers
{
    [ApiController]
    [Route("carrinho")]
    public class CarrinhoController : ControllerBase
    {
        private readonly AppDataContext _context;

        public CarrinhoController(AppDataContext context)
        {
            _context = context;
        }

        // GET carrinho/{usuarioId}
        [HttpGet("carrinho/{usuarioId:int}")]
        public IActionResult GetCarrinho([FromRoute] int usuarioId)
        {
            var carrinho = _context.Carrinhos
                .Include(c => c.ItensCarrinho)
                .SingleOrDefault(c => c.UsuarioId == usuarioId);

            if (carrinho == null)
                return NotFound();

            return Ok(carrinho);
        }

        // POST carrinho
        [HttpPost("carrinho")]
        public IActionResult CriarCarrinho([FromBody] CarrinhoModel model)
        {
            var jaExiste = _context.Carrinhos.Any(c => c.UsuarioId == model.UsuarioId);
            if (jaExiste)
                return Conflict("Carrinho já existe para este usuário.");

            _context.Carrinhos.Add(model);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCarrinho), new { usuarioId = model.UsuarioId }, model);
        }

        // DELETE carrinho/{usuarioId}
        [HttpDelete("carrinho/{usuarioId:int}")]
        public IActionResult DeletarCarrinho([FromRoute] int usuarioId)
        {
            var carrinho = _context.Carrinhos
                .Include(c => c.ItensCarrinho)
                .SingleOrDefault(c => c.UsuarioId == usuarioId);

            if (carrinho == null)
                return NotFound();

            _context.ItemsCarrinho.RemoveRange(carrinho.ItensCarrinho);
            _context.Carrinhos.Remove(carrinho);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
