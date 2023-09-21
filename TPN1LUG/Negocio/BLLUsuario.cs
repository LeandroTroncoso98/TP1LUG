using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public abstract class BLLUsuario
    {
        Acceso oDatos;
        public bool EliminarUsuario(int id)
        {
            string ConsultaSQL = $"DELETE FROM Usuario WHERE Usuario_ID = {id}";
            oDatos = new Acceso();
            return oDatos.Escribir(ConsultaSQL);
        }
    }
}
