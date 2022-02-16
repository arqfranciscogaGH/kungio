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
    public class VerEstatusTareaController : ApiController
    {
        private modelo db = new modelo();
        // GET: api/VerEstatus
        [ResponseType(typeof(VerEstatusTarea_Result))]
        public IHttpActionResult Get(int id)
        {
            var resultado = db.VerEstatusTarea(id).ToList();
            return Ok(resultado);

        }
    }
}
