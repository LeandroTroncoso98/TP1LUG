using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Ejercicio
    {
        public int Ejercicio_ID { get; set; }
        public string Nombre { get; set; }
        public int Series { get; set; }
        public string Descripcion_Adicional { get; set; }
        public override string ToString()
        {
            return Nombre + " " + Series;
        }
    }
}
