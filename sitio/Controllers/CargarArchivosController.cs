using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Sitio.Models.ViewModels;
namespace Sitio.Controllers
{
    public class CargarArchivosController : Controller
    {
        // GET: CargarArchivos
        public ActionResult Index()
        {
            return View();
        }
        [System.Web.Http.HttpPost]
        public ArchivoViewModel Guardar( [FromBody] ArchivoViewModel m)
        {
            //var  pro = new Multipart
            //Models.ViewModels.ArchivoViewModel model
            String ruta = Server.MapPath("archivos");
            return m;
        }
    }
}