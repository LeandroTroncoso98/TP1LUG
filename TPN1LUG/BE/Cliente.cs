using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cliente : Usuario
    {
        public int Telefono { get; set; }
        public float Peso { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public Tarjeta oTarjeta { get; set; }
        public Rutina oRutina { get; set; }
    }
}
