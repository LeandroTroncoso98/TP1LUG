using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Dia
    {
        public int Dia_ID { get; set; }
        public string Tipo_Ejercicio { get; set; }
        public string Nombre { get; set; }
        public List<Ejercicio> ListaEjercicio { get; set; }
    }
}
