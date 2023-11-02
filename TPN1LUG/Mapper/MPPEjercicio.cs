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
    public class MPPEjercicio : IListable<Ejercicio>, IBorrable
    {
        Acceso oDatos;
        public List<Ejercicio> ListByIdByParent(int id)
        {
            oDatos = new Acceso();
            DataTable table;
            List<Ejercicio> listaEjercicios = new List<Ejercicio>();
            string consultaSQL = $"SELECT a.Ejercicio_ID,a.Nombre,a.Series,a.Descripcion_Adicional FROM Ejercicio AS a WHERE a.Dia_ID LIKE {id}";
            table = oDatos.Leer(consultaSQL);
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
            string consultaSQL = $"INSERT INTO Ejercicio (Nombre,Series,Descripcion_Adicional,Dia_ID)VALUES('{ejercicio.Nombre}',{ejercicio.Series},'{ejercicio.Descripcion_Adicional}',{dia_ID})";
            oDatos = new Acceso();
            return oDatos.Escribir(consultaSQL);
        }
        public bool EditarEjercicio(Ejercicio ejercicio)
        {
            string consultaSQL = $"UPDATE Ejercicio SET Nombre = '{ejercicio.Nombre}',Series = {ejercicio.Series},Descripcion_Adicional='{ejercicio.Descripcion_Adicional}' WHERE Ejercicio_ID LIKE {ejercicio.Ejercicio_ID}";
            oDatos = new Acceso();
            return oDatos.Escribir(consultaSQL);
        }
        public bool Delete(int ejercicio_id)
        {
            string consultaSQL = $"DELETE FROM Ejercicio WHERE Ejercicio_ID LIKE {ejercicio_id}";
            oDatos = new Acceso();
            return oDatos.Escribir(consultaSQL);
        }
    }
}
