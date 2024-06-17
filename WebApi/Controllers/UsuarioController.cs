using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionEntities;
using SistemaGestionBussiness;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetCLiente")]
        public IEnumerable<Usuario> usuarios()
        {
            return UsuarioBussiness.GetUsuarios().ToArray();
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerUsuario(int id)
        {
            Usuario usuario = UsuarioBussiness.ObtenerUsuario(id);

            return Ok(usuario);
        }

        [HttpDelete(Name = "EliminarUsuario")]
        public void Delete([FromBody] int id)
        {
            UsuarioBussiness.EliminarUsuario(id);
        }

        /*[HttpPut(Name = "ModificarUsuario")]
        public void Put([FromBody]int id, Usuario usuario)
        {
            UsuarioBussiness.ModificarUsuario(id, usuario);
        }*/

        [HttpPost(Name = "AltaUsuario")]
        public void Post([FromBody]Usuario usuario) 
        {
            UsuarioBussiness.CrearUsuario(usuario);
        }
    }
}
