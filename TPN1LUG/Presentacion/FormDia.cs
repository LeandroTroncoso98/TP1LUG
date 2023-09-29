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
    public partial class FormDia : Form
    {
        public FormDia()
        {
            InitializeComponent();
            oBLLDia = new BLLDia();
        }
        public FormDia(Cliente cliente)
        {
            _cliente = cliente;
            oBLLDia = new BLLDia();
            InitializeComponent();

        }
        public FormDia(Cliente cliente, Dia dia)
        {
            _dia = dia;
            _cliente = cliente;
            oBLLDia = new BLLDia();
            InitializeComponent();
        }
        private Dia _dia;
        private Cliente _cliente;
        private BLLDia oBLLDia;
        private void FormDia_Load(object sender, EventArgs e)
        {
            lblNombreCliente.Text = $"{_cliente.Nombre} {_cliente.Apellido}";
            if (_dia != null)
            {
                lblTitulo.Text = "Modificar día";
                txtDia.Text = _dia.Nombre;
                txtTipoEjercicio.Text = _dia.Tipo_Ejercicio;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtDia.Text) && !string.IsNullOrWhiteSpace(txtTipoEjercicio.Text))
                {

                    if (_dia == null)
                    {
                        if (!oBLLDia.ExisteDia(txtDia.Text,_cliente.oRutina.Rutina_ID))
                        {
                            //Creamos dia
                            Dia dia = new Dia();
                            dia.Nombre = txtDia.Text;
                            dia.Tipo_Ejercicio = txtTipoEjercicio.Text;
                            oBLLDia.CrearDia(dia, _cliente.oRutina.Rutina_ID);
                            MessageBox.Show("Se ha creado exitosamente.");
                            this.Close();
                        }
                        else MessageBox.Show($"El dia ya se encuentra en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        if (!oBLLDia.ExisteDia(txtDia.Text, _dia.Dia_ID))
                        {
                            //editamos dia
                            Dia dia = new Dia();
                            dia.Dia_ID = _dia.Dia_ID;
                            dia.Nombre = txtDia.Text;
                            dia.Tipo_Ejercicio = txtTipoEjercicio.Text;
                            oBLLDia.EditarDia(dia);
                            MessageBox.Show("Se ha editado exitosamente.");
                            this.Close();
                        }
                        else MessageBox.Show($"El dia ya se encuentra en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show($"Debe completar los campos para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo confirmar el dia.\nCausa{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
