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
    public partial class AdministrarSupervisores : Form
    {
        public AdministrarSupervisores()
        {
            oBLLSupervisor = new BLLSupervisor();
            _supervisor = new Supervisor();
            InitializeComponent();
        }
        private BLLSupervisor oBLLSupervisor;
        private Supervisor _supervisor;
        private void AdministrarSupervisores_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            dgvSupervisor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSupervisor.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSupervisor.MultiSelect = false;
            dgvSupervisor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void CargarGrilla()
        {
            dgvSupervisor.DataSource = null;
            dgvSupervisor.DataSource = oBLLSupervisor.ListaSupervisores();
            dgvSupervisor.Columns["Contraseña"].Visible = false;
            dgvSupervisor.Columns["Usuario_ID"].Visible = false;
        }
        private void VaciarCampos()
        {
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtEmail.Text = "";
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificadorCampos.VerificarCamposSupervisor(txtNombre, txtApellido, txtEmail))
                {
                    if (!oBLLSupervisor.VerificarMail(txtEmail.Text.Trim()))
                    {
                        Supervisor supervisor = new Supervisor()
                        {
                            Nombre = txtNombre.Text.Trim(),
                            Apellido = txtApellido.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            Rol = RolUsuario.Supervisor
                        };
                        oBLLSupervisor.AltaSupervisor(supervisor);
                        VaciarCampos();
                        CargarGrilla();
                        MessageBox.Show($"Se ha creado con exíto.\n Para ingresar:\nEmail: {supervisor.Email}.\nContraseña: 123456");
                    }
                    else MessageBox.Show("Ese email ya se encuentra en uso.", "Error de administracion de supervisor", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error al crear el supervisor, Causa: {ex}", "Error de administracion de supervisor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            if(_supervisor != null)
            {
                if (VerificadorCampos.VerificarCamposSupervisor(txtNombre, txtApellido, txtEmail))
                {
                    if (!oBLLSupervisor.VerificarMail(txtEmail.Text, _supervisor.Usuario_ID))
                    {
                        Supervisor supervisor = new Supervisor()
                        {
                            Usuario_ID = _supervisor.Usuario_ID,
                            Nombre = txtNombre.Text,
                            Apellido = txtApellido.Text,
                            Email = txtEmail.Text,
                            Rol = RolUsuario.Supervisor
                        };
                        oBLLSupervisor.ModificarSupervisor(supervisor);
                        CargarGrilla();
                        VaciarCampos();
                        _supervisor = null;
                    }
                    else MessageBox.Show("Ese email ya se encuentra en uso.", "Error de administracion de supervisor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show($"Los campos son obligatorios.", "Error de administracion de supervisor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show($"Debes seleccionar a un supervisor para editar", "Error de administracion de supervisor", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void dgvSupervisor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _supervisor = (Supervisor)dgvSupervisor.CurrentRow.DataBoundItem;
                txtNombre.Text = _supervisor.Nombre;
                txtApellido.Text = _supervisor.Apellido;
                txtEmail.Text = _supervisor.Email;

            }catch(Exception ex)
            {
                MessageBox.Show($"No se ha podido seleccionar al supervisor. Causa: {ex}", "Error al seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(_supervisor != null)
                {
                    if (!oBLLSupervisor.ExisteAsociadoEmpleado(_supervisor))
                    {
                        oBLLSupervisor.EliminarUsuario(_supervisor.Usuario_ID);
                        CargarGrilla();
                        VaciarCampos();
                        _supervisor = null;
                        GC.Collect();
                        MessageBox.Show("Eliminado con exíto.");
                    }
                    else MessageBox.Show($"Imposible eliminarlo, tiene un cliente asociado", "Error de administracion de supervisor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show($"Debes seleccionar a un supervisor para editar", "Error de administracion de supervisor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se ha podido borrar al supervisor.\nCausa: {ex}", "Error al seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarSupervisor_Click(object sender, EventArgs e)
        {
            try
            {
                if(_supervisor != null)
                {
                    oBLLSupervisor.QuitarSupervisor(_supervisor.Usuario_ID);
                    CargarGrilla();
                    VaciarCampos();
                    MessageBox.Show($"El supervisor {_supervisor.Nombre} {_supervisor.Apellido} se a reconfigurado a profesor.");
                    _supervisor = null;
                    GC.Collect();
                    
                }
                else MessageBox.Show($"Debes seleccionar a un supervisor para quitar su jerarquia.", "Error de administracion de supervisor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
