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
    public class FTConsultarHistorialController : ApiController
    {
        private modelo db = new modelo();
        //[HttpGet]
        int idIdioma;

        //http://localhost:50954/api/FTConsultarHistorial/LINEAIV/999/1/prueba

        [ResponseType(typeof(ConsultarHistorial_Result))]
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
                resultado = db.ConsultarHistorial(clave, identificador, idIdioma).ToList();
                return Ok(resultado);
            }
            else
                return NotFound();

        }

    }
}
