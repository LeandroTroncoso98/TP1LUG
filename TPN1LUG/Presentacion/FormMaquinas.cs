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
    public partial class FormMaquinas : Form
    {
        public FormMaquinas()
        {
            _verificador = new VerificarRegexMaquina();
            _bllMaquina = new BLLMaquina();
            InitializeComponent();
        }
        private VerificarRegexMaquina _verificador;
        private BLLMaquina _bllMaquina;
        private Maquina _maquina;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_verificador.CheckForm(txtNombre, txtCantidad, txtMaximoPeso))
                {
                    Maquina maquina = new Maquina(txtNombre.Text, int.Parse(txtMaximoPeso.Text), int.Parse(txtCantidad.Text));
                    if (_bllMaquina.Agregar(maquina))
                    {
                        MessageBox.Show("Se agrego la maquina al inventario.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                        LimpiarTBox();
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error.\nCausa: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarTBox()
        {
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtMaximoPeso.Text = "";
        }
        private void CargarGrilla()
        {
            dataGridView1.DataSource = null;
            List<Maquina> maquinas = _bllMaquina.Leer();
            if (maquinas != null)
                dataGridView1.DataSource = maquinas;
        }

        private void FormMaquinas_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_verificador.BuscarValido(txtBuscar))
                {
                    List<Maquina> maquinas = _bllMaquina.Buscar(txtBuscar.Text);
                    if (maquinas != null)
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = maquinas;
                    }
                    else
                    {
                        MessageBox.Show("No se encontro ningun maquina con ese atributo", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        CargarGrilla();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error.\nCausa:{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _maquina = (Maquina)dataGridView1.CurrentRow.DataBoundItem;

            }catch(Exception ex){
                MessageBox.Show($"Ha ocurrido un error.\nCausa:{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if(_maquina != null)
                {
                    DialogResult result = MessageBox.Show("Desea eliminar la maquina?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (_bllMaquina.Borrar(_maquina))
                        {
                            MessageBox.Show("Se ha eliminado con exito!");
                            CargarGrilla();
                            _maquina = null;
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Debe seleccionar una maquina para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error.\nCausa:{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
