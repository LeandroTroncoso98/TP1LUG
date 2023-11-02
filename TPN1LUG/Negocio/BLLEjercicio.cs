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
    public class BLLEjercicio
    {
        public BLLEjercicio()
        {
            _MPPEjercicio = new MPPEjercicio();
        }
        MPPEjercicio _MPPEjercicio;
        public List<Ejercicio> LeerEjericicios(int dia_id)
        {
            return _MPPEjercicio.ListByIdByParent(dia_id);
        }
        public bool CrearEjercicio(Ejercicio ejercicio, int dia_ID)
        {
            return _MPPEjercicio.CrearEjercicio(ejercicio, dia_ID);
        }
        public bool EditarEjercicio(Ejercicio ejercicio)
        {
            return _MPPEjercicio.EditarEjercicio(ejercicio);
        }
        public bool EliminarEjercicio(int ejercicio_id)
        {
            return _MPPEjercicio.Delete(ejercicio_id);
        }



    }
}
