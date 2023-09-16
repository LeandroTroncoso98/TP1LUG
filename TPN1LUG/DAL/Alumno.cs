using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Alumno
    {
        public int Alumno_ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int Edad { get; set; }
        public Tarjeta oTarjeta { get; set; }
    }
}
