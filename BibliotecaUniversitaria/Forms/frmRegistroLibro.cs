using System;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmRegistroLibro : Form
    {
        public frmRegistroLibro()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtISBN.Clear();
            txtTitulo.Clear();
            cmbCategoria.SelectedIndex = -1;
            txtAnio.Clear();
            txtEditorial.Clear();
            txtIdAutor.Clear();
            txtNombreAutor.Clear();
            cmbRolAutor.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // TODO: insertar el libro y su(s) autor(es) en la base de datos (SQL Server).
            MessageBox.Show("Libro guardado (pendiente de conectar a la base de datos).",
                "Registro Libro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // TODO: actualizar el registro seleccionado en dgvLibros.
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // TODO: eliminar el registro seleccionado en dgvLibros.
        }
    }
}
