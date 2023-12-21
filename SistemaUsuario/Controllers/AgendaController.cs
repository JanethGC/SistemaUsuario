using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaUsuario.Models;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SistemaUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : Controller
    {

        private readonly AgendaPruebaTecnicaReactContext _dbcontext;


        public AgendaController(AgendaPruebaTecnicaReactContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("ListarCompletaDeContactos")]
        public IActionResult ListarCompletaDeContactos()
        {
            List<Persona> lista = new List<Persona>();

            try
            {
                lista = _dbcontext.Personas.ToList();


                //lista = from p in _dbcontext.Personas
                //            join a in _dbcontext.Agenda on p.IdPersona equals a.IdPersona into aJoin
                //            from a in aJoin.DefaultIfEmpty()
                //            where a.IdPersona == null
                //            select new { p.IdPersona, p.Nombres, p.Apellidos, p.Email, p.Telefono };

                //lista = lista.ToList();



                //lista = from p in _dbcontext.Personas.AsQueryable()
                //        where p.IdPersona.NotIn(_dbcontext.Agenda.Select(a => a.IdPersona))
                //        select new { p.IdPersona, p.Nombres, p.Apellidos, p.Email, p.Telefono };

                //lista = lista.ToList();



                //lista = _dbcontext.Personas.ToQueryable()
                //    where lista.Select(p => p.IdPersona).NotIn(_dbcontext.Agenda.Select(a => a.IdPersona))
                //    select new { p.IdPersona, p.Nombres, p.Apellidos, p.Email, p.Telefono };


                //lista = lista.ToList();



                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }

        }


        [HttpGet]
        [Route("MiListarDeContactos/{idUsuario:int}")]
        public IActionResult MiListarDeContactos(int IdUsuario)
        {
            //Agendum oAgendum = _dbcontext.Agenda.Where(a => a.IdUsuario == IdUsuario).FirstOrDefault();

            var query = from a in _dbcontext.Agenda
                        where a.IdUsuario == IdUsuario
                        join p in _dbcontext.Personas on a.IdPersona equals p.IdPersona
                        select new Persona
                        {
                            IdPersona = p.IdPersona,
                            Nombres = p.Nombres,
                            Apellidos = p.Apellidos,
                            Email = p.Email,
                            Telefono = p.Telefono
                        };

            var contactos = query.ToList();

            if (contactos.Count == 0)
            {
                return BadRequest("La lista de contactos está vacía.");
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = contactos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = contactos });
            }

        }


        [HttpPost]
        [Route("AgregarContacto")]
        public IActionResult AgregarContacto([FromBody] Agenda objeto)
        {

            try
            {
                _dbcontext.Agenda.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }


        [HttpPut]
        [Route("EditarContacto")]
        public IActionResult EditarContacto([FromBody] Agenda objeto)
        {
            Agenda oAgenda = _dbcontext.Agenda.Find(objeto.IdAgenda);

            if (oAgenda == null)
            {
                return BadRequest("Contacto no encontrado");
            }

            try
            {
                oAgenda.IdUsuario = objeto.IdUsuario;
                oAgenda.IdPersona = objeto.IdPersona;

                _dbcontext.Agenda.Update(oAgenda);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }


        [HttpDelete]
        [Route("EliminarContacto/{idPersona:int}")]
        public IActionResult EliminarPersona(int IdAgenda)
        {
            Agenda oAgenda = _dbcontext.Agenda.Find(IdAgenda);

            if (oAgenda == null)
            {
                return BadRequest("Persona no encontrada");
            }
            try
            {
                _dbcontext.Agenda.Remove(oAgenda);
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
