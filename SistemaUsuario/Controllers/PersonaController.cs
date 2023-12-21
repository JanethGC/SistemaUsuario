using Microsoft.AspNetCore.Cors; //PERMITE USAR las reglas CORS
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaUsuario.Models;
using System;

namespace SistemaUsuario.Controllers
{
    //Habilita las ReglasCors para este controlador
    //[EnableCors("ReglasCors")]

    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly AgendaPruebaTecnicaReactContext _dbcontext;

        public PersonaController(AgendaPruebaTecnicaReactContext context)
        {
            _dbcontext = context;
        }

        

        [HttpGet]
        [Route("ListarPersonas")]
        public IActionResult ListarPersonas()
        {
            List<Persona> lista = new List<Persona>();

            try
            {
                lista = _dbcontext.Personas.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response =lista });

            }
            catch ( Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }

        }

        [HttpGet]
        [Route("ObtenerPersona/{idPersona:int}")]
        public IActionResult ObtenerPersona( int idPersona)
        {
            Persona oPersona = _dbcontext.Personas.Where(p => p.IdPersona == idPersona).FirstOrDefault();
            
            if (oPersona == null)
            {
                return BadRequest("Persona no encontrada");

            }
            try
            {
                
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oPersona });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oPersona });

            }

        }

        [HttpPost]
        [Route("GuardarPersona")]
        public IActionResult GuardarPersona([FromBody] Persona objeto)
        {

            try
            {
                _dbcontext.Personas.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok"});

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message});

            }

        }

        [HttpPut]
        [Route("EditarPersona")]
        public IActionResult EditarPersona([FromBody] Persona objeto)
        {
            Persona oPersona = _dbcontext.Personas.Find(objeto.IdPersona);

            if (oPersona == null)
            {
                return BadRequest("Persona no encontrada");

            }

            try
            {
                oPersona.Cedula = objeto.Cedula is null ? oPersona.Cedula : objeto.Cedula;
                oPersona.Nombres = objeto.Nombres is null ? oPersona.Nombres : objeto.Nombres;
                oPersona.Apellidos = objeto.Apellidos is null ? oPersona.Apellidos : objeto.Apellidos;
                oPersona.Edad = objeto.Edad is null ? oPersona.Edad : objeto.Edad;
                oPersona.Email = objeto.Email is null ? oPersona.Email : objeto.Email;
                oPersona.Telefono = objeto.Telefono is null ? oPersona.Telefono : objeto.Telefono;

                _dbcontext.Personas.Update(oPersona);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }


        [HttpDelete]
        [Route("EliminarPersona/{idPersona:int}")]

        public IActionResult EliminarPersona(int idPersona)
        {
            Persona oPersona = _dbcontext.Personas.Find(idPersona);

            if (oPersona == null)
            {
                return BadRequest("Persona no encontrada");

            }
            try
            {
                
                _dbcontext.Personas.Remove(oPersona);
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
