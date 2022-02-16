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
    public class FTSeguimientoController : ApiController
    {
        private modelo db = new modelo();
        // GET: api/FTSeguimiento
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // http
        // http://localhost:50954/api/FTSeguimiento/LINEAIV/999/1/prueba
        [ResponseType(typeof(Seguimiento_Result))]
        public IHttpActionResult Get(String clave, String identificador, int? idIdioma, String llave)
        {
            dynamic resultado;
            if (AdminisradorLLaves.validar(llave))
            {
                if (clave == "''" || clave == "0")
                    clave = "LINEAIV";
                if (identificador == "''" || identificador == "0")
                    identificador = "";
                if (idIdioma == null || idIdioma == 0)
                    idIdioma = 1;
                resultado = db.Seguimiento(clave, identificador,idIdioma).ToList();
                return Ok(resultado);
            }
            else
                return NotFound();

        }
 

        // POST: api/FTSeguimiento
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FTSeguimiento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FTSeguimiento/5
        public void Delete(int id)
        {
        }
    }
}
