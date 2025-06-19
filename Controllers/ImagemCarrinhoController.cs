using CodeWearApi.Data;
using CodeWearApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeWearApi.Controllers
{
    [ApiController]
    public class ImagemProdutoController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ImagemProdutoController(AppDataContext context)
        {
            _context = context;
        }

        // GET /produtos/{produtoId}/imagens
        [HttpGet("produtos/{produtoId}/imagens")]
        public async Task<ActionResult<IEnumerable<ImagemProdutoModel>>> GetByProdutoId(int produtoId)
        {
            var produtoExiste = await _context.Produtos.AnyAsync(p => p.Id == produtoId);
            if (!produtoExiste)
                return NotFound("Produto não encontrado.");

            var imagens = await _context.ImagensProduto
                .Where(i => i.ProdutoId == produtoId)
                .ToListAsync();

            return Ok(imagens);
        }

        // POST /produtos/{produtoId}/imagens
        [HttpPost("produtos/{produtoId}/imagens")]
        public async Task<ActionResult<ImagemProdutoModel>> AddImagem(int produtoId, [FromBody] ImagemProdutoModel imagem)
        {
            var produtoExiste = await _context.Produtos.AnyAsync(p => p.Id == produtoId);
            if (!produtoExiste)
                return NotFound("Produto não encontrado.");

            imagem.ProdutoId = produtoId;

            _context.ImagensProduto.Add(imagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByProdutoId), new { produtoId = produtoId }, imagem);
        }

        // DELETE /imagens/{imagemId}
        [HttpDelete("imagens/{imagemId}")]
        public async Task<IActionResult> DeleteImagem(int imagemId)
        {
            var imagem = await _context.ImagensProduto.FindAsync(imagemId);
            if (imagem == null)
                return NotFound();

            _context.ImagensProduto.Remove(imagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
