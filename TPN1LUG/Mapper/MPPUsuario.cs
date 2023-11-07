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
    public class MPPUsuario : IBorrable
    {
        AccesoParametro _accesoParametro;
        private ArrayList _al;
        public bool Delete(int id)
        {
            _al = new ArrayList();
            string query = "sp_DeleteUsuario";
            _accesoParametro = new AccesoParametro();
            SqlParameter parameter = new SqlParameter("@user_id",SqlDbType.Int);
            parameter.Value = id;
            _al.Add(parameter);
            return _accesoParametro.Escribir(query, _al);
        }
        public bool VerificarMail(string email, int id = 0)
        {
            DataTable table;
            _al = new ArrayList();
            _accesoParametro = new AccesoParametro();
            string query = "sp_VerificarEmail";
            List<Usuario> usuarios = new List<Usuario>();
            SqlParameter parameter = new SqlParameter("@user_id", SqlDbType.Int);
            parameter.Value = id;
            _al.Add(parameter);
            
            table = _accesoParametro.leer(query, _al);
            if(table.Rows.Count > 0)
            {
                foreach(DataRow row in table.Rows)
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
