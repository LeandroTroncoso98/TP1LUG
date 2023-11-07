using Abstraction;
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
    public class MPPSupervisor : IAltaModificable<Supervisor>
    {
        AccesoParametro _accesoParametro;
        private ArrayList _al;
        public List<Supervisor> ListaSupervisores()
        {
            List<Supervisor> supervisores = new List<Supervisor>();
            DataTable table;
            _accesoParametro = new AccesoParametro();
            table = _accesoParametro.leer("sp_Supervisor_ListaSupervisores",null);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    Supervisor supervisor = new Supervisor();
                    supervisor.Usuario_ID = Convert.ToInt32(row[0]);
                    supervisor.Nombre = row[1].ToString().Trim();
                    supervisor.Apellido = row[2].ToString().Trim();
                    supervisor.Rol = RolUsuario.Supervisor;
                    supervisor.Email = row[4].ToString().Trim();
                    supervisores.Add(supervisor);
                }
            }
            else supervisores = null;
            return supervisores;
        }
        public bool Alta(Supervisor supervisor)
        {
            string query = "sp_Supervisor_Alta";
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            SqlParameter prm1 = new SqlParameter("@user_nombre", SqlDbType.NChar);
            prm1.Value = supervisor.Nombre;
            SqlParameter prm2 = new SqlParameter("@user_apellido", SqlDbType.NVarChar);
            prm2.Value = supervisor.Apellido;
            SqlParameter prm3 = new SqlParameter("@user_email", SqlDbType.NVarChar);
            prm3.Value = supervisor.Email;
            SqlParameter prm4 = new SqlParameter("@user_rol", SqlDbType.NVarChar);
            prm4.Value = supervisor.Rol;
            _al.Add(prm1);
            _al.Add(prm2);
            _al.Add(prm3);
            _al.Add(prm4);
            return _accesoParametro.Escribir(query, _al);
        }
        public bool Modificar(Supervisor supervisor)
        {
            string query = "sp_QuitarSupervisores";
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            SqlParameter prm1 = new SqlParameter("@user_id", SqlDbType.Int);
            prm1.Value = supervisor.Usuario_ID;
            SqlParameter prm2 = new SqlParameter("@user_email", SqlDbType.NVarChar);
            prm2.Value = supervisor.Email;
            SqlParameter prm3 = new SqlParameter("@user_apellido", SqlDbType.NChar);
            prm3.Value = supervisor.Apellido;
            SqlParameter prm4 = new SqlParameter("@user_nombre", SqlDbType.NChar);
            prm4.Value = supervisor.Nombre;
            _al.Add(prm1);
            _al.Add(prm2);
            _al.Add(prm3);
            _al.Add(prm4);
            return _accesoParametro.Escribir(query, _al);
        }
        public bool QuitarSupervisor(int id)
        {
            string query = "sp_QuitarSupervisores";
            _al = new ArrayList();
            _accesoParametro = new AccesoParametro();
            SqlParameter parameter = new SqlParameter("@user_id", SqlDbType.Int);
            parameter.Value = id;
            _al.Add(parameter);
            return _accesoParametro.Escribir(query,_al);
        }
        #region Iniciar supervisor si no existe
        public bool ExistenSupervisores()
        {
            string query = "sp_ExistenSupervisores";
            _accesoParametro = new AccesoParametro();
            DataTable table;
            table = _accesoParametro.leer(query,null);
            if (table.Rows.Count > 0) return true;
            else return false;
        }
        public bool CrearAdminInicial(string contraseña)
        {
            _accesoParametro = new AccesoParametro();
            string query = "sp_CrearAdminInicial";
            _al = new ArrayList();
            SqlParameter parameter = new SqlParameter("@contraseña", SqlDbType.NVarChar);
            parameter.Value = contraseña;
            _al.Add(parameter);
            return _accesoParametro.Escribir(query, _al);        
        }
        #endregion
    }
}
