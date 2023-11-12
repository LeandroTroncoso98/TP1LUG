using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BLLMaquina
    {
        public BLLMaquina()
        {
            _mpp = new MPPMaquina();
        }
        private MPPMaquina _mpp;
        public bool Agregar(Maquina maquina)
        {
            return _mpp.Agregar(maquina);
        }
        public List<Maquina> Leer()
        {
            return _mpp.Leer();
        }
        public List<Maquina> Buscar(string nombre)
        {
            return _mpp.Buscar(nombre);
        }
        public bool Borrar(Maquina maquina)
        {
            return _mpp.Borrar(maquina);
        }
    }
}
