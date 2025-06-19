using CodeWearApi.Data;
using CodeWearApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using CodeWearApi.DTOs.Usuario;

namespace CodeWearApi.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDataContext _context;

        public UsuarioController(AppDataContext context)
        {
            _context = context;
        }

        // GET /usuarios
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.Include(u => u.Role).ToListAsync();

            List<UsuarioReadDto> usuariosDto = new List<UsuarioReadDto>();
            
            foreach(UsuarioModel usuario in usuarios)
            {
                UsuarioReadDto udto= new UsuarioReadDto()
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    NomeCompleto = usuario.NomeCompleto,
                    RoleId = usuario.RoleId,
                    RoleNome = _context.Roles.SingleOrDefault(x => x.Id == usuario.RoleId).Nome
                };

                usuariosDto.Add(udto);
            }

            return Ok(usuariosDto);
        }

        // GET /usuarios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
                return NotFound();

            UsuarioReadDto udto = new UsuarioReadDto()
            {
                Id = usuario.Id,
                Email = usuario.Email,
                NomeCompleto = usuario.NomeCompleto,
                RoleId = usuario.RoleId,
                RoleNome = _context.Roles.SingleOrDefault(x => x.Id == usuario.RoleId).Nome
            };

            return Ok(udto);
        }

        // POST /usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> PostUsuario(UsuarioCreateDto usuario)
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            usuarioModel.Email = usuario.Email;
            usuarioModel.NomeCompleto = usuario.NomeCompleto;
            usuarioModel.Senha = usuario.Senha;
            usuarioModel.RoleId = usuario.RoleId;
            usuarioModel.Role = _context.Roles.SingleOrDefault(x => x.Id == usuario.RoleId);



            _context.Usuarios.Add(usuarioModel);
            await _context.SaveChangesAsync();

            //UsuarioReadDto udto = new UsuarioReadDto();
            //udto.Id = usuarioModel.Id;
            //udto.Email = usuarioModel.Email;
            //udto.NomeCompleto = usuarioModel.NomeCompleto;
            //udto.RoleId = usuarioModel.RoleId;
            //udto.RoleNome = _context.Roles.SingleOrDefault(x => x.Id == usuarioModel.RoleId).Nome;

            return Ok();
        }

        // PUT /usuarios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioUpdateDto usuarioAtualizado)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(id);
            if (usuarioExistente == null)
                return NotFound();

            usuarioExistente.Email = usuarioAtualizado.Email;
            usuarioExistente.NomeCompleto = usuarioAtualizado.NomeCompleto;
            usuarioExistente.RoleId = usuarioAtualizado.RoleId;
            if (!string.IsNullOrWhiteSpace(usuarioAtualizado.Senha))
                usuarioExistente.Senha = usuarioAtualizado.Senha;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE /usuarios/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET /usuarios/{id}/carrinhos
        [HttpGet("{id}/carrinhos")]
        public async Task<ActionResult<IEnumerable<CarrinhoModel>>> GetCarrinhosUsuario(int id)
        {
            var usuarioExiste = await _context.Usuarios.AnyAsync(u => u.Id == id);
            if (!usuarioExiste)
                return NotFound();

            var carrinhos = await _context.Carrinhos
                .Where(c => c.UsuarioId == id)
                .ToListAsync();

            return Ok(carrinhos);
        }
    }
}
