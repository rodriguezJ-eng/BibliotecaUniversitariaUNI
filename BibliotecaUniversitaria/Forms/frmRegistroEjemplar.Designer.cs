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
        private Label lblEstado;
        private ComboBox cmbEstado;

        private Button btnNuevo, btnGuardar, btnEditar, btnEliminar;

        private GroupBox grpEjemplaresDelLibro;
        private DataGridView dgvEjemplares;

        private void InitializeComponent()
        {
            grpDatosEjemplar = new GroupBox();
            groupBox1 = new GroupBox();
            txtCodigo = new TextBox();
            lbllLibro = new Label();
            cmbLibro = new ComboBox();
            lblCodigo = new Label();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            grpEjemplaresDelLibro = new GroupBox();
            dgvEjemplares = new DataGridView();
            groupBox2 = new GroupBox();
            txtEstadisticas = new TextBox();
            btnEstadisticas = new Button();
            btnVerTodos = new Button();
            btnFiltrar = new Button();
            cmbFiltroEstado = new ComboBox();
            label1 = new Label();
            colIDEjemplar = new DataGridViewTextBoxColumn();
            colIDLibro = new DataGridViewTextBoxColumn();
            colCodigo = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colLibro = new DataGridViewTextBoxColumn();
            grpDatosEjemplar.SuspendLayout();
            grpEjemplaresDelLibro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEjemplares).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // grpDatosEjemplar
            // 
            grpDatosEjemplar.Controls.Add(groupBox1);
            grpDatosEjemplar.Controls.Add(txtCodigo);
            grpDatosEjemplar.Controls.Add(lbllLibro);
            grpDatosEjemplar.Controls.Add(cmbLibro);
            grpDatosEjemplar.Controls.Add(lblCodigo);
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
            // groupBox1
            // 
            groupBox1.Location = new Point(25, 266);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(525, 108);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(131, 117);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(264, 30);
            txtCodigo.TabIndex = 6;
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
            grpEjemplaresDelLibro.Location = new Point(23, 465);
            grpEjemplaresDelLibro.Margin = new Padding(3, 4, 3, 4);
            grpEjemplaresDelLibro.Name = "grpEjemplaresDelLibro";
            grpEjemplaresDelLibro.Padding = new Padding(3, 4, 3, 4);
            grpEjemplaresDelLibro.Size = new Size(800, 343);
            grpEjemplaresDelLibro.TabIndex = 5;
            grpEjemplaresDelLibro.TabStop = false;
            grpEjemplaresDelLibro.Text = "Listado de ejemplares";
            // 
            // dgvEjemplares
            // 
            dgvEjemplares.AllowUserToAddRows = false;
            dgvEjemplares.AllowUserToDeleteRows = false;
            dgvEjemplares.ColumnHeadersHeight = 29;
            dgvEjemplares.Columns.AddRange(new DataGridViewColumn[] { colIDEjemplar, colIDLibro, colCodigo, colEstado, colLibro });
            dgvEjemplares.Location = new Point(25, 31);
            dgvEjemplares.Margin = new Padding(3, 4, 3, 4);
            dgvEjemplares.Name = "dgvEjemplares";
            dgvEjemplares.ReadOnly = true;
            dgvEjemplares.RowHeadersWidth = 51;
            dgvEjemplares.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEjemplares.Size = new Size(750, 270);
            dgvEjemplares.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtEstadisticas);
            groupBox2.Controls.Add(btnEstadisticas);
            groupBox2.Controls.Add(btnVerTodos);
            groupBox2.Controls.Add(btnFiltrar);
            groupBox2.Controls.Add(cmbFiltroEstado);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.Location = new Point(23, 302);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(800, 156);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Filtro y Consultas";
            // 
            // txtEstadisticas
            // 
            txtEstadisticas.BackColor = SystemColors.Control;
            txtEstadisticas.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEstadisticas.ForeColor = SystemColors.WindowText;
            txtEstadisticas.Location = new Point(20, 88);
            txtEstadisticas.Multiline = true;
            txtEstadisticas.Name = "txtEstadisticas";
            txtEstadisticas.ReadOnly = true;
            txtEstadisticas.ScrollBars = ScrollBars.Vertical;
            txtEstadisticas.Size = new Size(760, 48);
            txtEstadisticas.TabIndex = 5;
            // 
            // btnEstadisticas
            // 
            btnEstadisticas.BackColor = Color.FromArgb(213, 234, 248);
            btnEstadisticas.Location = new Point(600, 40);
            btnEstadisticas.Name = "btnEstadisticas";
            btnEstadisticas.Size = new Size(175, 38);
            btnEstadisticas.TabIndex = 9;
            btnEstadisticas.Text = "Ver estadísticas";
            btnEstadisticas.UseVisualStyleBackColor = false;
            // 
            // btnVerTodos
            // 
            btnVerTodos.BackColor = Color.FromArgb(213, 234, 248);
            btnVerTodos.Location = new Point(483, 40);
            btnVerTodos.Name = "btnVerTodos";
            btnVerTodos.Size = new Size(110, 38);
            btnVerTodos.TabIndex = 8;
            btnVerTodos.Text = "Ver todos";
            btnVerTodos.UseVisualStyleBackColor = false;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(213, 234, 248);
            btnFiltrar.Location = new Point(367, 40);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(110, 38);
            btnFiltrar.TabIndex = 7;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.ItemHeight = 23;
            cmbFiltroEstado.Items.AddRange(new object[] { "Todos", "Disponible", "Prestado", "En reparación", "Baja" });
            cmbFiltroEstado.Location = new Point(170, 42);
            cmbFiltroEstado.Margin = new Padding(3, 4, 3, 4);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new Size(190, 31);
            cmbFiltroEstado.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 45);
            label1.Name = "label1";
            label1.Size = new Size(160, 23);
            label1.TabIndex = 0;
            label1.Text = "Filtrar por estado: ";
            // 
            // colIDEjemplar
            // 
            colIDEjemplar.HeaderText = "IDEjemplar";
            colIDEjemplar.MinimumWidth = 6;
            colIDEjemplar.Name = "colIDEjemplar";
            colIDEjemplar.ReadOnly = true;
            colIDEjemplar.Visible = false;
            colIDEjemplar.Width = 125;
            // 
            // colIDLibro
            // 
            colIDLibro.HeaderText = "IDLibro";
            colIDLibro.MinimumWidth = 6;
            colIDLibro.Name = "colIDLibro";
            colIDLibro.ReadOnly = true;
            colIDLibro.Visible = false;
            colIDLibro.Width = 125;
            // 
            // colCodigo
            // 
            colCodigo.HeaderText = "Código";
            colCodigo.MinimumWidth = 6;
            colCodigo.Name = "colCodigo";
            colCodigo.ReadOnly = true;
            colCodigo.Width = 200;
            // 
            // colEstado
            // 
            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 6;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            colEstado.Width = 376;
            // 
            // colLibro
            // 
            colLibro.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLibro.HeaderText = "Libro";
            colLibro.MinimumWidth = 6;
            colLibro.Name = "colLibro";
            colLibro.ReadOnly = true;
            // 
            // frmRegistroEjemplar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 234, 248);
            ClientSize = new Size(846, 830);
            Controls.Add(groupBox2);
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
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }
        private TextBox txtCodigo;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Button btnEstadisticas;
        private Button btnVerTodos;
        private Button btnFiltrar;
        private TextBox txtEstadisticas;
        private ComboBox cmbFiltroEstado;
        private DataGridViewTextBoxColumn colIDEjemplar;
        private DataGridViewTextBoxColumn colIDLibro;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colLibro;
    }
}
