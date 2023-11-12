using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Maquina
    {
        public Maquina()
        {

        }
        public Maquina(string nombre,int maximoPeso,int cantidad)
        {
            Nombre = nombre;
            MaximoPeso = maximoPeso;
            Cantidad = cantidad;
        }
        public string Nombre { get; set; }
        public int MaximoPeso { get; set; }
        public int Cantidad { get; set; }
    }
}
