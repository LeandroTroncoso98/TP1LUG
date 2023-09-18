using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BLLEmpleado
    {
        Acceso oDatos;

        public bool IniciarSesion(string user,string pass)
        {
            DataTable table;
            oDatos = new Acceso();
            table = oDatos.Leer($"SELECT COUNT(*) AS usuario FROM Usuario AS a WHERE a.Email LIKE '{user}' AND a.Contraseña LIKE '{pass}'");
            int resultado = Convert.ToInt32(table.Rows[0]["usuario"]);
            
            bool valido = (resultado > 0) ? true : false;
            return valido;
        }
    }
}
