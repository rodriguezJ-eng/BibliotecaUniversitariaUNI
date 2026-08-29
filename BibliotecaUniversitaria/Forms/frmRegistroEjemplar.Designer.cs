using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    partial class frmRegistroEjemplar
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

        private GroupBox grpDatosEjemplar;
        private Label lbllLibro;
        private ComboBox cmbLibro;
        private Label lblCodigo;
        private ComboBox cmbCodigo;
        private Label lblEstado;
        private ComboBox cmbEstado;

        private Button btnNuevo, btnGuardar, btnEditar, btnEliminar;

        private GroupBox grpEjemplaresDelLibro;
        private DataGridView dgvEjemplares;

        private void InitializeComponent()
        {
            grpDatosEjemplar = new GroupBox();
            lbllLibro = new Label();
            cmbLibro = new ComboBox();
            lblCodigo = new Label();
            cmbCodigo = new ComboBox();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            grpEjemplaresDelLibro = new GroupBox();
            dgvEjemplares = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            grpDatosEjemplar.SuspendLayout();
            grpEjemplaresDelLibro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEjemplares).BeginInit();
            SuspendLayout();
            // 
            // grpDatosEjemplar
            // 
            grpDatosEjemplar.Controls.Add(lbllLibro);
            grpDatosEjemplar.Controls.Add(cmbLibro);
            grpDatosEjemplar.Controls.Add(lblCodigo);
            grpDatosEjemplar.Controls.Add(cmbCodigo);
            grpDatosEjemplar.Controls.Add(lblEstado);
            grpDatosEjemplar.Controls.Add(cmbEstado);
            grpDatosEjemplar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpDatosEjemplar.Location = new Point(23, 20);
            grpDatosEjemplar.Margin = new Padding(3, 4, 3, 4);
            grpDatosEjemplar.Name = "grpDatosEjemplar";
            grpDatosEjemplar.Padding = new Padding(3, 4, 3, 4);
            grpDatosEjemplar.Size = new Size(800, 200);
            grpDatosEjemplar.TabIndex = 0;
            grpDatosEjemplar.TabStop = false;
            grpDatosEjemplar.Text = "Datos del ejemplar";
            // 
            // lbllLibro
            // 
            lbllLibro.AutoSize = true;
            lbllLibro.Location = new Point(34, 47);
            lbllLibro.Name = "lbllLibro";
            lbllLibro.Size = new Size(57, 23);
            lbllLibro.TabIndex = 0;
            lbllLibro.Text = "Libro:";
            // 
            // cmbLibro
            // 
            cmbLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLibro.Location = new Point(126, 43);
            cmbLibro.Margin = new Padding(3, 4, 3, 4);
            cmbLibro.Name = "cmbLibro";
            cmbLibro.Size = new Size(639, 31);
            cmbLibro.TabIndex = 1;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(34, 120);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(73, 23);
            lblCodigo.TabIndex = 2;
            lblCodigo.Text = "Codigo:";
            // 
            // cmbCodigo
            // 
            cmbCodigo.Location = new Point(126, 116);
            cmbCodigo.Margin = new Padding(3, 4, 3, 4);
            cmbCodigo.Name = "cmbCodigo";
            cmbCodigo.Size = new Size(285, 31);
            cmbCodigo.TabIndex = 3;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(457, 120);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(68, 23);
            lblEstado.TabIndex = 4;
            lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Items.AddRange(new object[] { "Disponible", "Prestado", "En reparación", "Extraviado" });
            cmbEstado.Location = new Point(537, 116);
            cmbEstado.Margin = new Padding(3, 4, 3, 4);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(228, 31);
            cmbEstado.TabIndex = 5;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(34, 240);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(109, 43);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "Nuevo";
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(154, 240);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(109, 43);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(274, 240);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(109, 43);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(394, 240);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(109, 43);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // grpEjemplaresDelLibro
            // 
            grpEjemplaresDelLibro.Controls.Add(dgvEjemplares);
            grpEjemplaresDelLibro.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpEjemplaresDelLibro.Location = new Point(23, 307);
            grpEjemplaresDelLibro.Margin = new Padding(3, 4, 3, 4);
            grpEjemplaresDelLibro.Name = "grpEjemplaresDelLibro";
            grpEjemplaresDelLibro.Padding = new Padding(3, 4, 3, 4);
            grpEjemplaresDelLibro.Size = new Size(800, 347);
            grpEjemplaresDelLibro.TabIndex = 5;
            grpEjemplaresDelLibro.TabStop = false;
            grpEjemplaresDelLibro.Text = "Ejemplares del Libro";
            // 
            // dgvEjemplares
            // 
            dgvEjemplares.ColumnHeadersHeight = 29;
            dgvEjemplares.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dgvEjemplares.Location = new Point(23, 40);
            dgvEjemplares.Margin = new Padding(3, 4, 3, 4);
            dgvEjemplares.Name = "dgvEjemplares";
            dgvEjemplares.RowHeadersWidth = 51;
            dgvEjemplares.Size = new Size(754, 267);
            dgvEjemplares.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Código";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.HeaderText = "Estado";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // frmRegistroEjemplar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 234, 248);
            ClientSize = new Size(846, 680);
            Controls.Add(grpDatosEjemplar);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(grpEjemplaresDelLibro);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmRegistroEjemplar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro Ejemplar";
            grpDatosEjemplar.ResumeLayout(false);
            grpDatosEjemplar.PerformLayout();
            grpEjemplaresDelLibro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEjemplares).EndInit();
            ResumeLayout(false);
        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
