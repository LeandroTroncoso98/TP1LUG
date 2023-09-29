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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                _cliente = oBLLCliente.GetCliente(txtEmail.Text);
                if(_cliente != null)
                {
                    lblNombre.Text = _cliente.Nombre;
                    lblApellido.Text = _cliente.Apellido;
                    lblPeso.Text = $"{_cliente.Peso} KG.";
                    if(_cliente.oRutina.Lista_Dia.Count > 0)
                    {
                        PanelDia.Visible = true;
                        CargarCBDias();
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
        private void CargarCBDias()
        {
            cbxDias.DataSource = _cliente.oRutina.Lista_Dia;
            cbxDias.ValueMember = "Dia_ID";
            cbxDias.DisplayMember = "Nombre";
        }

        private void FormConsultarRutina_Load(object sender, EventArgs e)
        {
            cbxDias.DropDownStyle = ComboBoxStyle.DropDownList;
            dgvEjercicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEjercicios.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvEjercicios.MultiSelect = false;
            dgvEjercicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            PanelDia.Visible = false;

        }

        private void cbxDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public void CargarDGVEjercicios(List<Ejercicio> lista)
        {
            dgvEjercicios.DataSource = null;
            dgvEjercicios.DataSource = lista;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            int dia_ID = (int)cbxDias.SelectedValue;
            List<Ejercicio> listaEjercicios = oBLLEjercicio.LeerEjericicios(dia_ID);
            CargarDGVEjercicios(listaEjercicios);
            dgvEjercicios.Columns["Ejercicio_ID"].Visible = false;
            dgvEjercicios.Columns["Descripcion_Adicional"].Visible = false;

        }

        private void dgvEjercicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _ejercicio = (Ejercicio)dgvEjercicios.CurrentRow.DataBoundItem;
                txtDescripcionGeneral.Text = _ejercicio.Descripcion_Adicional;

            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
