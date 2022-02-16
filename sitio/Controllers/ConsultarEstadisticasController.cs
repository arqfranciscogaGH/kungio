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
    //[RoutePrefix("api/estadisticas")]
    public class ConsultarEstadisticasController : ApiController
    {

        private modelo db = new modelo();

        // GET: api/Movs/1/2/3
        [ResponseType(typeof(ConsultarEstadisticas_Result))]
        public IHttpActionResult GetEstadisticas(String latitud, String longitud, int radio)
        {
            if (latitud == "''" || latitud == null)
                latitud = "19.6592532";
            if (longitud == "''" || longitud == null)
                longitud = "-99.2127038";
            if (radio == 0 || radio == null)
                radio = 10;
            var resultado = db.ConsultarEstadisticas(latitud, longitud, radio).ToList();
            return Ok(resultado);

        }




        //[HttpGet]
        //[Route("consultar/{int:radio}")]
        ////[ResponseType(typeof(ConsultarEstadisticas_Result))]
        //public IHttpActionResult Consultar(int radio)
        //{
        //    String Latitud = "19.6592532";
        //    String Longitud = "-99.2127038";
        //    var resultado = db.ConsultarEstadisticas(Latitud, Longitud, radio).ToList();
        //    return Ok(resultado);
        //}

    }
}
