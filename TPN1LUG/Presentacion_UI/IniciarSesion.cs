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

namespace Presentacion_UI
{
    public partial class IniciarSesion : Form
    {
        public IniciarSesion()
        {
            InitializeComponent();
            oBLLEmpleado = new BLLEmpleado();

        }
        BLLEmpleado oBLLEmpleado;

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtContra.Text) && !string.IsNullOrEmpty(txtEmail.Text))
                {
                    if (oBLLEmpleado.IniciarSesion(txtEmail.Text, txtContra.Text))
                    {
                        AdministrarClientes admClientes = new AdministrarClientes();

                        admClientes.Show();
                    }
                    else MessageBox.Show("Usuario Incorrecto");
                }
            }
            catch(Exception ex) { throw ex; }
        }
    }
}
