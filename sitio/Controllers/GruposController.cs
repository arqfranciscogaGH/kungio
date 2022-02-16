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
    public class GruposController : ApiController
    {
        private modelo db = new modelo();

        // GET: api/Grupos
        public IQueryable<Grupo> GetGrupo(String llave)
        {
            if (AdminisradorLLaves.validar(llave))
                return db.Grupo;
            else
                return null;
        }

        // GET: api/Grupos/5
        [ResponseType(typeof(Grupo))]
        public async Task<IHttpActionResult> GetGrupo(int id, String llave)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                Grupo grupo = await db.Grupo.FindAsync(id);
                if (grupo == null)
                {
                    return NotFound();
                }
                return Ok(grupo);
            }
            else
                return NotFound();
         }

        // PUT: api/Grupos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGrupo(int id, String llave, Grupo grupo)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != grupo.IdGrupo)
                {
                    return BadRequest();
                }

                db.Entry(grupo).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoExists(id))
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

        // POST: api/Grupos
        [ResponseType(typeof(Grupo))]
        public async Task<IHttpActionResult> PostGrupo(String llave, Grupo grupo)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Grupo.Add(grupo);
                await db.SaveChangesAsync();
            }
            return CreatedAtRoute("DefaultApi", new { id = grupo.IdGrupo }, grupo);
        }

        // DELETE: api/Grupos/5
        [ResponseType(typeof(Grupo))]
        public async Task<IHttpActionResult> DeleteGrupo(int id, String llave)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                Grupo grupo = await db.Grupo.FindAsync(id);
                if (grupo == null)
                {
                    return NotFound();
                }
                db.Grupo.Remove(grupo);
                await db.SaveChangesAsync();

                return Ok(grupo);
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

        private bool GrupoExists(int id)
        {
            return db.Grupo.Count(e => e.IdGrupo == id) > 0;
        }
    }
}