using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BLLProfesor : BLLEmpleado
    {
        public BLLProfesor()
        {
            _MPPProfesor = new MPPProfesor();
        }
        MPPProfesor _MPPProfesor;
        public bool AltaProfesor(Profesor profesor)
        {
            return _MPPProfesor.AltaProfesor(profesor);
        }
        public List<Profesor> ListaProfesores()
        {
            return _MPPProfesor.ListaProfesores();
        }
        public bool ActualizarProfesor(Profesor profesor)
        {
            return _MPPProfesor.ActualizarProfesor(profesor);
        }
        public bool AscenderProfesor(int id)
        {
            return _MPPProfesor.AscenderProfesor(id);
        }



    }
}
