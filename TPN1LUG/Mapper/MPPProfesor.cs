using Abstraction;
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
    public class MPPProfesor : IAltaModificable<Profesor>
    {
        Acceso oDatos;
        public bool Alta(Profesor profesor)
        {
            string consultaSQL = $"INSERT INTO Usuario (Nombre,Apellido,Rol,Email,Contraseña,Especializacion)VALUES('{profesor.Nombre}','{profesor.Apellido}',{(int)profesor.Rol},'{profesor.Email}','{profesor.Contraseña}','{profesor.Especializacion}')";
            oDatos = new Acceso();
            return oDatos.Escribir(consultaSQL);
        }
        public List<Profesor> ListaProfesores()
        {
            List<Profesor> listProfesores = new List<Profesor>();
            DataTable table;
            oDatos = new Acceso();
            table = oDatos.Leer($"SELECT a.Usuario_ID,a.Nombre,a.Apellido,a.Email,a.Especializacion FROM Usuario AS a WHERE a.Rol LIKE 2");
            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    Profesor profe = new Profesor();
                    profe.Usuario_ID = Convert.ToInt32(fila[0]);
                    profe.Nombre = fila[1].ToString().Trim();
                    profe.Apellido = fila[2].ToString().Trim();
                    profe.Email = fila[3].ToString().Trim();
                    profe.Especializacion = fila[4].ToString().Trim();
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
        public bool Modificar(Profesor profesor)
        {
            string consultaSQL = $"UPDATE Usuario SET Nombre = '{profesor.Nombre}',Apellido = '{profesor.Apellido}',Email='{profesor.Email}',Especializacion='{profesor.Especializacion}' WHERE Usuario_ID LIKE {profesor.Usuario_ID}";
            oDatos = new Acceso();
            return oDatos.Escribir(consultaSQL);
        }
        public bool AscenderProfesor(int id)
        {
            string consultaSQL = $"UPDATE Usuario SET Rol = 1 WHERE Usuario_ID LIKE {id}";
            oDatos = new Acceso();
            return oDatos.Escribir(consultaSQL);
        }
    }
}
