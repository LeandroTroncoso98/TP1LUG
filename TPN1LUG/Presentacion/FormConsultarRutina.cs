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
    public partial class FormConsultarRutina : Form
    {
        public FormConsultarRutina()
        {
            InitializeComponent();
            oBLLCliente = new BLLCliente();
            _cliente = new Cliente();
            oBLLEjercicio = new BLLEjercicio();
            _ejercicio = new Ejercicio();
        }
        private BLLCliente oBLLCliente;
        private BLLEjercicio oBLLEjercicio;
        private Cliente _cliente;
        private Ejercicio _ejercicio;
        private Dia _dia;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    _cliente = oBLLCliente.GetCliente(txtEmail.Text);
                    if (_cliente != null)
                    {
                        lblNombre.Text = _cliente.Nombre;
                        lblApellido.Text = _cliente.Apellido;
                        lblPeso.Text = $"{_cliente.Peso} KG.";
                        if (_cliente.oRutina.Lista_Dia.Count > 0)
                        {
                            CargarCBDias();
                            PanelDia.Visible = true;
                        }
                    }
                    else
                    {
                        PanelDia.Visible = false;
                        lblNombre.Text = "";
                        lblApellido.Text = "";
                        lblPeso.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar su mail para continuar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar resultado.\nCausa: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CargarCBDias()
        {
            cbxDias.DataSource = _cliente.oRutina.Lista_Dia;
            cbxDias.ValueMember = "Dia_ID";
            cbxDias.DisplayMember = "Nombre";
            return true;
        }

        private void FormConsultarRutina_Load(object sender, EventArgs e)
        {
            cbxDias.DropDownStyle = ComboBoxStyle.DropDownList;
            dgvEjercicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEjercicios.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvEjercicios.MultiSelect = false;
            dgvEjercicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            PanelDia.Visible = false;
            btnGenerarReporte.Visible = false;

            this.reportViewer1.RefreshReport();
        }

        private void cbxDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CargarCBDias() == true)//Para que no genere una excepcion al traer la rutina del usuario 
                {
                    int dia_ID = (int)cbxDias.SelectedValue;
                    _dia = _cliente.oRutina.Lista_Dia.FirstOrDefault(m => m.Dia_ID == dia_ID);
                    List<Ejercicio> listaEjercicios = _dia.ListaEjercicio.ToList();
                    if (listaEjercicios != null)
                    {
                        CargarDGVEjercicios(listaEjercicios);
                        dgvEjercicios.Columns["Ejercicio_ID"].Visible = false;
                        dgvEjercicios.Columns["Descripcion_Adicional"].Visible = false;
                        if (listaEjercicios.Count > 0) btnGenerarReporte.Visible = true;
                    }
                    else MessageBox.Show("No posee ejercicios ese dia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarDGVEjercicios(List<Ejercicio> lista)
        {
            dgvEjercicios.DataSource = null;
            if (lista != null)
            {
                dgvEjercicios.DataSource = lista;
            }
        }


        private void dgvEjercicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _ejercicio = (Ejercicio)dgvEjercicios.CurrentRow.DataBoundItem;
                txtDescripcionGeneral.Text = _ejercicio.Descripcion_Adicional;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (_dia.ListaEjercicio.Count > 0)
            {
                reportViewer1.LocalReport.DataSources[0].Value = _dia.ListaEjercicio;
                reportViewer1.RefreshReport();
            }
        }
    }
}
