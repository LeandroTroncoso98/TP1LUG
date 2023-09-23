﻿using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BLLCliente : BLLUsuario
    {
        Acceso oDatos;
        public List<Cliente> listarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            oDatos = new Acceso();
            DataTable table;
            table = oDatos.Leer($"SELECT a.Usuario_ID,a.Nombre,a.Apellido,a.Email,a.Telefono,a.Peso, a.Fecha_Nacimiento, a.Rol,b.Usuario_ID AS Profesor_ID,b.Nombre AS Profeosor, b.Especializacion FROM Usuario AS a LEFT JOIN Usuario AS b ON a.Empleado_ID = b.Usuario_ID WHERE a.Rol LIKE 3");
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
        public bool CrearCliente(Cliente cliente)
        {
            string consultaSQL = $"INSERT INTO Usuario (Nombre,Apellido,Rol,Email,Telefono,Peso,Fecha_Nacimiento,Empleado_ID)VALUES('{cliente.Nombre}','{cliente.Apellido}',{(int)cliente.Rol},'{cliente.Email}',{cliente.Telefono},{cliente.Peso},'{cliente.Fecha_Nacimiento.ToString("yyyy-MM-dd")}',{cliente.oProfesor.Usuario_ID})";
            oDatos = new Acceso();
            return oDatos.Escribir(consultaSQL);
        }
        public bool EditarCliente(Cliente cliente)
        {
            string consultaSQL = $"UPDATE Usuario SET Nombre = '{cliente.Nombre}',Apellido = '{cliente.Apellido}',Email = '{cliente.Email}',Telefono = {cliente.Telefono},Peso = '{cliente.Peso}',Fecha_Nacimiento = '{cliente.Fecha_Nacimiento.ToString("yyyy-MM-dd")}',Empleado_ID = {cliente.oProfesor.Usuario_ID} WHERE Usuario_ID LIKE {cliente.Usuario_ID}";
            oDatos = new Acceso();
            return oDatos.Escribir(consultaSQL);
        }

    }
}

