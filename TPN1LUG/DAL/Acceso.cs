using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Acceso
    {
        private SqlConnection oCnn = new SqlConnection(@"Data Source=DESKTOP-KB5GB1U\SQLSERVER;Initial Catalog=TP1LUG;Integrated Security=True");
        SqlCommand cmd;

        public DataTable Leer(string consulta)
        {
            DataTable tabla = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(consulta, oCnn);
                da.Fill(tabla);
            }
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally
            {
                oCnn.Close();
            }
            return tabla;
        }
        public bool Escribir(string ConsultaSQL)
        {
            oCnn.Open();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = oCnn;
            cmd.CommandText = ConsultaSQL;
            try
            {
                int respuesta = cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex) { throw ex; }
            finally { oCnn.Close(); }
        }
        public DataSet LeerTablas(string ConsultaSQL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(ConsultaSQL, oCnn);
                da.Fill(ds);
            }
            catch(SqlException ex) { throw ex; }
            catch(Exception ex) { throw ex; }
            finally { oCnn.Close(); }
            return ds;
        }
    }
}
