using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Data;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PersonasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Persona> GetPersonas()
        {
            

            return  context.Persona.ToList(); 

        }

        [HttpPost("{idPersona:Guid}", Name = "AceptarEliminar")]
        public ActionResult AceptarEliminar([FromBody]int eliminar, Guid idPersona) 
        {
            if (eliminar == 1)
            {
                this.BorrarPersona(idPersona);
                var listaPersonas = this.GetPersonas();
                return Ok(listaPersonas);
            }
            else 
            {
                return Ok(this.GetPersonas());
            }
            
            
        }
        
        
        [HttpDelete("{idPersonas:Guid}", Name = "BorrarPersona")]
        private ActionResult BorrarPersona(Guid idPersonas)
        {
            var persona = context.Persona.FirstOrDefault(p => p.Id == idPersonas);

            if (persona != null)
            {

                context.Persona.Remove(persona);
                context.SaveChanges();

                var listaPersonas = context.Persona.OrderBy(p => p.Nombre).ToList();

                return Ok(listaPersonas);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{Id}")]
        public IActionResult ActualizarPersona(Guid Id, [FromBody] Persona persona)
        {
            if (persona.Id.Equals(Id))
            {
                context.Entry(persona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                var listaPersonas = context.Persona.OrderBy(p => p.Nombre).ToList();

                return Ok(listaPersonas);
            }
            else
            {
                ModelState.AddModelError("", "Algo salio mal eliminando el registro");
                return StatusCode(404, ModelState);
            }
        }

        [HttpPost]
        public ActionResult CrearPersona([FromBody] Persona persona)
        {
            try
            {
                context.Persona.Add(persona);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


    }
}
