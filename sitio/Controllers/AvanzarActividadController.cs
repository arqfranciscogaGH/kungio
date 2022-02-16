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
    public class AvanzarActividadController : ApiController
    {
        private modelo db = new modelo();


        // http://localhost:50954/api/FTAvanzarActividad/LINEAIV/999/INICIAR/''/''/'@FechaInicio: 05-01-2021  ,@FechaTernimacion:  , @Observacion: obs , @Resultado:resultado ,@IdUsuario:usuario ,@IdPerfil:Perfil , @IdEquipo: equipo,@Nombre:FRANCISCO  GARCIA  ALMARAZ,@Descripcion:XXX, @Clasificacion:clase,@Referencia:ref, @Importe:31000, @Numero:999'/'@IdSocio:1,@IdGrupo:B&D'/prueba/
        //  http://localhost:50954/api/FTAvanzarActividad/LINEAIV/999/INICIAR/''/''/''/''/prueba/
        public IHttpActionResult GetAvance(String clave, String identificador,  String idAccion, int? idTarea , String claveEstatus,String parametros, String variables, String llave)
        {
            dynamic resultado;
            if (AdminisradorLLaves.validar(llave))
            {
                if (clave == "''" || clave == "0")
                    clave = "LINEAIV";
                if (idAccion == null || idAccion == "")
                    idAccion = "INICIAR";
                if (idTarea == null || idTarea == 0)
                    idTarea = 1;
                if (claveEstatus == null || claveEstatus == "''")
                    claveEstatus = "";
                if (parametros == "''" || parametros == "0")
                    parametros = "";
                if (variables == "''" || variables == "0")
                    variables = "";
   
                resultado = db.AvanzarActividad(clave, identificador, idAccion , idTarea, claveEstatus, parametros,variables).ToList();
                return Ok(resultado);
            }
            else
                return NotFound();

        }
        // POST: api/AvanzarActividad
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AvanzarActividad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AvanzarActividad/5
        public void Delete(int id)
        {
        }
    }
}
