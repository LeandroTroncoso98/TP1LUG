using BE;
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

namespace Presentacion
{
    public partial class FormRutina : Form
    {
        public FormRutina()
        {
            InitializeComponent();
        }
        public FormRutina(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente;
            oBLLRutina = new BLLRutina();
        }
        private Cliente _cliente;
        BLLRutina oBLLRutina;
        private void FormRutina_Load(object sender, EventArgs e)
        {
            if (_cliente.oRutina == null)
            {
                btnConfirmar.Text = "Crear";
            }
            else
            {
                lblTitulo.Text = "Editar cliente";
                btnConfirmar.Text = "Editar";
                txtDescGeneral.Text = _cliente.oRutina.DescripcionGeneral;
                dtpFechaInicio.Value = _cliente.oRutina.Fecha_Inicio;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtDescGeneral.Text))
                {
                    if (_cliente.oRutina == null)
                    {
                        Rutina rutina = new Rutina();
                        rutina.Fecha_Inicio = dtpFechaInicio.Value;
                        rutina.DescripcionGeneral = txtDescGeneral.Text;
                        oBLLRutina.CrearRutina(rutina, _cliente.Usuario_ID);
                        MessageBox.Show($"Se ha creado la rutina de {_cliente.Nombre.Trim()} {_cliente.Apellido.Trim()}");
                        this.Close();
                    }
                    else
                    {
                        Rutina rutina = new Rutina();
                        rutina.Rutina_ID = _cliente.oRutina.Rutina_ID;
                        rutina.DescripcionGeneral = txtDescGeneral.Text;
                        rutina.Fecha_Inicio = dtpFechaInicio.Value;
                        oBLLRutina.EditarRutina(rutina);
                        MessageBox.Show($"Se ha editado la rutina de {_cliente.Nombre.Trim()} {_cliente.Apellido.Trim()}");
                        this.Close();
                    }
                }
                else MessageBox.Show("Debe completar los campos para continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al crear la rutina.\nCausa: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
