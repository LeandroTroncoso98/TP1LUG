using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Profesor : Empleado
    {
        public string Especializacion { get; set; }
        public List<Cliente> ListaClientes { get; set; }
    }
}
