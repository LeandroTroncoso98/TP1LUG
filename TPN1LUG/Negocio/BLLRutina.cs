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
    public class BLLRutina
    {
        public BLLRutina()
        {
            _MPPRutina = new MPPRutina();
        }
        MPPRutina _MPPRutina;
        public Rutina traerRutina(Cliente cliente)
        {
            return _MPPRutina.traerRutina(cliente);
        }
        public bool CrearRutina(Rutina rutina, int usuarioID)
        {
            return _MPPRutina.CrearRutina(rutina, usuarioID);
        }
        public bool EditarRutina(Rutina rutina)
        {
            return _MPPRutina.EditarRutina(rutina);
        }
        public bool ExisteRutinaAsociada(int rutina_id)
        {
            return _MPPRutina.ExisteRutinaAsociada(rutina_id);
        }
        public bool EliminarRutina(int rutina_ID)
        {
            return _MPPRutina.EliminarRutina(rutina_ID);
        }



    }
}
