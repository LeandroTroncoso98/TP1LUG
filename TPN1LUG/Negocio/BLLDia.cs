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
    public class BLLDia
    {
        public BLLDia()
        {
            _MPPDia = new MPPDia();
        }
        MPPDia _MPPDia;
        public List<Dia> LeerDias(int rutina_ID)
        {
            return _MPPDia.ListByIdByParent(rutina_ID);
        }
        public bool CrearDia(Dia dia, int rutina_ID)
        {
            return _MPPDia.CrearDia(dia, rutina_ID);
        }
        public bool ExisteDia(string nombre, int rutina_ID = 0)
        {
            return _MPPDia.ExisteDia(nombre, rutina_ID);
        }
        public bool EditarDia(Dia dia)
        {
            return _MPPDia.EditarDia(dia);
        }
        public bool EliminarDia(int dia_ID)
        {
            return _MPPDia.Delete(dia_ID);
        }
        public bool ExisteDiaAsociado(int dia_id)
        {
            return _MPPDia.ExisteDiaAsociado(dia_id);
        }
        public Dia LeerDia(int dia_id)
        {
            return _MPPDia.LeerDia(dia_id);
        }






    }
}
