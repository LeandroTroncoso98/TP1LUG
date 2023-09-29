
namespace Presentacion
{
    partial class AdministracionMenu
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.administrarProfesoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarClientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.armarRutinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarSupervisoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lEmail = new System.Windows.Forms.Label();
            this.lRol = new System.Windows.Forms.Label();
            this.lApellido = new System.Windows.Forms.Label();
            this.lnombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarSupervisoresToolStripMenuItem,
            this.administrarProfesoresToolStripMenuItem,
            this.administrarClientesToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 56);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(957, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip1";
            // 
            // administrarProfesoresToolStripMenuItem
            // 
            this.administrarProfesoresToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.administrarProfesoresToolStripMenuItem.Name = "administrarProfesoresToolStripMenuItem";
            this.administrarProfesoresToolStripMenuItem.Size = new System.Drawing.Size(139, 20);
            this.administrarProfesoresToolStripMenuItem.Text = "Administrar Profesores";
            this.administrarProfesoresToolStripMenuItem.Click += new System.EventHandler(this.administrarProfesoresToolStripMenuItem_Click);
            // 
            // administrarClientesToolStripMenuItem
            // 
            this.administrarClientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarClientesToolStripMenuItem1,
            this.armarRutinaToolStripMenuItem});
            this.administrarClientesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.administrarClientesToolStripMenuItem.Name = "administrarClientesToolStripMenuItem";
            this.administrarClientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.administrarClientesToolStripMenuItem.Text = "Clientes";
            // 
            // administrarClientesToolStripMenuItem1
            // 
            this.administrarClientesToolStripMenuItem1.Name = "administrarClientesToolStripMenuItem1";
            this.administrarClientesToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.administrarClientesToolStripMenuItem1.Text = "Administrar clientes";
            this.administrarClientesToolStripMenuItem1.Click += new System.EventHandler(this.administrarClientesToolStripMenuItem1_Click);
            // 
            // armarRutinaToolStripMenuItem
            // 
            this.armarRutinaToolStripMenuItem.Name = "armarRutinaToolStripMenuItem";
            this.armarRutinaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.armarRutinaToolStripMenuItem.Text = "Armar Rutina";
            this.armarRutinaToolStripMenuItem.Click += new System.EventHandler(this.armarRutinaToolStripMenuItem_Click);
            // 
            // administrarSupervisoresToolStripMenuItem
            // 
            this.administrarSupervisoresToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.administrarSupervisoresToolStripMenuItem.Name = "administrarSupervisoresToolStripMenuItem";
            this.administrarSupervisoresToolStripMenuItem.Size = new System.Drawing.Size(150, 20);
            this.administrarSupervisoresToolStripMenuItem.Text = "Administrar Supervisores";
            this.administrarSupervisoresToolStripMenuItem.Click += new System.EventHandler(this.administrarSupervisoresToolStripMenuItem_Click);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.lEmail);
            this.panel1.Controls.Add(this.lRol);
            this.panel1.Controls.Add(this.lApellido);
            this.panel1.Controls.Add(this.lnombre);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.Window;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 56);
            this.panel1.TabIndex = 2;
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Location = new System.Drawing.Point(500, 34);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(35, 13);
            this.lEmail.TabIndex = 4;
            this.lEmail.Text = "Email:";
            // 
            // lRol
            // 
            this.lRol.AutoSize = true;
            this.lRol.Location = new System.Drawing.Point(693, 34);
            this.lRol.Name = "lRol";
            this.lRol.Size = new System.Drawing.Size(26, 13);
            this.lRol.TabIndex = 3;
            this.lRol.Text = "Rol:";
            // 
            // lApellido
            // 
            this.lApellido.AutoSize = true;
            this.lApellido.Location = new System.Drawing.Point(290, 34);
            this.lApellido.Name = "lApellido";
            this.lApellido.Size = new System.Drawing.Size(47, 13);
            this.lApellido.TabIndex = 2;
            this.lApellido.Text = "Apellido:";
            // 
            // lnombre
            // 
            this.lnombre.AutoSize = true;
            this.lnombre.Location = new System.Drawing.Point(94, 34);
            this.lnombre.Name = "lnombre";
            this.lnombre.Size = new System.Drawing.Size(47, 13);
            this.lnombre.TabIndex = 1;
            this.lnombre.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido";
            // 
            // AdministracionMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 592);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "AdministracionMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdministracionMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdministracionMenu_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem administrarProfesoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarSupervisoresToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lEmail;
        private System.Windows.Forms.Label lRol;
        private System.Windows.Forms.Label lApellido;
        private System.Windows.Forms.Label lnombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem administrarClientesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem armarRutinaToolStripMenuItem;
    }
}