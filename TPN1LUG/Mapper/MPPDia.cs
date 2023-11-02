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
    public class MPPDia : IListable<Dia>, IBorrable
    {
        Acceso oDatos;
        MPPEjercicio _MPPEjercicio;
        public List<Dia> ListByIdByParent(int id)
        {
            oDatos = new Acceso();
            List<Dia> listaDias = new List<Dia>();
            DataTable table;
            _MPPEjercicio = new MPPEjercicio();
            string consultaSQL = $"SELECT a.Dia_ID,a.Nombre,a.Tipo_Ejercicio,a.Rutina_ID FROM Dia AS a WHERE a.Rutina_ID LIKE {id}";
            table = oDatos.Leer(consultaSQL);
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
            oDatos = new Acceso();
            string consultaSQL = $"INSERT INTO Dia(Nombre,Tipo_Ejercicio,Rutina_ID)VALUES('{dia.Nombre}','{dia.Tipo_Ejercicio}',{rutina_ID})";
            return oDatos.Escribir(consultaSQL);
        }
        public bool ExisteDia(string nombre, int rutina_ID = 0)
        {
            oDatos = new Acceso();
            List<Dia> listaDias = new List<Dia>();
            DataTable table;
            string consultaSQL = $"SELECT * FROM Dia WHERE Rutina_ID LIKE {rutina_ID} AND Nombre LIKE '{nombre}'";
            table = oDatos.Leer(consultaSQL);
            if (table.Rows.Count > 0) return true;
            else return false;
        }
        public bool EditarDia(Dia dia)
        {
            oDatos = new Acceso();
            string consultaSQL = $"UPDATE Dia SET Nombre = '{dia.Nombre}',Tipo_Ejercicio = '{dia.Tipo_Ejercicio}' WHERE Dia_ID LIKE {dia.Dia_ID}";
            return oDatos.Escribir(consultaSQL);
        }
        public bool Delete(int dia_ID)
        {
            oDatos = new Acceso();
            string consultaSQL = $"DELETE Dia WHERE Dia_ID LIKE {dia_ID}";
            return oDatos.Escribir(consultaSQL);
        }
        public bool ExisteDiaAsociado(int dia_id)
        {
            oDatos = new Acceso();
            return oDatos.LeerScalar($"SELECT COUNT(*) FROM Ejercicio WHERE Dia_ID LIKE {dia_id}");
        }
        public Dia LeerDia(int id)
        {
            oDatos = new Acceso();
            string consultaSQL = $"SELECT a.Dia_ID,a.Nombre,a.Tipo_Ejercicio FROM Dia AS a WHERE a.Dia_ID LIKE {id}";
            DataTable table;
            table = oDatos.Leer(consultaSQL);
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
