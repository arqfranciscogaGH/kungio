//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sitio.Models
{
    using System;
    
    public partial class Seguimiento_Result
    {
        public Nullable<int> Orden { get; set; }
        public string Actividad { get; set; }
        public string Estatus__Instancia { get; set; }
        public string Estatus_Tarea { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaTernimacion { get; set; }
        public Nullable<int> TiempoActividad { get; set; }
        public Nullable<int> TiempoLimite { get; set; }
        public Nullable<int> ProductividadTiempo { get; set; }
        public string Referencia { get; set; }
        public string IdUsuario { get; set; }
        public string IdEquipo { get; set; }
        public string Observacion { get; set; }
    }
}
