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
    public class MPPRutina : IBorrable
    {
        Acceso oDatos;
        MPPDia _MPPDia;
        private AccesoParametro _accesoParametro;
        private ArrayList _al;

        public Rutina traerRutina(Cliente cliente)
        {
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            SqlParameter parameter = new SqlParameter("@email_cliente", SqlDbType.NVarChar);
            parameter.Value = cliente.Email;
            _al.Add(parameter);
            DataTable table;
            _MPPDia = new MPPDia();
            string query = "sp_Rutina_TraerRutina";
            try
            {
                table = _accesoParametro.leer(query, _al);
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    Rutina rutina = new Rutina();
                    rutina.Rutina_ID = Convert.ToInt32(row[0]);
                    rutina.Fecha_Inicio = Convert.ToDateTime(row[1]);
                    rutina.DescripcionGeneral = Convert.ToString(row[2]);
                    rutina.Lista_Dia = new List<Dia>();
                    List<Dia> listaDias = _MPPDia.ListByIdByParent(rutina.Rutina_ID);
                    if (listaDias != null)
                    {
                        foreach (Dia dia in listaDias)
                        {
                            rutina.Lista_Dia.Add(dia);
                        }
                    }
                    return rutina;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CrearRutina(Rutina rutina, int usuarioID)
        {
            string query = "sp_Rutina_CrearRutina";
            _al = new ArrayList();
            SqlParameter prm1 = new SqlParameter("@FechaInicio_Rutina",SqlDbType.DateTime);
            prm1.Value = rutina.Fecha_Inicio;
            SqlParameter prm2 = new SqlParameter("@user_id", SqlDbType.Int);
            prm2.Value = usuarioID;
            SqlParameter prm3 = new SqlParameter("@Descrip_Rutina", SqlDbType.NVarChar);
            _al.Add(prm1);
            _al.Add(prm2);
            _al.Add(prm3);
            return _accesoParametro.Escribir(query, _al);
        }
        public bool EditarRutina(Rutina rutina)
        {
            string query = "sp_Rutina_EditarRutina";
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            SqlParameter prm1 = new SqlParameter("@FechaInicio_Rutina", SqlDbType.DateTime);
            prm1.Value = rutina.Fecha_Inicio;
            SqlParameter prm2 = new SqlParameter("@Rutina_id", SqlDbType.Int);
            prm2.Value = rutina.Rutina_ID;
            SqlParameter prm3 = new SqlParameter("@Descrip_Rutina", SqlDbType.NVarChar);
            prm3.Value = rutina.DescripcionGeneral;
            _al.Add(prm1);
            _al.Add(prm2);
            _al.Add(prm3);
            return _accesoParametro.Escribir(query, _al);
        }
        public bool ExisteRutinaAsociada(int rutina_id)
        {
            string query = "sp_Rutina_ExisteAsociada";
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            SqlParameter prm1 = new SqlParameter("@Rutina_id", SqlDbType.Int);
            prm1.Value = rutina_id;
            _al.Add(prm1);
            return _accesoParametro.LeerScalar(query, _al);

        }
        public bool Delete(int rutina_ID)
        {
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            string query = "sp_Rutina_Delete";
            SqlParameter parameter = new SqlParameter("@Rutina_id", SqlDbType.Int);
            parameter.Value = rutina_ID;
            _al.Add(parameter);
            return _accesoParametro.Escribir(query, _al);
        }
    }
}
