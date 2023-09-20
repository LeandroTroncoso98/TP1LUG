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
        }
        public AdministracionMenu(Profesor profesor)
        {
            InitializeComponent();
            administrarProfesoresToolStripMenuItem.Visible = false;
        }

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
    }
}
