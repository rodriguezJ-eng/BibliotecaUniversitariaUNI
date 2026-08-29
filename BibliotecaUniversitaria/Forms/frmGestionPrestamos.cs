using System;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmGestionPrestamos : Form
    {
        public frmGestionPrestamos()
        {
            InitializeComponent();
        }

        private void btnRegistroPrestamo_Click(object sender, EventArgs e)
        {
            // TODO: insertar el préstamo en la base de datos.
            MessageBox.Show("Prestamo registrado (pendiente de conectar a la base de datos).",
                "Gestion de Prestamos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            // TODO: actualizar el estado del préstamo seleccionado en dgvPrestamos.
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // TODO: filtrar dgvPrestamos según cmbPrestamos.
        }
    }
}
