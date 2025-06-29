using CodeWearApi.Data;
using CodeWearApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeWearApi.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ProdutoController(AppDataContext context)
        {
            _context = context;
        }

        // GET: /produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetAll()
        {
            return await _context.Produtos
                .ToListAsync();
        }

        // GET: /produtos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> GetById(int id)
        {
            var produto = await _context.Produtos
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null)
                return NotFound();

            return produto;
        }

        // POST: /produtos
        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Create(ProdutoModel produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProdutoModel produto)
        {
            var oldProduto = await _context.Produtos.SingleOrDefaultAsync(x => x.Id == id);
            if (oldProduto == null)
                return NotFound();

            // Verifica se a Colecao existe
            var colecao = await _context.Colecoes.FindAsync(produto.ColecaoId);
            if (colecao == null)
                return BadRequest("Coleção informada não existe.");

            // Atualiza os campos
            oldProduto.Nome = produto.Nome;
            oldProduto.TipoProduto = produto.TipoProduto;
            oldProduto.Preco = produto.Preco;
            oldProduto.ColecaoId = produto.ColecaoId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: /produtos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return NotFound();

            var comentarios = _context.Comentarios.Where(x => x.ProdutoId == id).ToList();
            _context.Comentarios.RemoveRange(comentarios);

            var itensCarrinho = _context.ItemsCarrinho.Where(x => x.ProdutoId == produto.Id).ToList();
            _context.ItemsCarrinho.RemoveRange(itensCarrinho);

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // GET: /produtos/{id}/comentarios
        [HttpGet("{id}/comentarios")]
        public async Task<ActionResult<IEnumerable<ComentarioModel>>> GetComentariosProduto(int id)
        {
            var produtoExiste = await _context.Produtos.AnyAsync(p => p.Id == id);
            if (!produtoExiste)
                return NotFound();

            var comentarios = await _context.Comentarios
                .Where(c => c.ProdutoId == id)
                .ToListAsync();

            return Ok(comentarios);
        }




        // GET: /produtos/{id}/imagens

        [HttpGet("{id}/imagens")]
        public async Task<ActionResult<IEnumerable<ImagemProdutoModel>>> GetImagensProduto(int id)
        {
            var produtoExiste = await _context.Produtos.AnyAsync(p => p.Id == id);
            if (!produtoExiste)
                return NotFound();

            var imagens = await _context.ImagensProduto
                .Where(i => i.ProdutoId == id)
                .ToListAsync();

            return Ok(imagens);
        }

        [HttpGet("{id}/colecoes")]
        public async Task<IActionResult> GetColecaoProduto([FromRoute]int id) 
        {
            var produto = await _context.Produtos.SingleOrDefaultAsync(x => x.Id == id);

            if (produto is null) return Ok("Este produto não existe");

            if (produto.ColecaoId is null) return Ok("Este produto não é parte de uma colecao");

            var colecao = await _context.Colecoes.SingleOrDefaultAsync(x => x.Id == produto.ColecaoId);

            int a = 10;

            return Ok(colecao);
        }

    }
}
