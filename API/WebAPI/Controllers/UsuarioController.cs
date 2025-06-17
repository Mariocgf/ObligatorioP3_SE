using Compartido.DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.ExepcionesEntidades;
using Microsoft.AspNetCore.Mvc;
using WebAPI.JWT;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioLogin _usuarioLogin;
        public UsuarioController(IUsuarioLogin usuarioLogin)
        {
            _usuarioLogin = usuarioLogin;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                if (loginDto == null)
                    return BadRequest("Datos vacios");
                UsuarioLoggedDTO usuarioDto = _usuarioLogin.Login(loginDto);
                if (usuarioDto == null)
                    return BadRequest("Datos vacios");
                usuarioDto.Token = ManejadorToken.CrearToken(usuarioDto);
                return Ok(usuarioDto);
            }
            catch (UsuarioException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error interno del servidor :)");
            }
        }
    }
}
