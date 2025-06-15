using CodeWearApi.Data;
using CodeWearApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeWearApi.Controllers
{
    [ApiController]
    public class UsuarioController: ControllerBase
    {
        private readonly AppDataContext _context;


        public UsuarioController(AppDataContext context) 
        {
            _context  = context;
        }

        [HttpGet("usuario/{id:int}")]
        public IActionResult GetUsuarioById([FromRoute] int id)
        {
            var user = _context.Usuarios.SingleOrDefault(x => x.Id == id);

            return Ok(user);
        }

        [HttpGet("usuario")]
        public IActionResult GetAllUsuarios()
        {
            var users = _context.Usuarios.ToList();

            return Ok(users);
        }

        [HttpPost("usuario")]
        public IActionResult PostUsuario([FromBody] UsuarioModel newUser)
        {
            _context.Usuarios.Add(newUser);
            _context.SaveChanges();

            return Ok();

        }

        [HttpPut("usuario-senha/{id:int}")]
        public IActionResult PutSenhaUsuario([FromBody] string senha, [FromRoute] int id)
        {
            var user = _context.Usuarios.SingleOrDefault(x => x.Id == id);
            user.Password = senha;
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("usuario-email/{id:int}")]
        public IActionResult PutEmailUsuario([FromBody] string email, [FromRoute] int id)
        {
            var user = _context.Usuarios.SingleOrDefault(x => x.Id == id);
            user.Email = email;
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("usuario-nome/{id:int}")]
        public IActionResult PutNomeUsuario([FromBody] string nome, [FromRoute] int id)
        {
            var user = _context.Usuarios.SingleOrDefault(x => x.Id == id);
            user.NomeCompleto = nome;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("usuario/{id}")]
        public IActionResult DeleteUsuario([FromRoute] int id)
        {
            var user = _context.Usuarios.SingleOrDefault(x => x.Id == id);
            _context.Usuarios.Remove(user);
            _context.SaveChanges();

            return Ok();
        }
    }
}
