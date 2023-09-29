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
    public class BLLEmpleado : BLLUsuario
    {
        public BLLEmpleado()
        {
            _MPPEmpleado = new MPPEmpleado();
        }
        MPPEmpleado _MPPEmpleado;
        public bool IniciarSesion(string user, string pass)
        {
            return _MPPEmpleado.IniciarSesion(user, pass);
        }
        public Empleado HabilitarSesion(string user, string pass)
        {
            return _MPPEmpleado.HabilitarSesion(user, pass);
        }
        public bool ExisteAsociadoEmpleado(Empleado empleado)
        {
            return _MPPEmpleado.ExisteAsociadoEmpleado(empleado);
        }



    }
}
