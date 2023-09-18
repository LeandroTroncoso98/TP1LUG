using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Supervisor : Empleado
    {
        public List<Profesor> ListaProfesores { get; set; }
    }
}
