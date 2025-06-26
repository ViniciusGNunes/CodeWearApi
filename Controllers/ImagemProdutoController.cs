using CodeWearApi.Data;
using CodeWearApi.DTOs.ImagemProdutoModel;
using CodeWearApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeWearApi.Controllers
{
    [Route("imagensProduto")]
    [ApiController]
    public class ImagemProdutoController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ImagemProdutoController(AppDataContext context)
        {
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] ImagemProdutoUploadDto dto)
        {
            if (dto.Imagem == null || dto.Imagem.Length == 0)
                return BadRequest("Imagem não enviada.");

            using var memoryStream = new MemoryStream();
            await dto.Imagem.CopyToAsync(memoryStream);
            var imagemBytes = memoryStream.ToArray();

            var imagemProduto = new ImagemProdutoModel
            {
                Descricao = dto.Descricao,
                Imagem = imagemBytes,
                ProdutoId = dto.ProdutoId,
                TipoMime = dto.Imagem.ContentType // Salva o tipo MIME aqui
            };

            _context.ImagensProduto.Add(imagemProduto);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Upload e salvamento realizados com sucesso!", id = imagemProduto.Id });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Download(int id)
        {
            var imagem = await _context.ImagensProduto.FindAsync(id);
            if (imagem == null)
                return NotFound();

            return File(imagem.Imagem, imagem.TipoMime ?? "application/octet-stream", imagem.Descricao);
        }

        [HttpGet("produto/{produtoId}")]
        public async Task<ActionResult<IEnumerable<ImagemProdutoModel>>> GetByProduto(int produtoId)
        {
            return await _context.ImagensProduto
                                 .Where(ip => ip.ProdutoId == produtoId)
                                 .ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var img = await _context.ImagensProduto.FindAsync(id);
            if (img == null)
                return NotFound();

            _context.ImagensProduto.Remove(img);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
