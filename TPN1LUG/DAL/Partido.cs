using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Partido
    {
        public int Partido_ID { get; set; }
        public DateTime Partido_Fecha { get; set; }
        public TimeSpan Partido_Hora { get; set; }
        public string Direccion { get; set; }
        public List<Alumno> ListaAlumnos { get; set; }
    }
}
