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
    public class NivelRedsController : ApiController
    {
        private modelo db = new modelo();

        // GET: api/NivelReds
        public IQueryable<NivelRed> GetNivelRed(String llave)
        {
            if (AdminisradorLLaves.validar(llave))
                return db.NivelRed;
            else
                return null;
        }

        // GET: api/NivelReds/5
        [ResponseType(typeof(NivelRed))]
        public async Task<IHttpActionResult> GetNivelRed(int id, String llave)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                NivelRed nivelRed = await db.NivelRed.FindAsync(id);
                if (nivelRed == null)
                {
                    return NotFound();
                }

                return Ok(nivelRed);
                }
            else
                return NotFound();
        }

        // PUT: api/NivelReds/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNivelRed(int id, String llave, NivelRed nivelRed)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != nivelRed.id)
                {
                    return BadRequest();
                }

                db.Entry(nivelRed).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelRedExists(id))
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

        // POST: api/NivelReds
        [ResponseType(typeof(NivelRed))]
        public async Task<IHttpActionResult> PostNivelRed(String llave, NivelRed nivelRed)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.NivelRed.Add(nivelRed);
                await db.SaveChangesAsync();
            }
            return CreatedAtRoute("DefaultApi", new { id = nivelRed.id }, nivelRed);
        }

        // DELETE: api/NivelReds/5
        [ResponseType(typeof(NivelRed))]
        public async Task<IHttpActionResult> DeleteNivelRed(int id, String llave)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                NivelRed nivelRed = await db.NivelRed.FindAsync(id);
                if (nivelRed == null)
                {
                    return NotFound();
                }

                db.NivelRed.Remove(nivelRed);
                await db.SaveChangesAsync();

                return Ok(nivelRed);
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

        private bool NivelRedExists(int id)
        {
            return db.NivelRed.Count(e => e.id == id) > 0;
        }
    }
}