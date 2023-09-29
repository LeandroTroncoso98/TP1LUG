using BE;
using Negocio;
using Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace Presentacion
{
    public partial class IniciarSesion : Form
    {
        public IniciarSesion(Form form)
        {
            InitializeComponent();
            oBLLEmpleado = new BLLEmpleado();
            main = form;
        }
        private Form main;
        private BLLEmpleado oBLLEmpleado;

        private void button1_Click(object sender, EventArgs e)
        {
            if (VerificadorCampos.VerificarCamposIniciarSesion(txtEmail, txtContra))
            {
                if (oBLLEmpleado.IniciarSesion(txtEmail.Text, Encriptador.GenerarMD5(txtContra.Text)))
                {
                    Empleado empleado = oBLLEmpleado.HabilitarSesion(txtEmail.Text, Encriptador.GenerarMD5(txtContra.Text));
                    if(empleado != null)
                    {
                        if(empleado.Rol == RolUsuario.Supervisor)
                        {
                            Supervisor supervisor = new Supervisor();
                            supervisor.Usuario_ID = empleado.Usuario_ID;
                            supervisor.Nombre = empleado.Nombre;
                            supervisor.Apellido = empleado.Apellido;
                            supervisor.Rol = empleado.Rol;
                            supervisor.Email = empleado.Email;
                            AdministracionMenu administracionMenu = new AdministracionMenu(supervisor);
                            administracionMenu.Show();
                            this.Close();
                        }
                        else if (empleado.Rol == RolUsuario.Profesor)
                        {
                            Profesor profesor = new Profesor();
                            profesor.Usuario_ID = empleado.Usuario_ID;
                            profesor.Nombre = empleado.Nombre;
                            profesor.Apellido = empleado.Apellido;
                            profesor.Rol = empleado.Rol;
                            profesor.Email = empleado.Email;
                            AdministracionMenu administracionMenu = new AdministracionMenu(profesor);
                            administracionMenu.Show();
                            this.Close();
                        }
                        
                    }
                }
                else { MessageBox.Show("Usuario o contraseña incorrectos, por favor intente nuevamente", "Error al iniciar Sesion", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else
            {
                MessageBox.Show("Debe completar los campos para continuar", "Error al inicar sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
