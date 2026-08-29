using System;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmGestionMultas : Form
    {
        public frmGestionMultas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // TODO: buscar multas según txtBuscar.
        }

        private void btnMarcarPagada_Click(object sender, EventArgs e)
        {
            // TODO: actualizar la multa seleccionada en dgvMultas como pagada.
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // TODO: eliminar la multa seleccionada en dgvMultas.
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
