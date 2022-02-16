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
    public class FTConsultarMisPendientesController : ApiController
    {
        private modelo db = new modelo();


        // http://localhost:50954/api/FTConsultarMisPendientes/LINEAIV/var/1/prueba/xxx/cons

        [ResponseType(typeof(ConsultarMisPendientes_Result))]
        public IHttpActionResult Get( String clave, String variables, int? idIdioma, String llave, String consulta)
        {
            dynamic resultado;
            if (AdminisradorLLaves.validar(llave))
            {
                if (clave == "''" || clave == "0")
                    clave = "LINEAIV";
                if (variables == "''" || variables == "0")
                    variables = "";
                if (idIdioma == null || idIdioma == 0)
                    idIdioma = 1;
                resultado = db.ConsultarMisPendientes(clave, variables, idIdioma).ToList();
                return Ok(resultado);
            }
            else
                return NotFound();

        }

        // POST: api/FTConsultarMisPendientes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FTConsultarMisPendientes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FTConsultarMisPendientes/5
        public void Delete(int id)
        {
        }
    }
}
