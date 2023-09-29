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
    public partial class AdministrarRutina : Form
    {
        public AdministrarRutina()
        {
            InitializeComponent();
            oBLLCliente = new BLLCliente();
            oBLLDia = new BLLDia();
            oBLLEjercicio = new BLLEjercicio();
            oBLLRutina = new BLLRutina();
        }
        BLLCliente oBLLCliente;
        BLLDia oBLLDia;
        BLLRutina oBLLRutina;
        BLLEjercicio oBLLEjercicio;
        Cliente _cliente;
        Ejercicio _ejercicio;
        Dia _dia;
        private void btnBuscarRutina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtEmailRutina.Text))
                {
                    _cliente = oBLLCliente.GetCliente(txtEmailRutina.Text);
                    if (_cliente != null)
                    {
                        if (_cliente.oRutina != null)
                        {
                            panelRutina.Visible = true;
                            lblCliente.Text = $"{_cliente.Nombre} {_cliente.Apellido}";
                            lblFecha_Comienzo.Text = _cliente.oRutina.Fecha_Inicio.ToString("dd-MM-yyyy");
                            lblDescripcionGeneral.Text = _cliente.oRutina.DescripcionGeneral;
                            if(_cliente.oRutina.Lista_Dia.Count > 0)
                            {
                                PanelDia.Visible = true;
                                CargarCBDia();
                            }
                            else
                            {
                                PanelDia.Visible = false;
                            }
                        }
                        else
                        {
                            DialogResult resultado = MessageBox.Show("El cliente no posee rutina, ¿desea crear una? ", "Consulta", MessageBoxButtons.YesNo);
                            if (resultado == DialogResult.Yes)
                            {
                                FormRutina formRutina = new FormRutina(_cliente);
                                formRutina.Show();
                            }                           
                            panelRutina.Visible = false;
                            PanelDia.Visible = false;
                        }
                    }
                    else MessageBox.Show("No existe el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else MessageBox.Show("Debe ingresar un mail valido.", "Error al traer rutina", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error al traer la rutina.\nCausa: {ex}", "Error al traer rutina", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CargarCBDia()
        {
            cbxDias.DataSource = oBLLDia.LeerDias(_cliente.oRutina.Rutina_ID);
            cbxDias.ValueMember = "Dia_ID";
            cbxDias.DisplayMember = "Nombre";
        }
        private void AdministrarRutina_Load(object sender, EventArgs e)
        {
            FLPDescGeneral.FlowDirection = FlowDirection.TopDown;
            panelRutina.Visible = false;
            PanelDia.Visible = false;
            PanelEjercio.Visible = false;
            lblDescripcionGeneral.AutoSize = true;
            FLPDescGeneral.Controls.Add(lblDescripcionGeneral);
            cbxDias.DropDownStyle = ComboBoxStyle.DropDownList;
            dgvEjercicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEjercicios.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvEjercicios.MultiSelect = false;
            dgvEjercicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnCambiarRutina_Click(object sender, EventArgs e)
        {
            FormRutina formRutina = new FormRutina(_cliente);
            formRutina.Show();
        }

        private void btnAgregarDias_Click(object sender, EventArgs e)
        {
            FormDia dia = new FormDia(_cliente);
            dia.Show();
        }


        private void cbxDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDiaDe.Text = _cliente.oRutina.Lista_Dia[cbxDias.SelectedIndex].Tipo_Ejercicio;
            PanelEjercio.Visible = false;
        }
        public void CargarDGVEjercicios(List<Ejercicio> lista)
        {
            dgvEjercicios.DataSource = null;
            dgvEjercicios.DataSource = lista;
            if (dgvEjercicios.Rows.Count > 0) PanelEjercio.Visible = true;
            else PanelEjercio.Visible = false;
            dgvEjercicios.Columns["Ejercicio_ID"].Visible = false;
            dgvEjercicios.Columns["Descripcion_Adicional"].Visible = false;

        }
        private void btnModificarDia_Click(object sender, EventArgs e)
        {
            FormDia formDia = new FormDia(_cliente,_cliente.oRutina.Lista_Dia[cbxDias.SelectedIndex]);
            formDia.Show();
        }

        private void btnEliminarDia_Click(object sender, EventArgs e)
        {
            try
            {
                if (!oBLLDia.ExisteDiaAsociado((int)cbxDias.SelectedValue))
                {
                    oBLLDia.EliminarDia((int)cbxDias.SelectedValue);
                    MessageBox.Show("Se ha elíminado con exíto.");
                    _cliente.oRutina.Lista_Dia = oBLLDia.LeerDias(_cliente.oRutina.Rutina_ID);
                    if (_cliente.oRutina.Lista_Dia != null)
                    {
                        CargarCBDia();
                    }
                    else PanelDia.Visible = false;
                }
                else MessageBox.Show($"No se puede eliminar el dia ya que tiene ejercicios asociados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error al eliminar el dia.\nCausa: {ex}", "Error al traer rutina", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrarEjericicios_Click(object sender, EventArgs e)
        {
            int dia_id = (int)cbxDias.SelectedValue;
            List<Ejercicio> listaEjercicios = oBLLEjercicio.LeerEjericicios(dia_id);
            if (listaEjercicios != null)
            {
                CargarDGVEjercicios(listaEjercicios);
                PanelEjercio.Visible = true;
            }
            else
            {
                PanelEjercio.Visible = false;
            }
        }

        private void dgvEjercicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                _ejercicio = (Ejercicio)dgvEjercicios.CurrentRow.DataBoundItem;
                lblDescripcionEJercicio.Text = _ejercicio.Descripcion_Adicional;
            }catch(Exception ex)
            {
                MessageBox.Show($"No se ha podido seleccionar el ejercicio.\nCausa:{ex}", "Error",MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void btnAgregarEjercicio_Click(object sender, EventArgs e)
        {
            _dia = oBLLDia.LeerDia((int)cbxDias.SelectedValue);
            FormEjercicio ejercicio = new FormEjercicio(_dia, this);
            ejercicio.ShowDialog();
        }

        private void btnEditarEjercicio_Click(object sender, EventArgs e)
        {
            _dia = oBLLDia.LeerDia((int)cbxDias.SelectedValue);
            FormEjercicio ejercicio = new FormEjercicio(_ejercicio,_dia, this);
            ejercicio.ShowDialog();
        }

        private void btnEliminarEjercicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ejercicio != null)
                {
                    DialogResult resultado = MessageBox.Show("¿Esta seguro de eliminar el ejercicio?", "Eliminar ejercicio", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (DialogResult.Yes == resultado)
                    {
                        oBLLEjercicio.EliminarEjercicio(_ejercicio.Ejercicio_ID);
                        MessageBox.Show("Se ha eliminado con exíto.");
                        _dia = oBLLDia.LeerDia((int)cbxDias.SelectedValue);
                        CargarDGVEjercicios(oBLLEjercicio.LeerEjericicios(_dia.Dia_ID));
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(_cliente.oRutina != null)
                {
                    if (!oBLLRutina.ExisteRutinaAsociada(_cliente.oRutina.Rutina_ID))
                    {
                        oBLLRutina.EliminarRutina(_cliente.oRutina.Rutina_ID);
                        panelRutina.Visible = false;
                    }
                    else MessageBox.Show("No puede eliminarlo porque la rutina tiene dias asociados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
