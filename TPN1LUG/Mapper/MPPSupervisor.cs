using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class MPPSupervisor
    {
        Acceso oDatos;
        public List<Supervisor> ListaSupervisores()
        {
            List<Supervisor> supervisores = new List<Supervisor>();
            DataTable table;
            oDatos = new Acceso();
            table = oDatos.Leer($"SELECT a.Usuario_ID,a.Nombre,a.Apellido,a.Rol,a.Email FROM Usuario AS a WHERE a.Rol LIKE 1");
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
        public bool AltaSupervisor(Supervisor supervisor)
        {
            string consultaSQL = $"INSERT INTO Usuario (Nombre,Apellido,Email,Rol,Contraseña)VALUES('{supervisor.Nombre}','{supervisor.Apellido}','{supervisor.Email}',{(int)supervisor.Rol},'123456')";
            oDatos = new Acceso();
            return oDatos.Escribir(consultaSQL);
        }
        public bool ModificarSupervisor(Supervisor supervisor)
        {
            string consultaSQL = $"UPDATE Usuario SET Nombre ='{supervisor.Nombre}',Apellido='{supervisor.Apellido}',Email='{supervisor.Email}' WHERE Usuario_ID LIKE {supervisor.Usuario_ID}";
            oDatos = new Acceso();
            return oDatos.Escribir(consultaSQL);
        }
        public bool QuitarSupervisor(int id)
        {
            string consultaSQL = $"UPDATE Usuario SET Rol = 2 WHERE Usuario_ID LIKE {id}";
            oDatos = new Acceso();
            return oDatos.Escribir(consultaSQL);
        }
        #region Iniciar supervisor si no existe
        public bool ExistenSupervisores()
        {
            string consultaSQL = "SELECT * FROM Usuario WHERE Rol LIKE 1";
            oDatos = new Acceso();
            DataTable table;
            table = oDatos.Leer(consultaSQL);
            if (table.Rows.Count > 0) return true;
            else return false;
        }
        public bool CrearAdminInicial(string contraseña)
        {
            string consultasql = $"INSERT INTO Usuario (Nombre,Apellido,Email,Rol,Contraseña,Especializacion)VALUES('Admin1','Admin','Admin1@.com',1,'{contraseña}','Jefe')";
            oDatos = new Acceso();
            return oDatos.Escribir(consultasql);
        }
        #endregion
    }
}
