using System;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmRegistroUsuario : Form
    {
        public frmRegistroUsuario()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCedula.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtCarrera.Clear();
            txtTipo.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // TODO: insertar el usuario en la base de datos.
            MessageBox.Show("Usuario guardado (pendiente de conectar a la base de datos).",
                "Registro de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // TODO: actualizar el usuario seleccionado en dgvUsuarios.
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // TODO: eliminar el usuario seleccionado en dgvUsuarios.
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
