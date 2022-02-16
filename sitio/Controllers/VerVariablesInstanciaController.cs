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
    public class VerVariablesInstanciaController : ApiController
    {
        private modelo db = new modelo();
        // GET: api/VerEstatus
        [ResponseType(typeof(VerVariablesInstancia_Result))]
        public IHttpActionResult Get(int id)
        {
            var resultado = db.VerVariablesInstancia(id).ToList();
            return Ok(resultado);

        }
    }
}
