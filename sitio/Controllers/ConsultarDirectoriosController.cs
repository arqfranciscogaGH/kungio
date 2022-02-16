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
    public class ConsultarDirectoriosController : ApiController
    {
        private modelo db = new modelo();
        [ResponseType(typeof(ConsultarDirectorios_Result))]
        public IHttpActionResult GetConsultarDirectorios(String latitud, String longitud, int radio, String giro, String categoria, String subcategoria)
        {
            if (latitud == "''" || latitud== null)
                latitud = "19.6592532";
            if (longitud == "''" || longitud == null)
                longitud = "-99.2127038";
            if (radio == 0 || radio == null)
                radio = 100;

        
            var resultado = db.ConsultarDirectorios(latitud, longitud, radio, giro, categoria, subcategoria).ToList();
            return Ok(resultado);

        }
    }
}
