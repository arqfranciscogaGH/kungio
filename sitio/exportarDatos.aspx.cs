using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Sitio.Models;
using System.Data.Entity;
using System.Web.UI.HtmlControls;

namespace Sitio
{
    public partial class exportarDatos : System.Web.UI.Page
    {
        private GridView _vistaTabla = new GridView();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public GridView VistaTabla
        {
            get
            {
                if (_vistaTabla == null)
                {
                    _vistaTabla = new GridView();
                    _vistaTabla.ID = "grd_" + "id";

                    _vistaTabla.ViewStateMode = ViewStateMode.Enabled;
                    _vistaTabla.Columns.Add(new TemplateField());

                }

                return _vistaTabla;
            }
            set { _vistaTabla = value; }
        }
        protected void btnExportar_Click(object sender, EventArgs e)
        {
            dynamic resultado = null;
            modelo db = new modelo();
            List<FlujoTrabajoDocumento> documentos = db.FlujoTrabajoDocumento.ToList();

            resultado = db.VerDashBoard("", "", 1).ToList();

            AdministradorFuenteDatos admfd = new AdministradorFuenteDatos();
            //admfd.ExportarVista(this.Page, ucConsultor1.Tabla, ucConsultor1.Datos, "word", "infome");
            //admfd.ExportarVista(this.Page, gridService, documentos, "excel", string.Empty);

            gridService.DataSource = resultado;
            gridService.DataBind();
            ExportToExcel(this.Page, "Informe.xls", gridService);





        }
        private void ExportToExcel(Page pagina, string nameReport, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);


            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();

            form.Controls.Add(wControl);
            pageToRender.Controls.Add(form);

            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport);
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();
        }
    }
    public class AdministradorFuenteDatos
    {
        public static int Consecutivo = 0;
        public void ExportarVista(Page pagina, GridView control, IEnumerable<object> lista, string tipo, string nombreDocumento)
        {
            string contenido = string.Empty;
            HttpResponse response = pagina.Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            control.EnableViewState = false;
            control.AllowPaging = false;

            //control.DataSource = lista;
            //control.DataBind();
            //control.RenderControl(htw);
            //control.RenderControl(htw);

            GridView controltemp = new GridView();
            controltemp.DataSource = lista;
            controltemp.DataBind();

            //HtmlForm form = new HtmlForm();
            //pagina.Controls.Add(form);
            //form.Controls.Add(controltemp);
            pagina.Controls.Add(controltemp);

            //controltemp.RenderControl(htw);

            DefinirTipoDocumentoExportacion(tipo, ref nombreDocumento, ref contenido);

            response.Clear();
            response.Buffer = true;
            response.ClearContent();
            //response.ContentType = "application/vnd.ms-excel";
            response.ContentType = contenido;
            response.AddHeader("Content-Disposition", "attachment;filename=" + nombreDocumento);
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;


            response.Write(sw.ToString());
            response.End();
        }
        public void DefinirTipoDocumentoExportacion(string tipo, ref string nombreDocumento, ref string contenido)
        {
            if (nombreDocumento == null || nombreDocumento == string.Empty)
                nombreDocumento = "Documento" + Consecutivo++.ToString();
            switch (tipo.ToUpper())
            {
                case "WORD":
                    nombreDocumento = nombreDocumento + ".doc";
                    contenido = "application/word";
                    break;
                case "EXCEL":
                    nombreDocumento = nombreDocumento + ".xls";
                    contenido = "application/excel";
                    break;
                case "PDF":
                    nombreDocumento = nombreDocumento + ".pdf";
                    contenido = "application/vnd.ms-excel";
                    break;
            }
        }
    }
}