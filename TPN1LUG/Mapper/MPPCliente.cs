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
    public class MPPCliente : MPPUsuario, IAltaModificable<Cliente>
    {
        Acceso oDatos;
        MPPRutina _MPPRutina;
        private AccesoParametro _accesoParametro;
        private ArrayList _al;
        public List<Cliente> listarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            _accesoParametro = new AccesoParametro();
            string query = "sp_Clientes_Listar";
            DataTable table;
            table = _accesoParametro.leer(query, null);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    Cliente cliente = new Cliente();
                    cliente.Usuario_ID = Convert.ToInt32(row[0]);
                    cliente.Nombre = row[1].ToString();
                    cliente.Apellido = row[2].ToString();
                    cliente.Email = row[3].ToString();
                    cliente.Telefono = Convert.ToInt32(row[4]);
                    cliente.Peso = row[5].ToString();
                    cliente.Fecha_Nacimiento = Convert.ToDateTime(row[6]);
                    cliente.Rol = (RolUsuario)row[7];
                    Profesor oProf = new Profesor();
                    oProf.Usuario_ID = Convert.ToInt32(row[8]);
                    oProf.Nombre = row[9].ToString();
                    oProf.Rol = RolUsuario.Profesor;
                    cliente.oProfesor = oProf;
                    clientes.Add(cliente);
                }
                return clientes;
            }
            else
                return clientes = null;
        }
        public bool Alta(Cliente cliente)
        {
            string query = "sp_Clientes_Alta";
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            SqlParameter prm1 = new SqlParameter("@nombre_cli", SqlDbType.NChar);
            prm1.Value = cliente.Nombre;
            _al.Add(prm1);
            SqlParameter prm2 = new SqlParameter("@apellido_cli", SqlDbType.NChar);
            prm2.Value = cliente.Apellido;
            _al.Add(prm2);
            SqlParameter prm3 = new SqlParameter("@rol_cli", SqlDbType.Int);
            prm3.Value = cliente.Rol;
            _al.Add(prm3);
            SqlParameter prm4 = new SqlParameter("@email_cli", SqlDbType.NVarChar);
            prm4.Value = cliente.Email;
            _al.Add(prm4);
            SqlParameter prm5 = new SqlParameter("@telefono_cli", SqlDbType.Int);
            prm5.Value = cliente.Telefono;
            _al.Add(prm5);
            SqlParameter prm6 = new SqlParameter("@peso_cli", SqlDbType.NVarChar);
            prm6.Value = cliente.Peso;
            _al.Add(prm6);
            SqlParameter prm7 = new SqlParameter("@nacimiento_cli", SqlDbType.DateTime);
            prm7.Value = cliente.Fecha_Nacimiento;
            _al.Add(prm7);
            SqlParameter prm8 = new SqlParameter("@id_profesor", SqlDbType.Int);
            prm8.Value = cliente.oProfesor.Usuario_ID;
            _al.Add(prm8);
            return _accesoParametro.Escribir(query, _al);
        }
        public bool Modificar(Cliente cliente)
        {
            string query = "sp_Clientes_Modificar";
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            SqlParameter prm1 = new SqlParameter("@nombre_cli", SqlDbType.NChar);
            prm1.Value = cliente.Nombre;
            _al.Add(prm1);
            SqlParameter prm2 = new SqlParameter("@apellido_cli", SqlDbType.NChar);
            prm2.Value = cliente.Apellido;
            _al.Add(prm2);
            SqlParameter prm3 = new SqlParameter("@id_cli", SqlDbType.Int);
            prm3.Value = cliente.Usuario_ID;
            _al.Add(prm3);
            SqlParameter prm4 = new SqlParameter("@email_cli", SqlDbType.NVarChar);
            prm4.Value = cliente.Email;
            _al.Add(prm4);
            SqlParameter prm5 = new SqlParameter("@telefono_cli", SqlDbType.Int);
            prm5.Value = cliente.Telefono;
            _al.Add(prm5);
            SqlParameter prm6 = new SqlParameter("@peso_cli", SqlDbType.NVarChar);
            prm6.Value = cliente.Peso;
            _al.Add(prm6);
            SqlParameter prm7 = new SqlParameter("@nacimiento_cli", SqlDbType.DateTime);
            prm7.Value = cliente.Fecha_Nacimiento;
            _al.Add(prm7);
            SqlParameter prm8 = new SqlParameter("@id_profesor", SqlDbType.Int);
            prm8.Value = cliente.oProfesor.Usuario_ID;
            _al.Add(prm8);
            return _accesoParametro.Escribir(query, _al);
        }

        public Cliente GetCliente(string email)
        {
            _accesoParametro = new AccesoParametro();
            _al = new ArrayList();
            string query = "sp_Clientes_Get";
            SqlParameter prm1 = new SqlParameter("@email_cli", SqlDbType.NVarChar);
            prm1.Value = email;
            _al.Add(prm1);
            DataTable table;
            table = _accesoParametro.leer(query, _al);
            if (table.Rows.Count == 1)
            {
                DataRow row = table.Rows[0];
                Cliente cliente = new Cliente();
                cliente.Usuario_ID = Convert.ToInt32(row[0]);
                cliente.Nombre = Convert.ToString(row[1]);
                cliente.Apellido = Convert.ToString(row[2]);
                cliente.Rol = (RolUsuario)row[3];
                cliente.Email = Convert.ToString(row[4]);
                cliente.Telefono = Convert.ToInt32(row[5]);
                cliente.Peso = Convert.ToString(row[6]);
                cliente.Fecha_Nacimiento = Convert.ToDateTime(row[7]);
                cliente.Edad = Cliente.CalcularEdad(cliente.Fecha_Nacimiento);
                _MPPRutina = new MPPRutina();
                cliente.oRutina = new Rutina();
                cliente.oRutina = _MPPRutina.traerRutina(cliente);
                return cliente;
            }
            else return null;
        }
    }
}
