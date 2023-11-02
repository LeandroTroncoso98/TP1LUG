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
    public class BLLSupervisor : BLLEmpleado
    {
        public BLLSupervisor()
        {
            _MPPSupervisor = new MPPSupervisor();
        }
        MPPSupervisor _MPPSupervisor;
        public List<Supervisor> ListaSupervisores()
        {
            return _MPPSupervisor.ListaSupervisores();
        }
        public bool AltaSupervisor(Supervisor supervisor)
        {
            return _MPPSupervisor.Alta(supervisor);
        }
        public bool ModificarSupervisor(Supervisor supervisor)
        {
            return _MPPSupervisor.Modificar(supervisor);
        }
        public bool QuitarSupervisor(int id)
        {
            return _MPPSupervisor.QuitarSupervisor(id);
        }
        public bool ExistenSupervisores()
        {
           return _MPPSupervisor.ExistenSupervisores();
        }
        public bool CrearAdminInicial(string contraseña)
        {
            return _MPPSupervisor.CrearAdminInicial(contraseña);
        }




    }
}
