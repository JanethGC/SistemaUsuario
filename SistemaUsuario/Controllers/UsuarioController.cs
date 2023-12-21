using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaUsuario.Models;

namespace SistemaUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AgendaPruebaTecnicaReactContext _dbcontext;

        public UsuarioController(AgendaPruebaTecnicaReactContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("ListarUsuarios")]
        public IActionResult ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                lista = _dbcontext.Usuarios.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }

        }

        [HttpGet]
        [Route("ObtenerUsuario/{idUsuario:int}")]
        public IActionResult ObtenerUsuario(int idUsuario)
        {
            Usuario oUsuario = _dbcontext.Usuarios.Where(p => p.IdUsuario == idUsuario).FirstOrDefault();

            if (oUsuario == null)
            {
                return BadRequest("Usuario no encontrada");

            }
            try
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oUsuario });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oUsuario });

            }

        }

        [HttpPost]
        [Route("GuardarUsuario")]
        public IActionResult GuardarUsuario([FromBody] Usuario objeto)
        {

            try
            {
                _dbcontext.Usuarios.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }

        }

        [HttpPut]
        [Route("EditarUsuario")]
        public IActionResult EditarUsuario([FromBody] Usuario objeto)
        {
            Usuario oUsuario = _dbcontext.Usuarios.Find(objeto.IdUsuario);

            if (oUsuario == null)
            {
                return BadRequest("Usuario no encontrada");

            }

            try
            {
                oUsuario.NombreUsuario = objeto.NombreUsuario is null ? oUsuario.NombreUsuario : objeto.NombreUsuario;
                oUsuario.Contraseña = objeto.Contraseña is null ? oUsuario.Contraseña : objeto.Contraseña;
                

                _dbcontext.Usuarios.Update(oUsuario);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }


        [HttpDelete]
        [Route("EliminarUsuario/{idUsuario:int}")]

        public IActionResult EliminarUsuario(int idUsuario)
        {
            Usuario oUsuario = _dbcontext.Usuarios.Find(idUsuario);

            if (oUsuario == null)
            {
                return BadRequest("Usuario no encontrada");

            }
            try
            {

                _dbcontext.Usuarios.Remove(oUsuario);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }


        }


    }


}
