using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    partial class frmRegistroUsuario
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

        private GroupBox grbDatosUsuario;
        private Label lblCedula, lblNombres, lblApellidos, lblTelefono;
        private Label lblCorreo, lblCarrera, lblTipo;
        private TextBox txtCedula, txtNombres, txtApellidos, txtTelefono;
        private TextBox txtCorreo, txtCarrera, txtTipo;

        private Button btnNuevo, btnGuardar, btnEditar, btnEliminar, btnCerrar;

        private GroupBox grbUsuariosRegistrados;
        private DataGridView dgvUsuarios;

        private void InitializeComponent()
        {
            this.grbDatosUsuario = new GroupBox();
            this.lblCedula = new Label();
            this.txtCedula = new TextBox();
            this.lblNombres = new Label();
            this.txtNombres = new TextBox();
            this.lblApellidos = new Label();
            this.txtApellidos = new TextBox();
            this.lblTelefono = new Label();
            this.txtTelefono = new TextBox();
            this.lblCorreo = new Label();
            this.txtCorreo = new TextBox();
            this.lblCarrera = new Label();
            this.txtCarrera = new TextBox();
            this.lblTipo = new Label();
            this.txtTipo = new TextBox();

            this.btnNuevo = new Button();
            this.btnGuardar = new Button();
            this.btnEditar = new Button();
            this.btnEliminar = new Button();
            this.btnCerrar = new Button();

            this.grbUsuariosRegistrados = new GroupBox();
            this.dgvUsuarios = new DataGridView();

            this.grbDatosUsuario.SuspendLayout();
            this.grbUsuariosRegistrados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            // --- grbDatosUsuario ---
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Text = "Cédula";
            this.lblCedula.Location = new Point(30, 40);
            this.lblCedula.AutoSize = true;

            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Location = new Point(130, 37);
            this.txtCedula.Size = new Size(280, 23);

            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Text = "Nombres";
            this.lblNombres.Location = new Point(30, 80);
            this.lblNombres.AutoSize = true;

            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Location = new Point(130, 77);
            this.txtNombres.Size = new Size(280, 23);

            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Text = "Apellidos";
            this.lblApellidos.Location = new Point(30, 120);
            this.lblApellidos.AutoSize = true;

            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Location = new Point(130, 117);
            this.txtApellidos.Size = new Size(280, 23);

            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Text = "Telefono";
            this.lblTelefono.Location = new Point(30, 160);
            this.lblTelefono.AutoSize = true;

            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Location = new Point(130, 157);
            this.txtTelefono.Size = new Size(280, 23);

            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Text = "Correo";
            this.lblCorreo.Location = new Point(460, 40);
            this.lblCorreo.AutoSize = true;

            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Location = new Point(560, 37);
            this.txtCorreo.Size = new Size(280, 23);

            this.lblCarrera.Name = "lblCarrera";
            this.lblCarrera.Text = "Carrera";
            this.lblCarrera.Location = new Point(460, 80);
            this.lblCarrera.AutoSize = true;

            this.txtCarrera.Name = "txtCarrera";
            this.txtCarrera.Location = new Point(560, 77);
            this.txtCarrera.Size = new Size(280, 23);

            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Text = "Tipo";
            this.lblTipo.Location = new Point(460, 120);
            this.lblTipo.AutoSize = true;

            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Location = new Point(560, 117);
            this.txtTipo.Size = new Size(280, 23);

            this.grbDatosUsuario.Name = "grbDatosUsuario";
            this.grbDatosUsuario.Text = "Datos de usuario";
            this.grbDatosUsuario.Font = Estilos.FuenteTitulo;
            this.grbDatosUsuario.Location = new Point(20, 15);
            this.grbDatosUsuario.Size = new Size(880, 210);
            this.grbDatosUsuario.Controls.Add(this.lblCedula);
            this.grbDatosUsuario.Controls.Add(this.txtCedula);
            this.grbDatosUsuario.Controls.Add(this.lblNombres);
            this.grbDatosUsuario.Controls.Add(this.txtNombres);
            this.grbDatosUsuario.Controls.Add(this.lblApellidos);
            this.grbDatosUsuario.Controls.Add(this.txtApellidos);
            this.grbDatosUsuario.Controls.Add(this.lblTelefono);
            this.grbDatosUsuario.Controls.Add(this.txtTelefono);
            this.grbDatosUsuario.Controls.Add(this.lblCorreo);
            this.grbDatosUsuario.Controls.Add(this.txtCorreo);
            this.grbDatosUsuario.Controls.Add(this.lblCarrera);
            this.grbDatosUsuario.Controls.Add(this.txtCarrera);
            this.grbDatosUsuario.Controls.Add(this.lblTipo);
            this.grbDatosUsuario.Controls.Add(this.txtTipo);

            // --- Botones CRUD ---
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Location = new Point(20, 240);
            this.btnNuevo.Size = new Size(95, 32);
            Estilos.AplicarBotonAccion(this.btnNuevo);
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new Point(125, 240);
            this.btnGuardar.Size = new Size(95, 32);
            Estilos.AplicarBotonAccion(this.btnGuardar);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Text = "Editar";
            this.btnEditar.Location = new Point(230, 240);
            this.btnEditar.Size = new Size(95, 32);
            Estilos.AplicarBotonAccion(this.btnEditar);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new Point(335, 240);
            this.btnEliminar.Size = new Size(95, 32);
            Estilos.AplicarBotonAccion(this.btnEliminar);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Location = new Point(440, 240);
            this.btnCerrar.Size = new Size(95, 32);
            Estilos.AplicarBotonAccion(this.btnCerrar);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // --- grbUsuariosRegistrados ---
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Location = new Point(20, 30);
            this.dgvUsuarios.Size = new Size(840, 210);
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.Columns.Add("Cedula", "Cédula");
            this.dgvUsuarios.Columns.Add("Nombres", "Nombres");
            this.dgvUsuarios.Columns.Add("Apellidos", "Apellidos");
            this.dgvUsuarios.Columns.Add("Telefono", "Telefono");
            this.dgvUsuarios.Columns.Add("Correo", "Correo");
            this.dgvUsuarios.Columns.Add("Carrera", "Carrera");
            this.dgvUsuarios.Columns.Add("Tipo", "Tipo");

            this.grbUsuariosRegistrados.Name = "grbUsuariosRegistrados";
            this.grbUsuariosRegistrados.Text = "Usuarios registrados";
            this.grbUsuariosRegistrados.Font = Estilos.FuenteTitulo;
            this.grbUsuariosRegistrados.Location = new Point(20, 285);
            this.grbUsuariosRegistrados.Size = new Size(880, 260);
            this.grbUsuariosRegistrados.Controls.Add(this.dgvUsuarios);

            // --- frmRegistroUsuario ---
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(920, 570);
            this.BackColor = Estilos.FondoFormulario;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "frmRegistroUsuario";
            this.Text = "Registro de usuarios";

            this.Controls.Add(this.grbDatosUsuario);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.grbUsuariosRegistrados);

            this.grbDatosUsuario.ResumeLayout(false);
            this.grbDatosUsuario.PerformLayout();
            this.grbUsuariosRegistrados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
