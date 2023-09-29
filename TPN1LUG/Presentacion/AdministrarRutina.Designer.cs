
namespace Presentacion
{
    partial class AdministrarRutina
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscarRutina = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmailRutina = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRutina = new System.Windows.Forms.Panel();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAgregarDias = new System.Windows.Forms.Button();
            this.btnCambiarRutina = new System.Windows.Forms.Button();
            this.FLPDescGeneral = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDescripcionGeneral = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFecha_Comienzo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PanelDia = new System.Windows.Forms.Panel();
            this.btnAgregarEjercicio = new System.Windows.Forms.Button();
            this.btnMostrarEjericicios = new System.Windows.Forms.Button();
            this.btnEliminarDia = new System.Windows.Forms.Button();
            this.lblDiaDe = new System.Windows.Forms.Label();
            this.cbxDias = new System.Windows.Forms.ComboBox();
            this.btnModificarDia = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PanelEjercio = new System.Windows.Forms.Panel();
            this.btnEditarEjercicio = new System.Windows.Forms.Button();
            this.btnEliminarEjercicio = new System.Windows.Forms.Button();
            this.flpDescripcionEjercicio = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDescripcionEJercicio = new System.Windows.Forms.Label();
            this.dgvEjercicios = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelRutina.SuspendLayout();
            this.FLPDescGeneral.SuspendLayout();
            this.PanelDia.SuspendLayout();
            this.PanelEjercio.SuspendLayout();
            this.flpDescripcionEjercicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.btnBuscarRutina);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtEmailRutina);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnBuscarRutina
            // 
            this.btnBuscarRutina.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuscarRutina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarRutina.ForeColor = System.Drawing.SystemColors.Window;
            this.btnBuscarRutina.Location = new System.Drawing.Point(314, 57);
            this.btnBuscarRutina.Name = "btnBuscarRutina";
            this.btnBuscarRutina.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarRutina.TabIndex = 1;
            this.btnBuscarRutina.Text = "Buscar";
            this.btnBuscarRutina.UseVisualStyleBackColor = false;
            this.btnBuscarRutina.Click += new System.EventHandler(this.btnBuscarRutina_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(99, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "RUTINA DEL CLIENTE";
            // 
            // txtEmailRutina
            // 
            this.txtEmailRutina.Location = new System.Drawing.Point(95, 59);
            this.txtEmailRutina.Name = "txtEmailRutina";
            this.txtEmailRutina.Size = new System.Drawing.Size(213, 20);
            this.txtEmailRutina.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email del cliente:";
            // 
            // panelRutina
            // 
            this.panelRutina.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelRutina.Controls.Add(this.button1);
            this.panelRutina.Controls.Add(this.lblCliente);
            this.panelRutina.Controls.Add(this.label13);
            this.panelRutina.Controls.Add(this.btnAgregarDias);
            this.panelRutina.Controls.Add(this.btnCambiarRutina);
            this.panelRutina.Controls.Add(this.FLPDescGeneral);
            this.panelRutina.Controls.Add(this.label5);
            this.panelRutina.Controls.Add(this.lblFecha_Comienzo);
            this.panelRutina.Controls.Add(this.label3);
            this.panelRutina.Controls.Add(this.label4);
            this.panelRutina.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelRutina.Location = new System.Drawing.Point(12, 118);
            this.panelRutina.Name = "panelRutina";
            this.panelRutina.Size = new System.Drawing.Size(416, 197);
            this.panelRutina.TabIndex = 3;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(47, 26);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(0, 13);
            this.lblCliente.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Cliente:";
            // 
            // btnAgregarDias
            // 
            this.btnAgregarDias.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAgregarDias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDias.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAgregarDias.Location = new System.Drawing.Point(6, 147);
            this.btnAgregarDias.Name = "btnAgregarDias";
            this.btnAgregarDias.Size = new System.Drawing.Size(87, 23);
            this.btnAgregarDias.TabIndex = 7;
            this.btnAgregarDias.Text = "Agregar día";
            this.btnAgregarDias.UseVisualStyleBackColor = false;
            this.btnAgregarDias.Click += new System.EventHandler(this.btnAgregarDias_Click);
            // 
            // btnCambiarRutina
            // 
            this.btnCambiarRutina.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCambiarRutina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarRutina.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCambiarRutina.Location = new System.Drawing.Point(8, 118);
            this.btnCambiarRutina.Name = "btnCambiarRutina";
            this.btnCambiarRutina.Size = new System.Drawing.Size(87, 23);
            this.btnCambiarRutina.TabIndex = 3;
            this.btnCambiarRutina.Text = "Cambiar rutina";
            this.btnCambiarRutina.UseVisualStyleBackColor = false;
            this.btnCambiarRutina.Click += new System.EventHandler(this.btnCambiarRutina_Click);
            // 
            // FLPDescGeneral
            // 
            this.FLPDescGeneral.Controls.Add(this.lblDescripcionGeneral);
            this.FLPDescGeneral.Location = new System.Drawing.Point(117, 85);
            this.FLPDescGeneral.Name = "FLPDescGeneral";
            this.FLPDescGeneral.Size = new System.Drawing.Size(272, 109);
            this.FLPDescGeneral.TabIndex = 6;
            // 
            // lblDescripcionGeneral
            // 
            this.lblDescripcionGeneral.AutoSize = true;
            this.lblDescripcionGeneral.Location = new System.Drawing.Point(3, 0);
            this.lblDescripcionGeneral.Name = "lblDescripcionGeneral";
            this.lblDescripcionGeneral.Size = new System.Drawing.Size(0, 13);
            this.lblDescripcionGeneral.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Descripcion General:";
            // 
            // lblFecha_Comienzo
            // 
            this.lblFecha_Comienzo.AutoSize = true;
            this.lblFecha_Comienzo.Location = new System.Drawing.Point(114, 56);
            this.lblFecha_Comienzo.Name = "lblFecha_Comienzo";
            this.lblFecha_Comienzo.Size = new System.Drawing.Size(0, 13);
            this.lblFecha_Comienzo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Detalles de la rutina:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Comienzo de la rutina: ";
            // 
            // PanelDia
            // 
            this.PanelDia.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.PanelDia.Controls.Add(this.btnAgregarEjercicio);
            this.PanelDia.Controls.Add(this.btnMostrarEjericicios);
            this.PanelDia.Controls.Add(this.btnEliminarDia);
            this.PanelDia.Controls.Add(this.lblDiaDe);
            this.PanelDia.Controls.Add(this.cbxDias);
            this.PanelDia.Controls.Add(this.btnModificarDia);
            this.PanelDia.Controls.Add(this.label7);
            this.PanelDia.Controls.Add(this.label8);
            this.PanelDia.Controls.Add(this.label10);
            this.PanelDia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PanelDia.Location = new System.Drawing.Point(12, 321);
            this.PanelDia.Name = "PanelDia";
            this.PanelDia.Size = new System.Drawing.Size(862, 94);
            this.PanelDia.TabIndex = 8;
            // 
            // btnAgregarEjercicio
            // 
            this.btnAgregarEjercicio.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAgregarEjercicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarEjercicio.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAgregarEjercicio.Location = new System.Drawing.Point(741, 21);
            this.btnAgregarEjercicio.Name = "btnAgregarEjercicio";
            this.btnAgregarEjercicio.Size = new System.Drawing.Size(108, 23);
            this.btnAgregarEjercicio.TabIndex = 14;
            this.btnAgregarEjercicio.Text = "Cargar ejercicio";
            this.btnAgregarEjercicio.UseVisualStyleBackColor = false;
            this.btnAgregarEjercicio.Click += new System.EventHandler(this.btnAgregarEjercicio_Click);
            // 
            // btnMostrarEjericicios
            // 
            this.btnMostrarEjericicios.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMostrarEjericicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarEjericicios.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMostrarEjericicios.Location = new System.Drawing.Point(627, 21);
            this.btnMostrarEjericicios.Name = "btnMostrarEjericicios";
            this.btnMostrarEjericicios.Size = new System.Drawing.Size(108, 23);
            this.btnMostrarEjericicios.TabIndex = 11;
            this.btnMostrarEjericicios.Text = "Mostrar Ejercicios";
            this.btnMostrarEjericicios.UseVisualStyleBackColor = false;
            this.btnMostrarEjericicios.Click += new System.EventHandler(this.btnMostrarEjericicios_Click);
            // 
            // btnEliminarDia
            // 
            this.btnEliminarDia.BackColor = System.Drawing.Color.Red;
            this.btnEliminarDia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDia.ForeColor = System.Drawing.SystemColors.Window;
            this.btnEliminarDia.Location = new System.Drawing.Point(101, 61);
            this.btnEliminarDia.Name = "btnEliminarDia";
            this.btnEliminarDia.Size = new System.Drawing.Size(87, 23);
            this.btnEliminarDia.TabIndex = 10;
            this.btnEliminarDia.Text = "Eliminar Dia";
            this.btnEliminarDia.UseVisualStyleBackColor = false;
            this.btnEliminarDia.Click += new System.EventHandler(this.btnEliminarDia_Click);
            // 
            // lblDiaDe
            // 
            this.lblDiaDe.AutoSize = true;
            this.lblDiaDe.Location = new System.Drawing.Point(46, 45);
            this.lblDiaDe.Name = "lblDiaDe";
            this.lblDiaDe.Size = new System.Drawing.Size(0, 13);
            this.lblDiaDe.TabIndex = 9;
            // 
            // cbxDias
            // 
            this.cbxDias.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cbxDias.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxDias.ForeColor = System.Drawing.SystemColors.Window;
            this.cbxDias.FormattingEnabled = true;
            this.cbxDias.Location = new System.Drawing.Point(117, 18);
            this.cbxDias.Name = "cbxDias";
            this.cbxDias.Size = new System.Drawing.Size(162, 21);
            this.cbxDias.TabIndex = 8;
            this.cbxDias.SelectedIndexChanged += new System.EventHandler(this.cbxDias_SelectedIndexChanged);
            // 
            // btnModificarDia
            // 
            this.btnModificarDia.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarDia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarDia.ForeColor = System.Drawing.SystemColors.Window;
            this.btnModificarDia.Location = new System.Drawing.Point(8, 61);
            this.btnModificarDia.Name = "btnModificarDia";
            this.btnModificarDia.Size = new System.Drawing.Size(87, 23);
            this.btnModificarDia.TabIndex = 3;
            this.btnModificarDia.Text = "Modificar dia";
            this.btnModificarDia.UseVisualStyleBackColor = false;
            this.btnModificarDia.Click += new System.EventHandler(this.btnModificarDia_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Día de:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(125, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Dia:";
            // 
            // PanelEjercio
            // 
            this.PanelEjercio.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.PanelEjercio.Controls.Add(this.btnEditarEjercicio);
            this.PanelEjercio.Controls.Add(this.btnEliminarEjercicio);
            this.PanelEjercio.Controls.Add(this.flpDescripcionEjercicio);
            this.PanelEjercio.Controls.Add(this.dgvEjercicios);
            this.PanelEjercio.Controls.Add(this.label12);
            this.PanelEjercio.Controls.Add(this.label11);
            this.PanelEjercio.Controls.Add(this.label9);
            this.PanelEjercio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PanelEjercio.Location = new System.Drawing.Point(439, 12);
            this.PanelEjercio.Name = "PanelEjercio";
            this.PanelEjercio.Size = new System.Drawing.Size(435, 303);
            this.PanelEjercio.TabIndex = 9;
            // 
            // btnEditarEjercicio
            // 
            this.btnEditarEjercicio.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnEditarEjercicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarEjercicio.ForeColor = System.Drawing.SystemColors.Window;
            this.btnEditarEjercicio.Location = new System.Drawing.Point(14, 224);
            this.btnEditarEjercicio.Name = "btnEditarEjercicio";
            this.btnEditarEjercicio.Size = new System.Drawing.Size(108, 23);
            this.btnEditarEjercicio.TabIndex = 13;
            this.btnEditarEjercicio.Text = "Editar ejercicio";
            this.btnEditarEjercicio.UseVisualStyleBackColor = false;
            this.btnEditarEjercicio.Click += new System.EventHandler(this.btnEditarEjercicio_Click);
            // 
            // btnEliminarEjercicio
            // 
            this.btnEliminarEjercicio.BackColor = System.Drawing.Color.Red;
            this.btnEliminarEjercicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarEjercicio.ForeColor = System.Drawing.SystemColors.Window;
            this.btnEliminarEjercicio.Location = new System.Drawing.Point(14, 259);
            this.btnEliminarEjercicio.Name = "btnEliminarEjercicio";
            this.btnEliminarEjercicio.Size = new System.Drawing.Size(108, 23);
            this.btnEliminarEjercicio.TabIndex = 12;
            this.btnEliminarEjercicio.Text = "Eliminar ejercicio";
            this.btnEliminarEjercicio.UseVisualStyleBackColor = false;
            this.btnEliminarEjercicio.Click += new System.EventHandler(this.btnEliminarEjercicio_Click);
            // 
            // flpDescripcionEjercicio
            // 
            this.flpDescripcionEjercicio.Controls.Add(this.label6);
            this.flpDescripcionEjercicio.Controls.Add(this.lblDescripcionEJercicio);
            this.flpDescripcionEjercicio.Location = new System.Drawing.Point(128, 204);
            this.flpDescripcionEjercicio.Name = "flpDescripcionEjercicio";
            this.flpDescripcionEjercicio.Size = new System.Drawing.Size(294, 96);
            this.flpDescripcionEjercicio.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 5;
            // 
            // lblDescripcionEJercicio
            // 
            this.lblDescripcionEJercicio.AutoSize = true;
            this.lblDescripcionEJercicio.Location = new System.Drawing.Point(9, 0);
            this.lblDescripcionEJercicio.Name = "lblDescripcionEJercicio";
            this.lblDescripcionEJercicio.Size = new System.Drawing.Size(0, 13);
            this.lblDescripcionEJercicio.TabIndex = 6;
            // 
            // dgvEjercicios
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.Window;
            this.dgvEjercicios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvEjercicios.BackgroundColor = System.Drawing.SystemColors.HotTrack;
            this.dgvEjercicios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEjercicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEjercicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvEjercicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEjercicios.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvEjercicios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEjercicios.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.dgvEjercicios.Location = new System.Drawing.Point(19, 42);
            this.dgvEjercicios.Name = "dgvEjercicios";
            this.dgvEjercicios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEjercicios.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvEjercicios.RowHeadersVisible = false;
            this.dgvEjercicios.Size = new System.Drawing.Size(403, 150);
            this.dgvEjercicios.TabIndex = 6;
            this.dgvEjercicios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEjercicios_CellClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Descripcion General:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(173, 26);
            this.label11.TabIndex = 8;
            this.label11.Text = "Ejercicios del dia";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(125, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(326, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Eliminar Rutina";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdministrarRutina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(886, 424);
            this.Controls.Add(this.PanelEjercio);
            this.Controls.Add(this.PanelDia);
            this.Controls.Add(this.panelRutina);
            this.Controls.Add(this.panel1);
            this.Name = "AdministrarRutina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdministrarRutina";
            this.Load += new System.EventHandler(this.AdministrarRutina_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelRutina.ResumeLayout(false);
            this.panelRutina.PerformLayout();
            this.FLPDescGeneral.ResumeLayout(false);
            this.FLPDescGeneral.PerformLayout();
            this.PanelDia.ResumeLayout(false);
            this.PanelDia.PerformLayout();
            this.PanelEjercio.ResumeLayout(false);
            this.PanelEjercio.PerformLayout();
            this.flpDescripcionEjercicio.ResumeLayout(false);
            this.flpDescripcionEjercicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjercicios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscarRutina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmailRutina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelRutina;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFecha_Comienzo;
        private System.Windows.Forms.Label lblDescripcionGeneral;
        private System.Windows.Forms.FlowLayoutPanel FLPDescGeneral;
        private System.Windows.Forms.Button btnAgregarDias;
        private System.Windows.Forms.Button btnCambiarRutina;
        private System.Windows.Forms.Panel PanelDia;
        private System.Windows.Forms.ComboBox cbxDias;
        private System.Windows.Forms.Button btnModificarDia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel PanelEjercio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.FlowLayoutPanel flpDescripcionEjercicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblDiaDe;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Button btnEliminarDia;
        private System.Windows.Forms.Button btnMostrarEjericicios;
        private System.Windows.Forms.DataGridView dgvEjercicios;
        private System.Windows.Forms.Label lblDescripcionEJercicio;
        private System.Windows.Forms.Button btnAgregarEjercicio;
        private System.Windows.Forms.Button btnEditarEjercicio;
        private System.Windows.Forms.Button btnEliminarEjercicio;
        private System.Windows.Forms.Button button1;
    }
}