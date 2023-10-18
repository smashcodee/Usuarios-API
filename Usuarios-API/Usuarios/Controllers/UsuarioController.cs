using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usuarios.Data;
using Usuarios.Data.Dto;
using Usuarios.Model;

namespace Usuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuariosContext _context;
        private IMapper _mapper;
        public UsuarioController(UsuariosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AdicionarUsuario([FromBody] CreateUsuarioDto usuarioDto)
        { 
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(LerUsuariosPorId), new {id = usuario.Id}, usuario);
        }

        [HttpGet]
        public IEnumerable<ReadUsuarioDto> LerUsuarios([FromQuery] int skip = 0, 
            [FromQuery]int take = 10) 
        {
            return _mapper.Map<List<ReadUsuarioDto>>(_context.Usuarios.Skip(skip).Take(take));  
        }


        [HttpGet("{id}")]
        public IActionResult LerUsuariosPorId(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(usaurio => usaurio.Id == id);
            if (usuario == null) return NotFound();
            var usuarioDto = _mapper.Map<ReadUsuarioDto>(usuario);
            return Ok(usuarioDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaUsuarios(int id,[FromBody] UpdateUsuarioDto usuarioDto)
        {
            var usuario = _context.Usuarios.FirstOrDefault(
                usuario => usuario.Id == id);
            if(usuario == null) return NotFound();
            _mapper.Map(usuarioDto, usuario);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaUsuario(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(
                usuario =>  usuario.Id == id);
            if(usuario == null) return NotFound();

            _context.Remove(usuario);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
