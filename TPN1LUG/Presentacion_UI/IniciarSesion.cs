using Negocio;
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

namespace Presentacion_UI
{
    public partial class IniciarSesion : Form
    {
        public IniciarSesion()
        {
            InitializeComponent();
            oDLLEmpleado = new BLLEmpleado();
            
        }
        private BLLEmpleado oDLLEmpleado;
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (VerificadorCampos.VerificarCampos(txtEmail, txtContra))
            {
                if (oDLLEmpleado.IniciarSesion(txtEmail.Text, txtContra.Text))
                {
                    Inicio pantallaPrincipal = new Inicio();
                    pantallaPrincipal.MdiParent = this;
                    pantallaPrincipal.Show();
                }
                else { MessageBox.Show("Usuario o contraseña incorrectos, por favor intente nuevamente", "Error al iniciar Sesion", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else
            {
                MessageBox.Show("Debe completar los campos para continuar", "Error al inicar sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void blaBlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("bla bla");
        }
    }
}
