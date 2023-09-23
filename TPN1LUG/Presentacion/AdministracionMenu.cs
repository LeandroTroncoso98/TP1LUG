using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class AdministracionMenu : Form
    {
        public AdministracionMenu()
        {
            InitializeComponent();
        }
        public AdministracionMenu(Supervisor supervisor)
        {
            InitializeComponent();
            _empleado = supervisor;
        }
        public AdministracionMenu(Profesor profesor)
        {
            InitializeComponent();
            administrarProfesoresToolStripMenuItem.Visible = false;
            administrarSupervisoresToolStripMenuItem.Visible = false;
            _empleado = profesor;
        }
        private Empleado _empleado;
        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void administrarProfesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministrarProfesores adm = new AdministrarProfesores();
            adm.MdiParent = this;
            adm.Show();
        }
        private void AdministracionMenu_Load(object sender, EventArgs e)
        {
            lnombre.Text += _empleado.Nombre;
            lApellido.Text += _empleado.Apellido;
            lRol.Text += _empleado.Rol;
            lEmail.Text += _empleado.Email;
        }
        private void administrarSupervisoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministrarSupervisores adm = new AdministrarSupervisores();
            adm.MdiParent = this;
            adm.Show();
        }

        private void administrarClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ABMClientes aBMClientes = new ABMClientes();
            aBMClientes.MdiParent = this;
            aBMClientes.Show();
        }
    }
}
