using CodeWearApi.Data;
using CodeWearApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeWearApi.Controllers
{
    [ApiController]
    [Route("itemcarrinho")]
    public class ItemCarrinhoController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ItemCarrinhoController(AppDataContext context)
        {
            _context = context;
        }

        // GET /itemcarrinho
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemCarrinhoModel>>> GetAll()
        {
            return await _context.ItemsCarrinho
                .ToListAsync();
        }

        // GET /itemcarrinho/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemCarrinhoModel>> GetById(int id)
        {
            var item = await _context.ItemsCarrinho
                .FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST /itemcarrinho
        [HttpPost]
        public async Task<ActionResult<ItemCarrinhoModel>> Create(ItemCarrinhoModel novoItem)
        {
            var carrinhoExiste = await _context.Carrinhos.AnyAsync(c => c.Id == novoItem.CarrinhoId);
            var produtoExiste = await _context.Produtos.AnyAsync(p => p.Id == novoItem.ProdutoId);

            if (!carrinhoExiste || !produtoExiste)
                return BadRequest("Carrinho ou Produto inválido.");

            _context.ItemsCarrinho.Add(novoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = novoItem.Id }, novoItem);
        }

        // PUT /itemcarrinho/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]ItemCarrinhoModel itemAtualizado)
        {
            var itemExistente = await _context.ItemsCarrinho.FindAsync(id);
            if (itemExistente == null)
                return NotFound();

            itemExistente.Quantidade = itemAtualizado.Quantidade;
            itemExistente.ProdutoId = itemAtualizado.ProdutoId;
            itemExistente.CarrinhoId = itemAtualizado.CarrinhoId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE /itemcarrinho/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.ItemsCarrinho.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.ItemsCarrinho.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET /carrinhos/{id}/itens
        [HttpGet("/carrinhos/{id}/itens")]
        public async Task<ActionResult<IEnumerable<ItemCarrinhoModel>>> GetItensPorCarrinho(int id)
        {
            var carrinhoExiste = await _context.Carrinhos.AnyAsync(c => c.Id == id);
            if (!carrinhoExiste)
                return NotFound();

            var itens = await _context.ItemsCarrinho
                .Where(i => i.CarrinhoId == id)
                .ToListAsync();

            return Ok(itens);
        }
    }
}
