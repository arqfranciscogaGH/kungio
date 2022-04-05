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
    public class UsuariosController : ApiController
    {
        private modelo db = new modelo();

        // GET: api/Usuarios
        public IQueryable<CuentaUsuario> GetUsuario(String llave)
        {

            if (AdminisradorLLaves.validar(llave))
                return db.CuentaUsuario;
            else
                return null;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(CuentaUsuario))]
        public async Task<IHttpActionResult> GetUsuario(int id, String llave)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                CuentaUsuario usuario = await db.CuentaUsuario.FindAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }

                return Ok(usuario);
            }
            else
                return NotFound();
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsuario(int id, String llave, CuentaUsuario usuario)
        {
            if (AdminisradorLLaves.validar(llave))
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != usuario.IdUsuario)
                {
                    return BadRequest();
                }

                db.Entry(usuario).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(CuentaUsuario))]
        public async Task<IHttpActionResult> PostUsuario( String llave, CuentaUsuario usuario)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.CuentaUsuario.Add(usuario);
                await db.SaveChangesAsync();
            }
            return CreatedAtRoute("DefaultApi", new { id = usuario.IdUsuario }, usuario);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> DeleteUsuario(int id,String llave)
        {
            if (AdminisradorLLaves.validar(llave))
            {
                CuentaUsuario usuario = await db.CuentaUsuario.FindAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }

                db.CuentaUsuario.Remove(usuario);
                await db.SaveChangesAsync();
                return Ok(usuario);
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

        private bool UsuarioExists(int id)
        {
            return db.CuentaUsuario.Count(e => e.IdUsuario == id) > 0;
        }
    }
}