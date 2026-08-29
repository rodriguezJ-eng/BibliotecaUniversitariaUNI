using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    partial class frmRegistroLibro
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

        private GroupBox grbDatosLibro;
        private TabControl tabLibro;
        private TabPage tabDatosGenerales;
        private TabPage tabAutores;

        // tabDatosGenerales
        private Label lblISBN, lblTitulo, lblCategoria, lblAnio, lblEditorial;
        private TextBox txtISBN, txtTitulo, txtAnio, txtEditorial;
        private ComboBox cmbCategoria;

        // tabAutores
        private Label lblIdAutor, lblNombreAutor, lblRolAutor;
        private TextBox txtIdAutor, txtNombreAutor;
        private ComboBox cmbRolAutor;

        private Button btnNuevo, btnGuardar, btnEditar, btnEliminar;
        private Label lblLibrosRegistrados;
        private DataGridView dgvLibros;

        private void InitializeComponent()
        {
            grbDatosLibro = new GroupBox();
            tabLibro = new TabControl();
            tabDatosGenerales = new TabPage();
            lblISBN = new Label();
            txtISBN = new TextBox();
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblAnio = new Label();
            txtAnio = new TextBox();
            lblEditorial = new Label();
            txtEditorial = new TextBox();
            tabAutores = new TabPage();
            lblIdAutor = new Label();
            txtIdAutor = new TextBox();
            lblNombreAutor = new Label();
            txtNombreAutor = new TextBox();
            lblRolAutor = new Label();
            cmbRolAutor = new ComboBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            lblLibrosRegistrados = new Label();
            dgvLibros = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            grbDatosLibro.SuspendLayout();
            tabLibro.SuspendLayout();
            tabDatosGenerales.SuspendLayout();
            tabAutores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            SuspendLayout();
            // 
            // grbDatosLibro
            // 
            grbDatosLibro.Controls.Add(tabLibro);
            grbDatosLibro.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grbDatosLibro.Location = new Point(23, 20);
            grbDatosLibro.Margin = new Padding(3, 4, 3, 4);
            grbDatosLibro.Name = "grbDatosLibro";
            grbDatosLibro.Padding = new Padding(3, 4, 3, 4);
            grbDatosLibro.Size = new Size(823, 347);
            grbDatosLibro.TabIndex = 0;
            grbDatosLibro.TabStop = false;
            grbDatosLibro.Text = "Datos del Libro";
            // 
            // tabLibro
            // 
            tabLibro.Controls.Add(tabDatosGenerales);
            tabLibro.Controls.Add(tabAutores);
            tabLibro.Location = new Point(23, 53);
            tabLibro.Margin = new Padding(3, 4, 3, 4);
            tabLibro.Name = "tabLibro";
            tabLibro.SelectedIndex = 0;
            tabLibro.Size = new Size(800, 267);
            tabLibro.TabIndex = 0;
            // 
            // tabDatosGenerales
            // 
            tabDatosGenerales.Controls.Add(lblISBN);
            tabDatosGenerales.Controls.Add(txtISBN);
            tabDatosGenerales.Controls.Add(lblTitulo);
            tabDatosGenerales.Controls.Add(txtTitulo);
            tabDatosGenerales.Controls.Add(lblCategoria);
            tabDatosGenerales.Controls.Add(cmbCategoria);
            tabDatosGenerales.Controls.Add(lblAnio);
            tabDatosGenerales.Controls.Add(txtAnio);
            tabDatosGenerales.Controls.Add(lblEditorial);
            tabDatosGenerales.Controls.Add(txtEditorial);
            tabDatosGenerales.Location = new Point(4, 32);
            tabDatosGenerales.Margin = new Padding(3, 4, 3, 4);
            tabDatosGenerales.Name = "tabDatosGenerales";
            tabDatosGenerales.Size = new Size(792, 231);
            tabDatosGenerales.TabIndex = 0;
            tabDatosGenerales.Text = "Datos generales";
            tabDatosGenerales.UseVisualStyleBackColor = true;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(34, 40);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(49, 23);
            lblISBN.TabIndex = 0;
            lblISBN.Text = "ISBN";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(137, 36);
            txtISBN.Margin = new Padding(3, 4, 3, 4);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(228, 30);
            txtISBN.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(411, 40);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(57, 23);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Titulo";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(491, 36);
            txtTitulo.Margin = new Padding(3, 4, 3, 4);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(262, 30);
            txtTitulo.TabIndex = 3;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(34, 107);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(88, 23);
            lblCategoria.TabIndex = 4;
            lblCategoria.Text = "Categoria";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Location = new Point(137, 103);
            cmbCategoria.Margin = new Padding(3, 4, 3, 4);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(228, 31);
            cmbCategoria.TabIndex = 5;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(411, 107);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(42, 23);
            lblAnio.TabIndex = 6;
            lblAnio.Text = "Año";
            // 
            // txtAnio
            // 
            txtAnio.Location = new Point(491, 103);
            txtAnio.Margin = new Padding(3, 4, 3, 4);
            txtAnio.Name = "txtAnio";
            txtAnio.Size = new Size(114, 30);
            txtAnio.TabIndex = 7;
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Location = new Point(34, 173);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.Size = new Size(78, 23);
            lblEditorial.TabIndex = 8;
            lblEditorial.Text = "Editorial";
            // 
            // txtEditorial
            // 
            txtEditorial.Location = new Point(137, 169);
            txtEditorial.Margin = new Padding(3, 4, 3, 4);
            txtEditorial.Name = "txtEditorial";
            txtEditorial.Size = new Size(228, 30);
            txtEditorial.TabIndex = 9;
            // 
            // tabAutores
            // 
            tabAutores.Controls.Add(lblIdAutor);
            tabAutores.Controls.Add(txtIdAutor);
            tabAutores.Controls.Add(lblNombreAutor);
            tabAutores.Controls.Add(txtNombreAutor);
            tabAutores.Controls.Add(lblRolAutor);
            tabAutores.Controls.Add(cmbRolAutor);
            tabAutores.Location = new Point(4, 32);
            tabAutores.Margin = new Padding(3, 4, 3, 4);
            tabAutores.Name = "tabAutores";
            tabAutores.Size = new Size(792, 231);
            tabAutores.TabIndex = 1;
            tabAutores.Text = "Autores";
            tabAutores.UseVisualStyleBackColor = true;
            // 
            // lblIdAutor
            // 
            lblIdAutor.AutoSize = true;
            lblIdAutor.Location = new Point(34, 40);
            lblIdAutor.Name = "lblIdAutor";
            lblIdAutor.Size = new Size(113, 23);
            lblIdAutor.TabIndex = 0;
            lblIdAutor.Text = "Id del Autor:";
            // 
            // txtIdAutor
            // 
            txtIdAutor.Location = new Point(171, 36);
            txtIdAutor.Margin = new Padding(3, 4, 3, 4);
            txtIdAutor.Name = "txtIdAutor";
            txtIdAutor.Size = new Size(285, 30);
            txtIdAutor.TabIndex = 1;
            // 
            // lblNombreAutor
            // 
            lblNombreAutor.AutoSize = true;
            lblNombreAutor.Location = new Point(34, 93);
            lblNombreAutor.Name = "lblNombreAutor";
            lblNombreAutor.Size = new Size(163, 23);
            lblNombreAutor.TabIndex = 2;
            lblNombreAutor.Text = "Nombre del Autor:";
            // 
            // txtNombreAutor
            // 
            txtNombreAutor.Location = new Point(171, 89);
            txtNombreAutor.Margin = new Padding(3, 4, 3, 4);
            txtNombreAutor.Name = "txtNombreAutor";
            txtNombreAutor.Size = new Size(285, 30);
            txtNombreAutor.TabIndex = 3;
            // 
            // lblRolAutor
            // 
            lblRolAutor.AutoSize = true;
            lblRolAutor.Location = new Point(34, 147);
            lblRolAutor.Name = "lblRolAutor";
            lblRolAutor.Size = new Size(123, 23);
            lblRolAutor.TabIndex = 4;
            lblRolAutor.Text = "Rol del Autor:";
            // 
            // cmbRolAutor
            // 
            cmbRolAutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRolAutor.Location = new Point(171, 143);
            cmbRolAutor.Margin = new Padding(3, 4, 3, 4);
            cmbRolAutor.Name = "cmbRolAutor";
            cmbRolAutor.Size = new Size(285, 31);
            cmbRolAutor.TabIndex = 5;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(23, 387);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(109, 43);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "Nuevo";
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(143, 387);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(109, 43);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(263, 387);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(109, 43);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(383, 387);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(109, 43);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblLibrosRegistrados
            // 
            lblLibrosRegistrados.AutoSize = true;
            lblLibrosRegistrados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLibrosRegistrados.Location = new Point(23, 447);
            lblLibrosRegistrados.Name = "lblLibrosRegistrados";
            lblLibrosRegistrados.Size = new Size(154, 23);
            lblLibrosRegistrados.TabIndex = 5;
            lblLibrosRegistrados.Text = "Libros registrados";
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.ColumnHeadersHeight = 29;
            dgvLibros.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvLibros.Location = new Point(23, 480);
            dgvLibros.Margin = new Padding(3, 4, 3, 4);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.RowHeadersWidth = 51;
            dgvLibros.Size = new Size(823, 267);
            dgvLibros.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "ISBN";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Titulo";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Categoria";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Año";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Editorial";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // frmRegistroLibro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 234, 248);
            ClientSize = new Size(869, 773);
            Controls.Add(grbDatosLibro);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(lblLibrosRegistrados);
            Controls.Add(dgvLibros);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmRegistroLibro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro Libro";
            grbDatosLibro.ResumeLayout(false);
            tabLibro.ResumeLayout(false);
            tabDatosGenerales.ResumeLayout(false);
            tabDatosGenerales.PerformLayout();
            tabAutores.ResumeLayout(false);
            tabAutores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}
