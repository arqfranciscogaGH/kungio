using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Sitio.Models;
using Sitio.Comun.Clases;

namespace Sitio.Controllers
{
    public class PersonasController : ApiController
    {
        private modelo db = new modelo();

        // GET: api/Personas
        public IQueryable<Persona> GetPersona(String llave)
        {
            if (AdminisradorLLaves.validar(llave))
                return db.Persona;
            else
                return null;
        }

        // GET: api/Personas/5
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> GetPersona(int id, String llave)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                Persona persona = await db.Persona.FindAsync(id);
                if (persona == null)
                {
                    return NotFound();
                }

                return Ok(persona);
            }
            else
                return NotFound();
        }
        public async Task<IHttpActionResult> GetPersona(int id, String filtro, String llave)
        {
            dynamic resultado = null;
            if (AdminisradorLLaves.validar(llave))
            {
                if (filtro == "id")
                    resultado = db.Persona.Where(s => s.IdPersona == id).ToList();
                else if (filtro == "IdUsuario")
                    resultado = db.Persona.Where(s => s.IdUsuario == id).ToList();
                else if (filtro == "IdSuscriptor")
                    resultado = db.Persona.Where(s => s.IdSuscriptor == id).ToList();
                else
                    resultado = db.Persona;
                return Ok(resultado);
            }
            else
                return NotFound();
        }
        // PUT: api/Personas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersona(int id, String llave, Persona persona)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != persona.IdPersona)
                {
                    return BadRequest();
                }

                db.Entry(persona).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Personas
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> PostPersona(String llave, Persona persona)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Persona.Add(persona);
                await db.SaveChangesAsync();
            }

            return CreatedAtRoute("DefaultApi", new { id = persona.IdPersona }, persona);
        }

        // DELETE: api/Personas/5
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> DeletePersona(int id, String llave)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                Persona persona = await db.Persona.FindAsync(id);
                if (persona == null)
                {
                    return NotFound();
                }

                db.Persona.Remove(persona);
                    return Ok(persona);
            }
            else
               return NotFound();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonaExists(int id)
        {
            return db.Persona.Count(e => e.IdPersona == id) > 0;
        }
    }
}