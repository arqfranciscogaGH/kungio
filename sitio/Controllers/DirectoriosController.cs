using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Sitio.Models;

namespace SitioModelo.Controllers
{
    public class DirectoriosController : ApiController
    {
        private modelo db = new modelo();

        // GET: api/Directorios

        public IHttpActionResult GetDirectorio()
        {
            var directorios = db.Directorio.ToList();
            return Ok(directorios);
        }
        // GET: api/Directorios/5
        [ResponseType(typeof(Directorio))]
        public IHttpActionResult GetDirectorio(int id)
        {
            Directorio directorio = db.Directorio.Find(id);
            if (directorio == null)
            {
                return NotFound();
            }

            return Ok(directorio);
        }

        // PUT: api/Directorios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDirectorio(int id, Directorio d)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != d.id)
            {
                return BadRequest();
            }

            //db.Entry(directorio).State = EntityState.Modified;
            db.ActualizarDirectorio(d.id, d.llave, d.clave, d.fecha, d.nombre, d.descripcion, d.tipo, d.direccion, d.telefono, d.correo, d.idCategoria, d.idSubCategoria, d.idGiro, d.latitud, d.longitud, d.rutaFoto, d.urlFoto, d.urlVideo, d.paginaWeb, d.facebook, d.youTube, d.otraRedSocial, d.idSuscriptor, d.fechaEstatus, d.estatus);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Directorios
        [ResponseType(typeof(Directorio))]
        public IHttpActionResult PostDirectorio(Directorio d)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Directorio.Add(directorio);
            //System.Data.Entity.Core.Objects.ObjectResult<int?>  _id
            // System.Data.Entity.Core.Objects.ObjectResult<InsertarDirectorio_Result> 
            var resultado  = db.InsertarDirectorio(d.id, d.llave, d.clave, d.fecha, d.nombre, d.descripcion, d.tipo, d.direccion, d.telefono, d.correo, d.idCategoria, d.idSubCategoria, d.idGiro, d.latitud, d.longitud, d.rutaFoto, d.urlFoto, d.urlVideo, d.paginaWeb, d.facebook, d.youTube, d.otraRedSocial, d.idSuscriptor, d.fechaEstatus, d.estatus).FirstOrDefault(); 
            // var _id = db.InsertarDirectorio(d.id, d.llave, d.clave, d.fecha, d.nombre, d.descripcion, d.tipo, d.direccion, d.telefono, d.correo, d.idCategoria, d.idSubCategoria, d.idGiro, d.latitud, d.longitud, d.rutaFoto, d.urlFoto, d.urlVideo, d.paginaWeb, d.facebook, d.youTube, d.otraRedSocial, d.idSuscriptor, d.fechaEstatus, d.estatus).FirstOrDefault();
            //var res = _id;
            // d.id = int.Parse(_id.ToString());
            // db.SaveChanges();
            //Directorio directorio = db.Directorio.Find(_id);
            return Ok(resultado);
            //return CreatedAtRoute("DefaultApi", new { id = d.id }, d);
        }

        // DELETE: api/Directorios/5
        [ResponseType(typeof(Directorio))]
        public IHttpActionResult DeleteDirectorio(int id)
        {
            Directorio directorio = db.Directorio.Find(id);
            if (directorio == null)
            {
                return NotFound();
            }

            db.Directorio.Remove(directorio);
            db.SaveChanges();

            return Ok(directorio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DirectorioExists(int id)
        {
            return db.Directorio.Count(e => e.id == id) > 0;
        }
    }
}