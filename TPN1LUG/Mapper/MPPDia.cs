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
    public class MPPDia : IListable<Dia>, IBorrable
    {
        Acceso oDatos;
        MPPEjercicio _MPPEjercicio;
        private AccesoParametro _accesoParametro;
        private ArrayList _al;
        public List<Dia> ListByIdByParent(int id)
        {
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            string query = "sp_Dia_ListByIdByParent";
            List<Dia> listaDias = new List<Dia>();
            DataTable table;
            _MPPEjercicio = new MPPEjercicio();
            SqlParameter prm1 = new SqlParameter("@id_rutina", SqlDbType.Int);
            prm1.Value = id;
            _al.Add(prm1);
            table = _accesoParametro.leer(query, _al);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    Dia dia = new Dia();
                    dia.Dia_ID = Convert.ToInt32(row[0]);
                    dia.Nombre = Convert.ToString(row[1]);
                    dia.Tipo_Ejercicio = Convert.ToString(row[2]);
                    dia.ListaEjercicio = new List<Ejercicio>();
                    List<Ejercicio> listaEjercicio = _MPPEjercicio.ListByIdByParent(dia.Dia_ID);
                    if (listaEjercicio != null)
                    {
                        foreach (Ejercicio ejercicio in listaEjercicio)
                        {
                            dia.ListaEjercicio.Add(ejercicio);
                        }
                    }
                    listaDias.Add(dia);
                }
                return listaDias;
            }
            else return listaDias = null;
        }

        public bool CrearDia(Dia dia, int rutina_ID)
        {
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            string query = "sp_Dia_Crear";
            SqlParameter prm1 = new SqlParameter("@nombre_dia", SqlDbType.NVarChar);
            prm1.Value = dia.Nombre;
            _al.Add(prm1);
            SqlParameter prm2 = new SqlParameter("@tipoEjer_dia", SqlDbType.NVarChar);
            prm2.Value = dia.Tipo_Ejercicio;
            _al.Add(prm2);
            SqlParameter prm3 = new SqlParameter("@id_rutina", SqlDbType.Int);
            prm3.Value = rutina_ID;
            _al.Add(prm3);
            return _accesoParametro.Escribir(query, _al);
        }
        public bool ExisteDia(string nombre, int rutina_ID = 0)
        {
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            string query = "sp_Dia_Existe";
            SqlParameter prm1 = new SqlParameter("@nombre_dia", SqlDbType.NVarChar);
            prm1.Value = nombre;
            _al.Add(prm1);
            SqlParameter prm2 = new SqlParameter("@id_rutina", SqlDbType.Int);
            prm2.Value = rutina_ID;
            _al.Add(prm2);
            DataTable table;
            table = _accesoParametro.leer(query, _al);
            if (table.Rows.Count > 0) return true;
            else return false;
        }
        public bool EditarDia(Dia dia)
        {
            string query = "sp_Dia_Editar";
            _al = new ArrayList();
            _accesoParametro = new AccesoParametro();
            SqlParameter prm1 = new SqlParameter("@nombre_dia", SqlDbType.NVarChar);
            prm1.Value = dia.Nombre;
            _al.Add(prm1);
            SqlParameter prm2 = new SqlParameter("@tipoEjer_dia", SqlDbType.NVarChar);
            prm2.Value = dia.Tipo_Ejercicio;
            _al.Add(prm2);
            SqlParameter prm3 = new SqlParameter("@id_dia", SqlDbType.Int);
            prm3.Value = dia.Dia_ID;
            _al.Add(prm3);
            return _accesoParametro.Escribir(query, _al);
        }
        public bool Delete(int dia_ID)
        {
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            string query = "sp_Dia_Delete";
            SqlParameter prm1 = new SqlParameter("@id_dia", SqlDbType.Int);
            prm1.Value = dia_ID;
            _al.Add(prm1);
            return _accesoParametro.Escribir(query, _al);
        }
        public bool ExisteDiaAsociado(int dia_id)
        {
            string query = "sp_Dia_ExisteAsociado";
            _al = new ArrayList();
            _accesoParametro = new AccesoParametro();
            SqlParameter prm1 = new SqlParameter("@id_dia", SqlDbType.Int);
            prm1.Value = dia_id;
            _al.Add(prm1);
            return _accesoParametro.LeerScalar(query, _al);
        }
        public Dia LeerDia(int id)
        {
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            string query = "sp_Dia_leer";
            SqlParameter prm1 = new SqlParameter("@id_dia", SqlDbType.Int);
            prm1.Value = id;
            _al.Add(prm1);
            DataTable table;
            table = _accesoParametro.leer(query, _al);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                Dia dia = new Dia();
                dia.Dia_ID = Convert.ToInt32(row[0]);
                dia.Nombre = Convert.ToString(row[1]);
                dia.Tipo_Ejercicio = Convert.ToString(row[2]);
                return dia;
            }
            return null;
        }
    }
}
