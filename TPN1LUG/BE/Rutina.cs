using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Rutina
    {
        public int Rutina_ID { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public List<Dia> Lista_Dia { get; set; }
        public string DescripcionGeneral { get; set; }
    }
}
