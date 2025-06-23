using CodeWearApi.Data;
using CodeWearApi.DTOs.ImagemProdutoModel;
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

        [HttpPost("/upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImagem(IFormFile imagem, [FromForm] ImagemProdutoCreateDto info)
        {
            if (imagem == null || imagem.Length == 0)
                return BadRequest("Imagem inválida.");

            if (info == null)
                return BadRequest("Dados do formulário ausentes.");

            var prod = _context.Produtos.SingleOrDefault(x => x.Id == info.ProdutoId);
            if (prod == null)
                return BadRequest("Produto não encontrado.");

            var pastaDestino = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Imagens",
                $"{prod.Nome.Replace(" ", "").ToUpper()}"
            );

            // Cria a pasta se não existir
            if (!Directory.Exists(pastaDestino))
                Directory.CreateDirectory(pastaDestino);

            // Gera um nome único
            var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);
            var caminhoCompleto = Path.Combine(pastaDestino, nomeArquivo);
            var caminhoParaBanco = Path.Combine("Imagens", prod.Nome.Replace(" ", "").ToUpper(), nomeArquivo).Replace("\\", "/");

            // Salva no disco
            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await imagem.CopyToAsync(stream);
            }
            // 4294967295
            // Cria e salva no banco
            var improd = new ImagemProdutoModel
            {
                Descricao = info.Descricao,
                ProdutoId = info.ProdutoId,
                Caminho = caminhoCompleto
            };

            _context.ImagensProduto.Add(improd);
            await _context.SaveChangesAsync();

            return Ok(new { caminho = caminhoParaBanco });
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
