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
    public class MPPUsuario
    {
        Acceso oDatos;
        public bool EliminarUsuario(int id)
        {
            string ConsultaSQL = $"DELETE FROM Usuario WHERE Usuario_ID = {id}";
            oDatos = new Acceso();
            return oDatos.Escribir(ConsultaSQL);
        }
        public bool VerificarMail(string email, int id = 0)
        {
            List<Usuario> usuarios = new List<Usuario>();
            DataTable table;
            oDatos = new Acceso();
            table = oDatos.Leer($"SELECT a.Usuario_ID,a.Email FROM Usuario AS a WHERE a.Usuario_ID NOT LIKE '{id}'");
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    Usuario usuario = new Usuario()
                    {
                        Usuario_ID = Convert.ToInt32(row[0]),
                        Email = row[1].ToString()
                    };
                    usuarios.Add(usuario);
                }
                return usuarios.Any(m => m.Email == email);
            }
            return false;
        }
    }
}
