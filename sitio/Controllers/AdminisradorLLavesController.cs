using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sitio.Comun.Clases;

namespace Sitio.Controllers
{
    public class AdminisradorLLavesController : ApiController
    {
        // http://localhost:50954/api/AdminisradorLLaves/1/produccion
        // http://localhost:50954/api/AdminisradorLLaves/Validar/1/produccion
        public string Get(int id, String llave)
        {
            return AdminisradorLLaves.generar(id, llave);
        }
        public bool Validar(int id, String llave)
        {
            return AdminisradorLLaves.validar(llave);
        }
    }
}
