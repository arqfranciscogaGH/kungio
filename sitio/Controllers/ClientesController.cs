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
    public class ClientesController : ApiController
    {
        private modelo db = new modelo();

        // GET: api/Personas
        public IQueryable<Cliente> GetPersona(String llave)
        {
            if (AdminisradorLLaves.validar(llave))
                return db.Cliente;
            else
                return null;
        }

        // GET: api/Personas/5
        [ResponseType(typeof(Cliente))]
        public async Task<IHttpActionResult> GetPersona(int id, String llave)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                Cliente persona = await db.Cliente.FindAsync(id);
                if (persona == null)
                {
                    return NotFound();
                }

                return Ok(persona);
            }
            else
                return NotFound();
        }

        // PUT: api/Personas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersona(int id, String llave, Cliente persona)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != persona.id)
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
        [ResponseType(typeof(Cliente))]
        public async Task<IHttpActionResult> PostPersona(String llave, Cliente persona)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Cliente.Add(persona);
                await db.SaveChangesAsync();
            }

            return CreatedAtRoute("DefaultApi", new { id = persona.id }, persona);
        }

        // DELETE: api/Personas/5
        [ResponseType(typeof(Cliente))]
        public async Task<IHttpActionResult> DeletePersona(int id, String llave)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                Cliente persona = await db.Cliente.FindAsync(id);
                if (persona == null)
                {
                    return NotFound();
                }

                db.Cliente.Remove(persona);
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
            return db.Cliente.Count(e => e.id == id) > 0;
        }
    }
}
