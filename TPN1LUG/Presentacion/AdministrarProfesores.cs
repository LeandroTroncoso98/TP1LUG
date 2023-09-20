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
    public partial class AdministrarProfesores : Form
    {
        public AdministrarProfesores()
        {
            InitializeComponent();
            oBLLEmpleado = new BLLEmpleado();
        }
        private BLLEmpleado oBLLEmpleado;
        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
        private void CargarGrillaEmpleados()
        {
            this.dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = oBLLEmpleado.ListaProfesores();

        }

        private void AdministrarProfesores_Load(object sender, EventArgs e)
        {
            CargarGrillaEmpleados();
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvEmpleados.MultiSelect = false;
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
