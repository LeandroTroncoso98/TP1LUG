using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class IniciadorSupervisor
    {
        public IniciadorSupervisor()
        {
            oBLLSupervisor = new BLLSupervisor();
        }
        BLLSupervisor oBLLSupervisor;
        public bool Inicializar(string contraseña)
        {
            if(!oBLLSupervisor.ExistenSupervisores()){
                return oBLLSupervisor.CrearAdminInicial(contraseña);
            }
            return false;
        }
    }
}
