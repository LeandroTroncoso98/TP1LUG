using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Supervisor : Usuario
    {
        public List<Profesor> ListaProfesores { get; set; }
    }
}
