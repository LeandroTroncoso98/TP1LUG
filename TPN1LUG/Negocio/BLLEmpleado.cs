using BE;
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
        public Empleado HabilitarSesion(string user,string pass)
        {
            DataTable table;
            oDatos = new Acceso();
            table = oDatos.Leer($"SELECT a.Usuario_ID,a.Nombre,a.Apellido,a.Rol,a.Email FROM Usuario AS a WHERE a.Email LIKE '{user}' AND a.Contraseña LIKE '{pass}'");
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
        public bool AltaProfesor(Profesor profesor)
        {
            string consultaSQL = $"INSERT INTO Usuario (Nombre,Apellido,Rol,Email,Contraseña,Especializacion)VALUES('{profesor.Nombre}','{profesor.Apellido}',2,'{profesor.Email}','123456','{profesor.Especializacion}')";
            oDatos = new Acceso();
            return oDatos.Escribir(consultaSQL);
        }
        public List<Profesor> ListaProfesores()
        {
            List<Profesor> listProfesores = new List<Profesor>();
            DataTable table;
            oDatos = new Acceso();
            table = oDatos.Leer($"SELECT a.Usuario_ID,a.Nombre,a.Apellido,a.Email,a.Especializacion FROM Usuario AS a WHERE a.Rol LIKE 2");
            if(table.Rows.Count > 0)
            {
                foreach(DataRow fila in table.Rows)
                {
                    Profesor profe = new Profesor();
                    profe.Usuario_ID = Convert.ToInt32(fila[0]);
                    profe.Nombre = fila[1].ToString();
                    profe.Apellido = fila[2].ToString();
                    profe.Email = fila[3].ToString();
                    profe.Especializacion = fila[4].ToString();
                    profe.Rol = RolUsuario.Profesor;
                    listProfesores.Add(profe);
                }
            }
            else
            {
                listProfesores = null;
            }
            return listProfesores;
        }
    }
}
