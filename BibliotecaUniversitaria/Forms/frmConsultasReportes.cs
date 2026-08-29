using System;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmConsultasReportes : Form
    {
        public frmConsultasReportes()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // TODO: consultar libros según los filtros y llenar dgvLibros.
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            // TODO: exportar el contenido de dgvLibros (por ejemplo a Excel o PDF).
        }
    }
}
