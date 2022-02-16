using System;
using Sitio.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Collections.Generic;

namespace Sitio.Controllers
{
    public class ConsultarNegociosController : ApiController
    {
        private modelo db = new modelo();
        [ResponseType(typeof(ConsultarNegocios_Result))]
        public IHttpActionResult GetConsultarNegocios(String latitud, String longitud, int radio, String giro)
        {
            if (latitud == "''" || latitud == null)
                latitud = "19.6592532";
            if (longitud == "''" || longitud == null)
                longitud = "-99.2127038";
            if (radio == 0 || radio == null)
                radio = 10;
            var resultado = db.ConsultarNegocios(latitud, longitud, radio, giro).ToList();
            return Ok(resultado);

        }
    }
}
