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
    public class FlujoTrabajoDocumentosController : ApiController
    {
        private modelo db = new modelo();

        // GET: api/Documentos
        public IQueryable<FlujoTrabajoDocumento> GetDocumento(String llave)
        {
            if (AdminisradorLLaves.validar(llave))
                return db.FlujoTrabajoDocumento; 
            else
                return null;
        }


        // GET: api/Documentos/5
        [ResponseType(typeof(FlujoTrabajoDocumento))]
        public async Task<IHttpActionResult> GetDocumento(int id, String llave)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                FlujoTrabajoDocumento Documento = await db.FlujoTrabajoDocumento.FindAsync(id);
                if (Documento == null)
                {
                    return NotFound();
                }

                return Ok(Documento);
            }
            else
                return NotFound();
        }

        // PUT: api/Documentos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDocumento(int id, String llave, FlujoTrabajoDocumento documento)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != documento.id)
                {
                    return BadRequest();
                }

                db.Entry(documento).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentoExists(id))
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

        // POST: api/Documentos
        [ResponseType(typeof(FlujoTrabajoDocumento))]
        public async Task<IHttpActionResult> PostDocumento(String llave, FlujoTrabajoDocumento documento)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.FlujoTrabajoDocumento.Add(documento);
                await db.SaveChangesAsync();
            }

            return CreatedAtRoute("DefaultApi", new { id = documento.id }, documento);
        }

        // DELETE: api/Documentos/5
        [ResponseType(typeof(Documento))]
        public async Task<IHttpActionResult> DeleteDocumento(int id, String llave)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                FlujoTrabajoDocumento documento = await db.FlujoTrabajoDocumento.FindAsync(id);
                if (documento == null)
                {
                    return NotFound();
                }

                db.FlujoTrabajoDocumento.Remove(documento);
                return Ok(documento);
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

        private bool DocumentoExists(int id)
        {
            return db.FlujoTrabajoDocumento.Count(e => e.id == id) > 0;
        }
    }
}
