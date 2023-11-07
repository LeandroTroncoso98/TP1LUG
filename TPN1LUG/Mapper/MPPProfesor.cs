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
    public class MPPProfesor : IAltaModificable<Profesor>
    {
        AccesoParametro _accesoParametro;
        ArrayList _al;


        public bool Alta(Profesor profesor)
        {          
            string query = "sp_Profesor_Alta";
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            SqlParameter prm1 = new SqlParameter("@nombre_profesor", SqlDbType.NChar);
            prm1.Value = profesor.Nombre;
            _al.Add(prm1);
            SqlParameter prm2 = new SqlParameter("@apellido_profesor", SqlDbType.NChar);
            prm2.Value = profesor.Apellido;
            _al.Add(prm2);
            SqlParameter prm3 = new SqlParameter("@rol_profesor", SqlDbType.Int);
            prm3.Value = profesor.Rol;
            _al.Add(prm3);
            SqlParameter prm4 = new SqlParameter("@email_profesor", SqlDbType.NVarChar);
            prm4.Value = profesor.Email;
            _al.Add(prm4);
            SqlParameter prm5 = new SqlParameter("@contraseña_profesor", SqlDbType.NVarChar);
            prm5.Value = profesor.Contraseña;
            _al.Add(prm5);
            SqlParameter prm6 = new SqlParameter("@especializacion_profesor", SqlDbType.NVarChar);
            prm6.Value = profesor.Especializacion;
            _al.Add(prm6);
            return _accesoParametro.Escribir(query, _al);

        }
        public List<Profesor> ListaProfesores()
        {
            List<Profesor> listProfesores = new List<Profesor>();
            DataTable table;
            _accesoParametro = new AccesoParametro();
            string query = "sp_Profesor_ListaProfesores";
            table = _accesoParametro.leer(query, null);
            
            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    Profesor profe = new Profesor();
                    profe.Usuario_ID = Convert.ToInt32(fila[0]);
                    profe.Nombre = fila[1].ToString().Trim();
                    profe.Apellido = fila[2].ToString().Trim();
                    profe.Email = fila[3].ToString().Trim();
                    profe.Especializacion = fila[4].ToString().Trim();
                    profe.Rol = RolUsuario.Profesor;
                    listProfesores.Add(profe);
                }
            }
            else
            {
                listProfesores = null;
            }
            return listProfesores;
        }
        public bool Modificar(Profesor profesor)
        {
            string query = "sp_Profesor_Modificar";
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            SqlParameter prm1 = new SqlParameter("@user_id", SqlDbType.Int);
            prm1.Value = profesor.Usuario_ID;
            _al.Add(prm1);
            SqlParameter prm2 = new SqlParameter("@nombre_profesor", SqlDbType.NChar);
            prm2.Value = profesor.Nombre;
            _al.Add(profesor.Nombre);
            SqlParameter prm3 = new SqlParameter("@apellido_profesor", SqlDbType.NChar);
            prm3.Value = profesor.Apellido;
            _al.Add(prm3);
            SqlParameter prm4 = new SqlParameter("@email_profesor", SqlDbType.NVarChar);
            prm4.Value = profesor.Email;
            _al.Add(prm4);
            SqlParameter prm5 = new SqlParameter("@especializacion_profesor", SqlDbType.NVarChar);
            prm5.Value = profesor.Especializacion;
            _al.Add(prm5);
            return _accesoParametro.Escribir(query, _al);

        }
        public bool AscenderProfesor(int id)
        {
            string query = "sp_Profesor_AscenderProfesor";
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            SqlParameter prm1 = new SqlParameter("@user_id", SqlDbType.Int);
            prm1.Value = id;
            _al.Add(prm1);
            return _accesoParametro.Escribir(query, _al);
        }
    }
}
