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
using Utility;

namespace Presentacion
{
    public partial class FormEjercicio : Form
    {
        public FormEjercicio()
        {
            InitializeComponent();
            oBLLEjercicio = new BLLEjercicio();
        }
        public FormEjercicio(Dia dia, AdministrarRutina administrarRutina)
        {
            _dia = dia;
            InitializeComponent();
            oBLLEjercicio = new BLLEjercicio();
            _admRutina = administrarRutina;
        }
        public FormEjercicio(Ejercicio ejercicio, Dia dia, AdministrarRutina administrarRutina)
        {
            _ejercicio = ejercicio;
            _dia = dia;
            oBLLEjercicio = new BLLEjercicio();
            _admRutina = administrarRutina;
            InitializeComponent();
        }
        private Ejercicio _ejercicio;
        private Dia _dia;
        BLLEjercicio oBLLEjercicio;
        private AdministrarRutina _admRutina;
        private void FormEjercicio_Load(object sender, EventArgs e)
        {
            lblDiaNombre.Text = _dia.Nombre;
            if (_ejercicio != null)
            {
                lblTitulo.Text = "Modificar Ejercicio";
                btnConfirmar.Text = "Modificar";
                txtNombre.Text = _ejercicio.Nombre;
                txtDescAdicional.Text = _ejercicio.Descripcion_Adicional;
                txtNumeroSeries.Text = _ejercicio.Series.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtNumeroSeries.Text)){
                    if (VerificadorCampos.verificarCampoInt(txtNumeroSeries))
                    {
                        if (_ejercicio == null)
                        {
                            Ejercicio ejercicio = new Ejercicio();
                            ejercicio.Nombre = txtNombre.Text;
                            ejercicio.Series = Convert.ToInt32(txtNumeroSeries.Text);
                            ejercicio.Descripcion_Adicional = txtDescAdicional.Text;
                            oBLLEjercicio.CrearEjercicio(ejercicio, _dia.Dia_ID);
                            MessageBox.Show("Se ha creado con exíto");
                            _admRutina.CargarDGVEjercicios(oBLLEjercicio.LeerEjericicios(_dia.Dia_ID));
                            this.Close();
                        }
                        else
                        {
                            Ejercicio ejercicio = new Ejercicio();
                            ejercicio.Ejercicio_ID = _ejercicio.Ejercicio_ID;
                            ejercicio.Nombre = txtNombre.Text;
                            ejercicio.Series = Convert.ToInt32(txtNumeroSeries.Text);
                            ejercicio.Descripcion_Adicional = txtDescAdicional.Text;
                            oBLLEjercicio.EditarEjercicio(ejercicio);
                            MessageBox.Show("Se ha modificado con exito.");
                            _admRutina.CargarDGVEjercicios(oBLLEjercicio.LeerEjericicios(_dia.Dia_ID));
                            this.Close();
                        }
                    }
                    else MessageBox.Show($"El formato de series es incorrecto.", "Alerta error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show($"Los campos de nombre y series son obligatorios", "Alerta error.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error en el formulario.\nCausa:{ex}", "Alerta error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
