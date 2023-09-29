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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void iniciarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniciarSesion form = new IniciarSesion(this);
            form.MdiParent = this;
            form.Show();
        }

        private void consultarRutinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConsultarRutina form = new FormConsultarRutina();
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniciadorSupervisor IS = new IniciadorSupervisor();
            string pass = GeneradorContraseña.GenerarPassword();
            if (IS.Inicializar(Encriptador.GenerarMD5(pass)))
            {
                MessageBox.Show("Se ha creado el primer usuario supervisor:\n" +
                "Email: Admin1@.com\n" +
                $"Contraseña:{pass}"
                );
            }
        }
    }
}
