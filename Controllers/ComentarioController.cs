using CodeWearApi.Data;
using CodeWearApi.Models;
using CodeWearApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeWearApi.Controllers
{
    [ApiController]
    public class ComentarioController: ControllerBase
    {

        private readonly AppDataContext _context;


        public ComentarioController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet("comentario")]
        public IActionResult GetComentarios() 
        {
            var comentarios = _context.Comentarios.ToList();

            return Ok(comentarios);
        }

        [HttpGet("comentario/{userId:int}")]
        public IActionResult GetComentariosById([FromRoute] int userId) 
        {
            var comentarios = _context.Comentarios.Where(x=> x.UsuarioId == userId).AsNoTracking().ToList();

            return Ok(comentarios);
        }

        [HttpPost("comentario/{userId:int}")]
        public IActionResult PostComentario([FromRoute] int userId, [FromBody] ComentarioCreateViewModel comentarioVm)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == userId);
            if (usuario == null)
                return NotFound(new { mensagem = "Usuário não encontrado." });

            var novoComentario = new ComentarioModel
            {
                UsuarioId = userId,
                Texto = comentarioVm.Texto
            };

            _context.Comentarios.Add(novoComentario);
            _context.SaveChanges();

            return Ok(novoComentario);
        }


        [HttpDelete("comentario/{userId:int}/{comentarioId:int}")]
        public IActionResult DeleteComentario([FromRoute] int userId, [FromRoute] int comentarioId)
        {
            var comentario = _context.Comentarios.SingleOrDefault(c => c.Id == comentarioId && c.UsuarioId == userId);

            if (comentario == null)
                return NotFound(new { mensagem = "Comentário não encontrado para este usuário." });

            _context.Comentarios.Remove(comentario);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
