using System;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmRegistroEjemplar : Form
    {
        public frmRegistroEjemplar()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cmbLibro.SelectedIndex = -1;
            cmbCodigo.SelectedIndex = -1;
            cmbCodigo.Text = string.Empty;
            cmbEstado.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // TODO: insertar el ejemplar en la base de datos.
            MessageBox.Show("Ejemplar guardado (pendiente de conectar a la base de datos).",
                "Registro Ejemplar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // TODO: actualizar el ejemplar seleccionado en dgvEjemplares.
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // TODO: eliminar el ejemplar seleccionado en dgvEjemplares.
        }
    }
}
