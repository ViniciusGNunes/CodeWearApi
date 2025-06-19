using CodeWearApi.Data;
using CodeWearApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CodeWearApi.Controllers
{
    [ApiController]
    [Route("comentarios")]
    public class ComentarioController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ComentarioController(AppDataContext context)
        {
            _context = context;
        }

        // GET /comentarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComentarioModel>>> GetAll()
        {
            return await _context.Comentarios
                .ToListAsync();
        }

        // GET /comentarios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ComentarioModel>> GetById(int id)
        {
            var comentario = await _context.Comentarios
                .FirstOrDefaultAsync(c => c.Id == id);

            if (comentario == null)
                return NotFound();

            return Ok(comentario);
        }

        // POST /comentarios
        [HttpPost]
        public async Task<ActionResult<ComentarioModel>> Create(ComentarioModel comentario)
        {
            var usuarioExiste = await _context.Usuarios.AnyAsync(u => u.Id == comentario.UsuarioId);
            if (!usuarioExiste)
                return BadRequest("Usuário inválido.");

            if (!comentario.ProdutoId.ToString().IsNullOrEmpty())
            {
                var produtoExiste = await _context.Produtos.AnyAsync(p => p.Id == comentario.ProdutoId);
                if (!produtoExiste)
                    return BadRequest("Produto inválido.");
            }

            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = comentario.Id }, comentario);
        }

        // PUT /comentarios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]ComentarioModel atualizado)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
                return NotFound();

            comentario.Texto = atualizado.Texto;
            comentario.ProdutoId = atualizado.ProdutoId;
            comentario.UsuarioId = atualizado.UsuarioId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /comentarios/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
                return NotFound();

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // GET /comentarios/produto/{produtoId}
        [HttpGet("produto/{produtoId}")]
        public async Task<ActionResult<IEnumerable<ComentarioModel>>> GetComentariosPorProduto(int produtoId)
        {
            var produtoExiste = await _context.Produtos.AnyAsync(p => p.Id == produtoId);
            if (!produtoExiste)
                return NotFound("Produto não encontrado.");

            var comentarios = await _context.Comentarios
                .Where(c => c.ProdutoId == produtoId)
                .ToListAsync();

            return Ok(comentarios);
        }


    }
}
