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
    public class PerfilsController : ApiController
    {
        private modelo db = new modelo();

        // GET: api/Perfils
        public IQueryable<Perfil> GetPerfil(String llave)
        {
            if (AdminisradorLLaves.validar(llave))
                return db.Perfil;
            else
                return null;
        }

        // GET: api/Perfils/5
        [ResponseType(typeof(Perfil))]
        public async Task<IHttpActionResult> GetPerfil(int id, String llave)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                Perfil perfil = await db.Perfil.FindAsync(id);
                if (perfil == null)
                {
                    return NotFound();
                }
                return Ok(perfil);
            }
            else
                return NotFound();
        }

        // PUT: api/Perfils/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPerfil(int id, String llave, Perfil perfil)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != perfil.IdPerfil)
                {
                    return BadRequest();
                }

                db.Entry(perfil).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfilExists(id))
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

        // POST: api/Perfils
        [ResponseType(typeof(Perfil))]
        public async Task<IHttpActionResult> PostPerfil(String llave, Perfil perfil)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Perfil.Add(perfil);
                await db.SaveChangesAsync();
            }
            return CreatedAtRoute("DefaultApi", new { id = perfil.IdPerfil }, perfil);
        }

        // DELETE: api/Perfils/5
        [ResponseType(typeof(Perfil))]
        public async Task<IHttpActionResult> DeletePerfil(int id, String llave)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                Perfil perfil = await db.Perfil.FindAsync(id);
                if (perfil == null)
                {
                    return NotFound();
                }

                db.Perfil.Remove(perfil);
                await db.SaveChangesAsync();

                return Ok(perfil);
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

        private bool PerfilExists(int id)
        {
            return db.Perfil.Count(e => e.IdPerfil == id) > 0;
        }
    }
}