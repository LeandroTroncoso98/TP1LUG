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
    public class MPPRutina
    {
        Acceso oDatos;
        MPPDia _MPPDia;


        public Rutina traerRutina(Cliente cliente)
        {
            oDatos = new Acceso();
            DataTable table;
            _MPPDia = new MPPDia();
            string consultaSQL = $"SELECT a.Rutina_ID,a.Fecha_Inicio,a.Descripcion_General,a.Cliente_id FROM Rutina AS a WHERE a.Cliente_id LIKE (SELECT b.Usuario_ID FROM Usuario AS b WHERE b.Email LIKE '{cliente.Email}')";
            try
            {
                table = oDatos.Leer(consultaSQL);
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    Rutina rutina = new Rutina();
                    rutina.Rutina_ID = Convert.ToInt32(row[0]);
                    rutina.Fecha_Inicio = Convert.ToDateTime(row[1]);
                    rutina.DescripcionGeneral = Convert.ToString(row[2]);
                    rutina.Lista_Dia = new List<Dia>();
                    List<Dia> listaDias = _MPPDia.LeerDias(rutina.Rutina_ID);
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
            string consultaSQL = $"INSERT INTO Rutina (Fecha_Inicio,Cliente_id,Descripcion_General)VALUES('{rutina.Fecha_Inicio.ToString("yyyy-MM-dd")}',{usuarioID},'{rutina.DescripcionGeneral}')";
            oDatos = new Acceso();
            return oDatos.Escribir(consultaSQL);
        }
        public bool EditarRutina(Rutina rutina)
        {
            string consultaSQL = $"UPDATE Rutina SET Descripcion_General = '{rutina.DescripcionGeneral}',Fecha_Inicio='{rutina.Fecha_Inicio.ToString("yyyy-MM-dd")}' WHERE Rutina_ID LIKE {rutina.Rutina_ID}";
            oDatos = new Acceso();
            return oDatos.Escribir(consultaSQL);
        }
        public bool ExisteRutinaAsociada(int rutina_id)
        {
            oDatos = new Acceso();
            return oDatos.LeerScalar($"SELECT COUNT(*) FROM Dia WHERE Rutina_ID LIKE {rutina_id}");
        }
        public bool EliminarRutina(int rutina_ID)
        {
            oDatos = new Acceso();
            return oDatos.Escribir($"DELETE FROM Rutina WHERE Rutina_ID LIKE {rutina_ID}");
        }
    }
}
