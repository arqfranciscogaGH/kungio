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
    public class ConsultarDocumentosFlujoTrabajoController : ApiController
    {
        private modelo db = new modelo();

        // http://localhost:50954/api/ConsultarDocumentosFlujoTrabajo/1/prueba
        public async Task<IHttpActionResult> GetDocumentos(int id, String llave)
        {
            dynamic resultado = null;
            if (AdminisradorLLaves.validar(llave))
            {
                resultado = resultado = db.ConsultarDocumentosFlujoTrabajo(id).ToList();
                return Ok(resultado);
            }
            else
                return NotFound();
        }
    }
}
