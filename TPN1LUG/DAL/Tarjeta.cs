using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Tarjeta
    {
        public int Tarjeta_ID { get; set; }
        public DateTime Fecha_Abono { get; set; }
        public float Monto_Abono { get; set; }
        public Alumno oAlumno { get; set; }
    }
}
