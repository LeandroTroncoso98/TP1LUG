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
    public class MPPEjercicio : IListable<Ejercicio>, IBorrable
    {
        private AccesoParametro _accesoParametro;
        private ArrayList _al;
        public List<Ejercicio> ListByIdByParent(int id)
        {
            _al = new ArrayList();
            _accesoParametro = new AccesoParametro();
            DataTable table;
            List<Ejercicio> listaEjercicios = new List<Ejercicio>();
            string query = "sp_Ejercicio_ListByIdByParent";
            SqlParameter prm1 = new SqlParameter("@dia_id", SqlDbType.Int);
            prm1.Value = id;
            _al.Add(prm1);
            table = _accesoParametro.leer(query, _al);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    Ejercicio ejercicio = new Ejercicio();
                    ejercicio.Ejercicio_ID = Convert.ToInt32(row[0]);
                    ejercicio.Nombre = Convert.ToString(row[1]);
                    ejercicio.Series = Convert.ToInt32(row[2]);
                    ejercicio.Descripcion_Adicional = Convert.ToString(row[3]);
                    listaEjercicios.Add(ejercicio);
                }
                return listaEjercicios;
            }
            else return null;
        }
        public bool CrearEjercicio(Ejercicio ejercicio, int dia_ID)
        {
            string query = "sp_Ejercicio_CrearEjercicio";
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            SqlParameter prm1 = new SqlParameter("@nombre_eje", SqlDbType.NVarChar);
            prm1.Value = ejercicio.Nombre;
            _al.Add(prm1);
            SqlParameter prm2 = new SqlParameter("@series_eje", SqlDbType.Int);
            prm2.Value = ejercicio.Series;
            _al.Add(prm2);
            SqlParameter prm3 = new SqlParameter("@descrip_eje", SqlDbType.NVarChar);
            prm3.Value = ejercicio.Descripcion_Adicional;
            _al.Add(prm3);
            SqlParameter prm4 = new SqlParameter("@id_dia", SqlDbType.Int);
            prm4.Value = dia_ID;
            _al.Add(prm4);
            return _accesoParametro.Escribir(query, _al);
        }
        public bool EditarEjercicio(Ejercicio ejercicio)
        {
            string query = "sp_Ejercicio_Editar";
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            SqlParameter prm1 = new SqlParameter("@nombre_eje", SqlDbType.NVarChar);
            prm1.Value = ejercicio.Nombre;
            _al.Add(prm1);
            SqlParameter prm2 = new SqlParameter("@series_eje", SqlDbType.Int);
            prm2.Value = ejercicio.Series;
            _al.Add(prm2);
            SqlParameter prm3 = new SqlParameter("@descrip_eje", SqlDbType.NVarChar);
            prm3.Value = ejercicio.Descripcion_Adicional;
            _al.Add(prm3);
            SqlParameter prm4 = new SqlParameter("@id_eje", SqlDbType.Int);
            prm4.Value = ejercicio.Ejercicio_ID;
            _al.Add(prm4);
            return _accesoParametro.Escribir(query, _al);
        }
        public bool Delete(int ejercicio_id)
        {
            string query = "sp_Ejercicio_Delete";
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            SqlParameter prm1 = new SqlParameter("@id_eje", SqlDbType.Int);
            prm1.Value = ejercicio_id;
            _al.Add(prm1);
            return _accesoParametro.Escribir(query, _al);

        }
    }
}
