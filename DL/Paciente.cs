//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Paciente
    {
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string AP { get; set; }
        public string AM { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<byte> IdTipoSangre { get; set; }
        public string Sexo { get; set; }
        public string Sintomas { get; set; }
    
        public virtual TipoSangre_DDL TipoSangre_DDL { get; set; }
    }
}
