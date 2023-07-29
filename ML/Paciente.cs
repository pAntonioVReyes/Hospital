using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string Ap { get; set; }
        public string Am { get; set; }
        public string FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public ML.TipoSangre_DLL TipoSangre { get; set; }
        public string Sexo { get; set; }
        public string Sintomas { get; set; }
        public List<object> Pacientes { get; set; }
    }
}
