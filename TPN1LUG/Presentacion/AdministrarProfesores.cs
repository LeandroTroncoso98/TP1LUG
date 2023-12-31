﻿using BE;
using Negocio;
using Security;
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
    public partial class AdministrarProfesores : Form
    {
        public AdministrarProfesores()
        {
            oBLLProfesor = new BLLProfesor();
            _profesor = new Profesor();
            _verificador = new VerificadorRegexProfesor();
            InitializeComponent();
        }
        private BLLProfesor oBLLProfesor;
        private Profesor _profesor;
        private VerificadorRegexProfesor _verificador;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_verificador.CheckForm(txtNombre, txtApellido, txtEmail, txtEspecializacion))
                {
                    if (!oBLLProfesor.VerificarMail(txtEmail.Text))
                    {
                        string pass = GeneradorContraseña.GenerarPassword();
                        Profesor profesor = new Profesor()
                        {
                            Nombre = txtNombre.Text,
                            Apellido = txtApellido.Text,
                            Email = txtEmail.Text,
                            Contraseña = Encriptador.GenerarMD5(pass),
                            Especializacion = txtEspecializacion.Text,
                            Rol = RolUsuario.Profesor
                        };
                        oBLLProfesor.AltaProfesor(profesor);
                        CargarGrillaEmpleados();
                        VaciarCampos();
                        MessageBox.Show($"Podra ingresar con el email:{profesor.Email} y contraseña: {pass}");
                    }
                    else MessageBox.Show("Ese email ya se encuentra en uso.", "Error al crear profesor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void CargarGrillaEmpleados()
        {
            try
            {
                this.dgvEmpleados.DataSource = null;
                List<Profesor> listaProfesor = oBLLProfesor.ListaProfesores();
                if (listaProfesor != null)
                {
                    dgvEmpleados.DataSource = listaProfesor;
                    dgvEmpleados.Columns["Contraseña"].Visible = false;
                    dgvEmpleados.Columns["Usuario_ID"].Visible = false;
                    dgvEmpleados.Columns["Nombre"].DisplayIndex = 0;
                    dgvEmpleados.Columns["Apellido"].DisplayIndex = 1;
                    dgvEmpleados.Columns["Especializacion"].DisplayIndex = 2;
                    dgvEmpleados.Columns["Rol"].DisplayIndex = 3;
                    dgvEmpleados.Columns["Email"].DisplayIndex = 4;
                }
            }catch(Exception ex){
                throw ex;
            }



        }
        private void VaciarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtEspecializacion.Text = "";
        }

        private void AdministrarProfesores_Load(object sender, EventArgs e)
        {

            CargarGrillaEmpleados();
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvEmpleados.MultiSelect = false;
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _profesor = (Profesor)dgvEmpleados.CurrentRow.DataBoundItem;
                txtNombre.Text = _profesor.Nombre;
                txtApellido.Text = _profesor.Apellido;
                txtEspecializacion.Text = _profesor.Especializacion;
                txtEmail.Text = _profesor.Email;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se puedo seleccionar el profesor. Causa:{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            try
            {
                if (_verificador.CheckForm(txtNombre, txtApellido, txtEmail, txtEspecializacion))
                {
                    if (!oBLLProfesor.VerificarMail(txtEmail.Text, _profesor.Usuario_ID))
                    {
                        Profesor profesor = new Profesor()
                        {
                            Usuario_ID = _profesor.Usuario_ID,
                            Nombre = txtNombre.Text,
                            Apellido = txtApellido.Text,
                            Email = txtEmail.Text,
                            Especializacion = txtEspecializacion.Text,
                            Rol = RolUsuario.Profesor
                        };
                        oBLLProfesor.ActualizarProfesor(profesor);
                        CargarGrillaEmpleados();
                        VaciarCampos();
                        _profesor = null;
                    }
                    else MessageBox.Show("Ese email ya se encuentra en uso.", "Error al crear profesor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el profesor, Causa: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(_profesor != null)
                {
                    if (!oBLLProfesor.ExisteAsociadoEmpleado(_profesor))
                    {
                        oBLLProfesor.EliminarUsuario(_profesor.Usuario_ID);
                        CargarGrillaEmpleados();
                        VaciarCampos();
                        _profesor = null;
                    }
                    else MessageBox.Show($"Imposible eliminarlo tiene un cliente asociado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el profesor, Causa: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAscenderSupervisor_Click(object sender, EventArgs e)
        {
            try
            {
                if (_profesor != null)
                {
                    oBLLProfesor.AscenderProfesor(_profesor.Usuario_ID);
                    CargarGrillaEmpleados();
                    VaciarCampos();
                    MessageBox.Show($"{_profesor.Nombre} {_profesor.Apellido} fue ascendido satisfactoriamente.");
                    _profesor = null;
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo realizar el ascenso a supervisor,\n Causa: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
