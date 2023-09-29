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
            SqlTransaction tx;
            tx = oCnn.BeginTransaction();

            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = oCnn;
            cmd.CommandText = ConsultaSQL;
            cmd.Transaction = tx;
            try
            {
                int respuesta = cmd.ExecuteNonQuery();
                tx.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                tx.Rollback();
                throw ex;
            }
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
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { oCnn.Close(); }
            return ds;
        }
        public bool LeerScalar(string consulta)
        {
            oCnn.Open();
            cmd = new SqlCommand(consulta, oCnn);
            cmd.CommandType = CommandType.Text;
            try
            {
                int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                oCnn.Close();
                if (resultado > 0) return true;
                else return false;
            }
            catch (SqlException ex)
            { throw ex; }
        }
    }
}
