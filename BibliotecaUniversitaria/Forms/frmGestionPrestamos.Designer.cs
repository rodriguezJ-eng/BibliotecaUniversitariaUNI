using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    partial class frmGestionPrestamos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private GroupBox grbRegistroPrestamos;
        private Label lblUsuarios, lblEjemplar, lblFechaPrestamo, lblDiasCredito, lblFechaDevolucion;
        private TextBox txtUsuarios, txtEjemplar, txtFechaPrestamo, txtDiasCredito, txtFechaDevolucion;
        private Button btnRegistroPrestamo, btnDevolucion;

        private GroupBox grbPrestamo;
        private Label lblPrestamos;
        private ComboBox cmbPrestamos;
        private Button btnBuscar;
        private DataGridView dgvPrestamos;

        private void InitializeComponent()
        {
            grbRegistroPrestamos = new GroupBox();
            lblUsuarios = new Label();
            txtUsuarios = new TextBox();
            lblEjemplar = new Label();
            txtEjemplar = new TextBox();
            lblFechaPrestamo = new Label();
            txtFechaPrestamo = new TextBox();
            lblDiasCredito = new Label();
            txtDiasCredito = new TextBox();
            lblFechaDevolucion = new Label();
            txtFechaDevolucion = new TextBox();
            btnRegistroPrestamo = new Button();
            btnDevolucion = new Button();
            grbPrestamo = new GroupBox();
            lblPrestamos = new Label();
            cmbPrestamos = new ComboBox();
            btnBuscar = new Button();
            dgvPrestamos = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            grbRegistroPrestamos.SuspendLayout();
            grbPrestamo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            SuspendLayout();
            // 
            // grbRegistroPrestamos
            // 
            grbRegistroPrestamos.Controls.Add(lblUsuarios);
            grbRegistroPrestamos.Controls.Add(txtUsuarios);
            grbRegistroPrestamos.Controls.Add(lblEjemplar);
            grbRegistroPrestamos.Controls.Add(txtEjemplar);
            grbRegistroPrestamos.Controls.Add(lblFechaPrestamo);
            grbRegistroPrestamos.Controls.Add(txtFechaPrestamo);
            grbRegistroPrestamos.Controls.Add(lblDiasCredito);
            grbRegistroPrestamos.Controls.Add(txtDiasCredito);
            grbRegistroPrestamos.Controls.Add(lblFechaDevolucion);
            grbRegistroPrestamos.Controls.Add(txtFechaDevolucion);
            grbRegistroPrestamos.Controls.Add(btnRegistroPrestamo);
            grbRegistroPrestamos.Controls.Add(btnDevolucion);
            grbRegistroPrestamos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grbRegistroPrestamos.Location = new Point(23, 20);
            grbRegistroPrestamos.Margin = new Padding(3, 4, 3, 4);
            grbRegistroPrestamos.Name = "grbRegistroPrestamos";
            grbRegistroPrestamos.Padding = new Padding(3, 4, 3, 4);
            grbRegistroPrestamos.Size = new Size(869, 293);
            grbRegistroPrestamos.TabIndex = 0;
            grbRegistroPrestamos.TabStop = false;
            grbRegistroPrestamos.Text = "Registrar Prestamos";
            // 
            // lblUsuarios
            // 
            lblUsuarios.AutoSize = true;
            lblUsuarios.Location = new Point(34, 47);
            lblUsuarios.Name = "lblUsuarios";
            lblUsuarios.Size = new Size(82, 23);
            lblUsuarios.TabIndex = 0;
            lblUsuarios.Text = "Usuarios:";
            // 
            // txtUsuarios
            // 
            txtUsuarios.Location = new Point(137, 43);
            txtUsuarios.Margin = new Padding(3, 4, 3, 4);
            txtUsuarios.Name = "txtUsuarios";
            txtUsuarios.Size = new Size(297, 30);
            txtUsuarios.TabIndex = 1;
            // 
            // lblEjemplar
            // 
            lblEjemplar.AutoSize = true;
            lblEjemplar.Location = new Point(491, 47);
            lblEjemplar.Name = "lblEjemplar";
            lblEjemplar.Size = new Size(87, 23);
            lblEjemplar.TabIndex = 2;
            lblEjemplar.Text = "Ejemplar:";
            // 
            // txtEjemplar
            // 
            txtEjemplar.Location = new Point(594, 43);
            txtEjemplar.Margin = new Padding(3, 4, 3, 4);
            txtEjemplar.Name = "txtEjemplar";
            txtEjemplar.Size = new Size(251, 30);
            txtEjemplar.TabIndex = 3;
            // 
            // lblFechaPrestamo
            // 
            lblFechaPrestamo.AutoSize = true;
            lblFechaPrestamo.Location = new Point(34, 107);
            lblFechaPrestamo.Name = "lblFechaPrestamo";
            lblFechaPrestamo.Size = new Size(85, 46);
            lblFechaPrestamo.TabIndex = 4;
            lblFechaPrestamo.Text = "Fecha\r\nPrestamo";
            // 
            // txtFechaPrestamo
            // 
            txtFechaPrestamo.Location = new Point(34, 160);
            txtFechaPrestamo.Margin = new Padding(3, 4, 3, 4);
            txtFechaPrestamo.Name = "txtFechaPrestamo";
            txtFechaPrestamo.Size = new Size(171, 30);
            txtFechaPrestamo.TabIndex = 5;
            // 
            // lblDiasCredito
            // 
            lblDiasCredito.AutoSize = true;
            lblDiasCredito.Location = new Point(224, 132);
            lblDiasCredito.Name = "lblDiasCredito";
            lblDiasCredito.Size = new Size(114, 23);
            lblDiasCredito.TabIndex = 6;
            lblDiasCredito.Text = "Dias Credito:";
            // 
            // txtDiasCredito
            // 
            txtDiasCredito.Location = new Point(354, 129);
            txtDiasCredito.Margin = new Padding(3, 4, 3, 4);
            txtDiasCredito.Name = "txtDiasCredito";
            txtDiasCredito.Size = new Size(114, 30);
            txtDiasCredito.TabIndex = 7;
            // 
            // lblFechaDevolucion
            // 
            lblFechaDevolucion.AutoSize = true;
            lblFechaDevolucion.Location = new Point(491, 107);
            lblFechaDevolucion.Name = "lblFechaDevolucion";
            lblFechaDevolucion.Size = new Size(104, 46);
            lblFechaDevolucion.TabIndex = 8;
            lblFechaDevolucion.Text = "Fecha\r\nDevolucion:";
            // 
            // txtFechaDevolucion
            // 
            txtFechaDevolucion.Location = new Point(491, 160);
            txtFechaDevolucion.Margin = new Padding(3, 4, 3, 4);
            txtFechaDevolucion.Name = "txtFechaDevolucion";
            txtFechaDevolucion.Size = new Size(194, 30);
            txtFechaDevolucion.TabIndex = 9;
            // 
            // btnRegistroPrestamo
            // 
            btnRegistroPrestamo.Location = new Point(34, 220);
            btnRegistroPrestamo.Margin = new Padding(3, 4, 3, 4);
            btnRegistroPrestamo.Name = "btnRegistroPrestamo";
            btnRegistroPrestamo.Size = new Size(194, 45);
            btnRegistroPrestamo.TabIndex = 10;
            btnRegistroPrestamo.Text = "Registrar Prestamo";
            btnRegistroPrestamo.Click += btnRegistroPrestamo_Click;
            // 
            // btnDevolucion
            // 
            btnDevolucion.Location = new Point(240, 220);
            btnDevolucion.Margin = new Padding(3, 4, 3, 4);
            btnDevolucion.Name = "btnDevolucion";
            btnDevolucion.Size = new Size(217, 45);
            btnDevolucion.TabIndex = 11;
            btnDevolucion.Text = "Marcar como devuelto";
            btnDevolucion.Click += btnDevolucion_Click;
            // 
            // grbPrestamo
            // 
            grbPrestamo.Controls.Add(lblPrestamos);
            grbPrestamo.Controls.Add(cmbPrestamos);
            grbPrestamo.Controls.Add(btnBuscar);
            grbPrestamo.Controls.Add(dgvPrestamos);
            grbPrestamo.Location = new Point(23, 327);
            grbPrestamo.Margin = new Padding(3, 4, 3, 4);
            grbPrestamo.Name = "grbPrestamo";
            grbPrestamo.Padding = new Padding(3, 4, 3, 4);
            grbPrestamo.Size = new Size(869, 440);
            grbPrestamo.TabIndex = 1;
            grbPrestamo.TabStop = false;
            // 
            // lblPrestamos
            // 
            lblPrestamos.AutoSize = true;
            lblPrestamos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrestamos.Location = new Point(23, 40);
            lblPrestamos.Name = "lblPrestamos";
            lblPrestamos.Size = new Size(92, 23);
            lblPrestamos.TabIndex = 0;
            lblPrestamos.Text = "Prestamos";
            // 
            // cmbPrestamos
            // 
            cmbPrestamos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrestamos.Location = new Point(23, 73);
            cmbPrestamos.Margin = new Padding(3, 4, 3, 4);
            cmbPrestamos.Name = "cmbPrestamos";
            cmbPrestamos.Size = new Size(342, 28);
            cmbPrestamos.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(377, 72);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(103, 33);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvPrestamos
            // 
            dgvPrestamos.AllowUserToAddRows = false;
            dgvPrestamos.ColumnHeadersHeight = 29;
            dgvPrestamos.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvPrestamos.Location = new Point(23, 120);
            dgvPrestamos.Margin = new Padding(3, 4, 3, 4);
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.RowHeadersWidth = 51;
            dgvPrestamos.Size = new Size(823, 293);
            dgvPrestamos.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Usuario";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Libros";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "F. Prestamo";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "F. Devolucion";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Estado";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // frmGestionPrestamos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 234, 248);
            ClientSize = new Size(914, 800);
            Controls.Add(grbRegistroPrestamos);
            Controls.Add(grbPrestamo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmGestionPrestamos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion de Prestamos";
            grbRegistroPrestamos.ResumeLayout(false);
            grbRegistroPrestamos.PerformLayout();
            grbPrestamo.ResumeLayout(false);
            grbPrestamo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
            ResumeLayout(false);
        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}
