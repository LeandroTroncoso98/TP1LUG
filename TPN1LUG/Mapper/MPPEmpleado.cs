using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class MPPEmpleado
    {
        Acceso oDatos;
        AccesoParametro _AccesoParametro;
        ArrayList _al;
        public bool IniciarSesion(string user, string pass)
        {
            DataTable table;
            string query = "sp_Empleado_IniciarSesion";
            _AccesoParametro = new AccesoParametro();
            _al = new ArrayList();
            SqlParameter prm1 = new SqlParameter("@email", SqlDbType.NVarChar);
            prm1.Value = user;
            _al.Add(prm1);
            SqlParameter prm2 = new SqlParameter("@pass", SqlDbType.NVarChar);
            prm2.Value = pass;
            _al.Add(prm2);
            table = _AccesoParametro.leer(query, _al);
            int resultado = Convert.ToInt32(table.Rows[0]["usuario"]);
            bool valido = (resultado > 0) ? true : false;
            return valido;
        }
        public Empleado HabilitarSesion(string user, string pass)
        {
            DataTable table;
            _AccesoParametro = new AccesoParametro();
            _al = new ArrayList();
            string query = "sp_Empleado_HabilitarSesion";
            SqlParameter prm1 = new SqlParameter("@email", SqlDbType.NVarChar);
            prm1.Value = user;
            SqlParameter prm2 = new SqlParameter("@pass", SqlDbType.NVarChar);
            prm2.Value = pass;
            _al.Add(prm1);
            _al.Add(prm2);
            table = _AccesoParametro.leer(query, _al);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                Empleado empleado = new Empleado();
                empleado.Usuario_ID = Convert.ToInt32(row[0]);
                empleado.Nombre = row[1].ToString();
                empleado.Apellido = row[2].ToString();
                empleado.Email = row[4].ToString();
                int rol = Convert.ToInt32(row[3]);
                empleado.Rol = (RolUsuario)rol; // Asigna el rol al empleado
                return empleado;
            }
            else return null;
        }
        public bool ExisteAsociadoEmpleado(Empleado empleado)
        {
            string query = "sp_Empleado_ExisteAsociado";
            _AccesoParametro = new AccesoParametro();
            _al = new ArrayList();
            SqlParameter prm1 = new SqlParameter("@user_id", SqlDbType.Int);
            prm1.Value = empleado.Usuario_ID;
            _al.Add(prm1);
            return _AccesoParametro.LeerScalar(query, _al);
        }
    }
}
