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
    public partial class ABMClientes : Form
    {
        public ABMClientes()
        {
            oBLLProfesor = new BLLProfesor();
            oBLLCliente = new BLLCliente();
            _cliente = new Cliente();
            _cliente.oProfesor = new Profesor();
            InitializeComponent();
        }
        private BLLProfesor oBLLProfesor;
        private BLLCliente oBLLCliente;
        private Cliente _cliente;
        private void ABMClientes_Load(object sender, EventArgs e)
        {
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvClientes.MultiSelect = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            CargarCBProfesor();
            CargarGrillaClientes();
        }
        private void CargarCBProfesor()
        {
            cbxProfesores.DataSource = null;
            cbxProfesores.DataSource = oBLLProfesor.ListaProfesores();
            cbxProfesores.ValueMember = "Usuario_ID";
            cbxProfesores.DisplayMember = "Nombre";
            cbxProfesores.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxProfesores.Refresh();
            cbxProfesores.SelectedIndex = 0;

        }
        private void resetearFormulario()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtPeso.Text = "";
            txtTelefono.Text = "";
            cbxProfesores.SelectedIndex = 0;
            dtpFechaNacimiento.Value = DateTime.Now;
        }
        private void CargarGrillaClientes()
        {
            try
            {
                List<Cliente> listaclientes = oBLLCliente.listarClientes();
                if(listaclientes != null)
                {
                    dgvClientes.DataSource = null;
                    dgvClientes.DataSource = listaclientes;
                    dgvClientes.Columns["oProfesor"].Visible = false;
                    dgvClientes.Columns["Rol"].Visible = false;
                    dgvClientes.Columns["oRutina"].Visible = false;
                    dgvClientes.Columns["oTarjeta"].Visible = false;
                    dgvClientes.Columns["Nombre"].DisplayIndex = 0;
                    dgvClientes.Columns["Apellido"].DisplayIndex = 1;
                    dgvClientes.Columns["Email"].DisplayIndex = 2;
                    dgvClientes.Columns["Peso"].DisplayIndex = 3;
                    dgvClientes.Columns["Fecha_Nacimiento"].DisplayIndex = 4;
                    dgvClientes.Columns["Usuario_ID"].Visible = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"No se pudo cargar la grilla.\nCausa: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificadorCampos.VerificarCamposCliente(txtNombre, txtApellido, txtEmail, txtTelefono, txtPeso))
                {
                    if(VerificadorCampos.verificarCampoInt(txtTelefono))
                    {
                        if (VerificadorCampos.VerificarCampoFloat(txtPeso))
                        {
                            Cliente cliente = new Cliente();
                            cliente.Nombre = txtNombre.Text;
                            cliente.Apellido = txtApellido.Text;
                            cliente.Rol = RolUsuario.Cliente;
                            cliente.Email = txtEmail.Text;
                            cliente.Telefono = Convert.ToInt32(txtTelefono.Text);
                            cliente.Peso = txtPeso.Text.Replace(',','.');
                            cliente.Fecha_Nacimiento = dtpFechaNacimiento.Value;
                            cliente.oProfesor = new Profesor();
                            cliente.oProfesor.Usuario_ID = (int)cbxProfesores.SelectedValue;
                            oBLLCliente.CrearCliente(cliente);
                            CargarGrillaClientes();
                            resetearFormulario();
                            MessageBox.Show("Cliente creado con exito.");
                        }
                        else MessageBox.Show($"Verificar si el campo de peso es correcto.", "Error de administracion de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show($"Verificar si el campo de telefono es correcto.", "Error de administracion de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show($"Todos los campos son obligatorios.", "Error de administracion de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo crear el cliente.\nCausa: {ex}", "Error de administracion de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
                txtNombre.Text = _cliente.Nombre;
                txtApellido.Text = _cliente.Apellido;
                txtEmail.Text = _cliente.Email;
                txtTelefono.Text = _cliente.Telefono.ToString();
                txtPeso.Text = _cliente.Peso;
                dtpFechaNacimiento.Value = _cliente.Fecha_Nacimiento;
                cbxProfesores.SelectedValue = _cliente.oProfesor.Usuario_ID;
            }catch(Exception ex)
            {
                MessageBox.Show($"No se pudo seleccionar el cliente.\nCausa: {ex}", "Error de administracion de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            try
            {
                if(_cliente != null)
                {
                    if (VerificadorCampos.VerificarCamposCliente(txtNombre, txtApellido, txtEmail, txtTelefono, txtPeso))
                    {
                        if (VerificadorCampos.verificarCampoInt(txtTelefono))
                        {
                            if (VerificadorCampos.VerificarCampoFloat(txtPeso))
                            {
                                Cliente cliente = new Cliente();
                                cliente.Usuario_ID = _cliente.Usuario_ID;
                                cliente.Nombre = txtNombre.Text;
                                cliente.Apellido = txtApellido.Text;
                                cliente.Rol = RolUsuario.Cliente;
                                cliente.Email = txtEmail.Text;
                                cliente.Telefono = Convert.ToInt32(txtTelefono.Text);
                                cliente.Peso = txtPeso.Text.Replace(',', '.');
                                cliente.Fecha_Nacimiento = dtpFechaNacimiento.Value;
                                cliente.oProfesor = new Profesor();
                                cliente.oProfesor.Usuario_ID = (int)cbxProfesores.SelectedValue;
                                oBLLCliente.EditarCliente(cliente);
                                MessageBox.Show("se ha modificado el cliente.");
                                CargarCBProfesor();
                                CargarGrillaClientes();
                                resetearFormulario();
                            }
                            else MessageBox.Show($"El formato de peso es incorrecto.", "Error de administracion de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else MessageBox.Show($"El numero de telefono ingresado no es valido", "Error de administracion de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show($"Debe completar todos los campos.", "Error de administracion de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show($"Debe seleccionar un cliente.", "Error de administracion de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"No se pudo modificar el cliente.\nCausa: {ex}", "Error de administracion de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(_cliente != null)
                {
                    oBLLCliente.EliminarUsuario(_cliente.Usuario_ID);
                    CargarCBProfesor();
                    CargarGrillaClientes();
                    resetearFormulario();
                    MessageBox.Show("Se ha borrado el cliente exitosamente.");
                }
                else MessageBox.Show($"Debe seleccionar un cliente para eliminar", "Error de administracion de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo borrar el cliente.\nCausa: {ex}", "Error de administracion de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
