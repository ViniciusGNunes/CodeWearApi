using CodeWearApi.Data;
using CodeWearApi.Models;
using CodeWearApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeWearApi.Controllers
{
    [ApiController]
    public class ProdutoController: ControllerBase
    {
        private readonly AppDataContext _context;


        public ProdutoController(AppDataContext context)
        {
            _context = context;
        }

        private bool UsuarioEhAdmin(int usuarioId)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
            return usuario != null && usuario.RoleId == 2;
        }

        [HttpGet("produto")]
        public IActionResult GetProdutos() 
        {
            var products = _context.Produtos.ToList();

            return Ok(products);
        }

        [HttpGet("produto/{id:int}")]
        public IActionResult GetProdutoById(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return NotFound(new { mensagem = "Produto não encontrado." });

            return Ok(produto);
        }

        [HttpPost("{usuarioId:int}/produto")]
        public IActionResult PostProdutos([FromBody] ProdutoCreateViewModel model, [FromQuery] int usuarioId)
        {
            if (!UsuarioEhAdmin(usuarioId))
                return Unauthorized(new { mensagem = "Apenas administradores podem criar produtos." });

            var novoProduto = new ProdutoModel
            {
                Nome = model.Nome,
                TipoProduto = model.TipoProduto,
                Preco = model.Preco,
                Tamanho = model.Tamanho,
            };

            _context.Produtos.Add(novoProduto);
            _context.SaveChanges();

            return Ok(novoProduto);
        }

        [HttpPut("{usuarioId:int}/produto/{id:int}")]
        public IActionResult PutProduto(int id, [FromBody] ProdutoCreateViewModel model, [FromRoute] int usuarioId)
        {

            if (!UsuarioEhAdmin(usuarioId))
                return Unauthorized(new { mensagem = "Apenas administradores podem criar produtos." });

            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return NotFound(new { mensagem = "Produto não encontrado." });

            produto.Nome = model.Nome;
            produto.TipoProduto = model.TipoProduto;
            produto.Preco = model.Preco;
            produto.Tamanho = model.Tamanho;

            _context.Produtos.Update(produto);
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{usuarioId:int}/produto/{id:int}")]
        public IActionResult DeleteProduto(int id, [FromRoute] int usuarioId)
        {

            if (!UsuarioEhAdmin(usuarioId))
                return Unauthorized(new { mensagem = "Apenas administradores podem criar produtos." });

            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return NotFound(new { mensagem = "Produto não encontrado." });

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
