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
    using System.Collections.Generic;
    
    public partial class Perfil
    {
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public string Pagina { get; set; }
        public Nullable<int> IdSuscriptor { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> IdMenu { get; set; }
        public string Privilegios { get; set; }
    }
}
