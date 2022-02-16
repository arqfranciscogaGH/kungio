using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sitio.Models;
using Sitio.Comun.Clases;
namespace Sitio.Controllers
{
    public class ServiciosClienteController : ApiController
    {
        private modelo db = new modelo();

        // GET: api/ServiciosClient
        public IHttpActionResult GetServicios(int id, int filtro,  String llave)
        {
            dynamic resultado = null;
            if (AdminisradorLLaves.validar(llave))
            {
                resultado = db.ConsultarServiciosPorCliente(id, filtro).ToList();
                return Ok(resultado);
            }
            else
                return NotFound();
        }
        public  IHttpActionResult GetServicio(int id, String llave)
        {
            dynamic resultado = null;
            if (AdminisradorLLaves.validar(llave))
            {
                resultado = db.ConsultarServiciosPorCliente(id, 0).ToList();
                return Ok(resultado);
            }
            else
                return NotFound();
        }

    }
}
