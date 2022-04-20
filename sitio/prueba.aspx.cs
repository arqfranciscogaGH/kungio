using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Newtonsoft.Json;
using Sitio.Models;
namespace Sitio
{
    public partial class prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String sitio_url = "http://api.kungio.com";
            String api_url = "/api/Clientes/prueba";
            String api_url2 = "http://jsonplaceholder.typicode.com/users";
            HttpClient cliente= new HttpClient() ;
            cliente.BaseAddress = new Uri(sitio_url);
            var request =  cliente.GetAsync(api_url).Result;
            if(request.IsSuccessStatusCode)
            {
                String  resultadojson = request.Content.ReadAsStringAsync().Result;
                List<Cliente> lista =JsonSerializer.Deserialize<List<Cliente>>(resultadojson);
                //var lista =JsonSerializer.Serialize(resultadojson);
                // var lista = JsonSerializer.Serialize(resultadojson);
                //List<Cliente> lista = JsonConvert.DeserializeObject<List<Cliente>>(resultadojson);

            }
        


        }
    }
}