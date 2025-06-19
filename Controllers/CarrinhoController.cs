using CodeWearApi.Data;
using CodeWearApi.DTOs.Carrinho;
using CodeWearApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CodeWearApi.Controllers
{
    [ApiController]
    [Route("carrinhos")]
    public class CarrinhoController : ControllerBase
    {
        private readonly AppDataContext _context;

        public CarrinhoController(AppDataContext context)
        {
            _context = context;
        }

        // GET /carrinhos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarrinhoModel>>> GetAll()
        {
            return await _context.Carrinhos
                .ToListAsync();
        }

        // GET /carrinhos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CarrinhoModel>> GetById(int id)
        {
            var carrinho = await _context.Carrinhos
                .FirstOrDefaultAsync(c => c.Id == id);

            if (carrinho == null)
                return NotFound();

            return Ok(carrinho);
        }

        // POST /carrinhos
        [HttpPost("{usuarioId:int}")]
        public async Task<ActionResult<CarrinhoModel>> Create([FromRoute] int usuarioId)
        {
            var usuarioExiste = await _context.Usuarios.AnyAsync(u => u.Id == usuarioId);
            if (!usuarioExiste)
                return NotFound("Usuário não encontrado.");

            var carrinho = new CarrinhoModel
            {
                UsuarioId = usuarioId,
                DataCriacao = DateTime.Now,
                Finalizado = false
            };

            _context.Carrinhos.Add(carrinho);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = carrinho.Id }, carrinho);
        }

        // PUT /carrinhos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CarrinhoAlterDto carrinhoAtualizado)
        {


            var carrinho = await _context.Carrinhos.FindAsync(id);
            if (carrinho == null)
                return NotFound();

            carrinho.DataCriacao = DateTime.Now;
            carrinho.Finalizado = carrinhoAtualizado.Finalizado;
            carrinho.UsuarioId = carrinhoAtualizado.UsuarioId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /carrinhos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var carrinho = await _context.Carrinhos.FindAsync(id);
            if (carrinho == null)
                return NotFound();

            _context.Carrinhos.Remove(carrinho);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST /carrinhos/{id}/finalizar
        [HttpPost("{id}/finalizar")]
        public async Task<IActionResult> FinalizarCarrinho(int id)
        {
            var carrinho = await _context.Carrinhos.FindAsync(id);
            if (carrinho == null)
                return NotFound();

            carrinho.Finalizado = true;
            await _context.SaveChangesAsync();

            return Ok(carrinho);
        }

        // GET /carrinhos/usuario/{userId}?finalizado=true
        [HttpGet("usuario/{userId}")]
        public async Task<ActionResult<IEnumerable<CarrinhoModel>>> GetCarrinhosPorUsuario(
            int userId, [FromQuery] bool finalizado)
        {
            var usuarioExiste = await _context.Usuarios.AnyAsync(u => u.Id == userId);
            if (!usuarioExiste)
                return NotFound();

            var carrinhos = await _context.Carrinhos
                .Where(c => c.UsuarioId == userId && c.Finalizado == finalizado)
                .ToListAsync();

            if (carrinhos.IsNullOrEmpty()) return Ok("Usuario não possui carrinhos cadastrados e/ou com essas caracteristicas");

            return Ok(carrinhos);
        }
    }
}
