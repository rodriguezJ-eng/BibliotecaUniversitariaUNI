using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmGestionMultas : Form
    {
        /// <summary>
        /// Multas generadas. Static por la misma razón que Lectores en
        /// frmRegistroLector y Prestamos en frmGestionPrestamos: debe poder
        /// recibir multas generadas desde la ventana de Préstamos aunque esta
        /// ventana de Multas no esté abierta en ese momento, y debe conservar
        /// sus datos aunque se cierre y se vuelva a abrir.
        /// </summary>
        public static List<Multa> Multas { get; } = new List<Multa>();

        private static int _siguienteIdMulta = 1;

        /// <summary>Genera el próximo ID de multa. Lo usa frmGestionPrestamos al crear una multa.</summary>
        public static int SiguienteIdMulta() => _siguienteIdMulta++;

        public frmGestionMultas()
        {
            InitializeComponent();
            dgvMultas.SelectionChanged += DgvMultas_SelectionChanged;
            CargarMultasEnGrid(Multas);
        }

        private void DgvMultas_SelectionChanged(object sender, EventArgs e)
        {
            txtIdMultaSeleccionada.Text = dgvMultas.CurrentRow != null
                ? dgvMultas.CurrentRow.Cells["Column1"].Value?.ToString()
                : string.Empty;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();

            var resultado = string.IsNullOrWhiteSpace(filtro)
                ? Multas
                : Multas.Where(m =>
                    m.Lector.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    m.Id.ToString() == filtro ||
                    m.IdPrestamo.ToString() == filtro).ToList();

            CargarMultasEnGrid(resultado);
        }

        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var multa = ObtenerMultaSeleccionada();
            if (multa == null) return;

            var respuesta = MessageBox.Show($"¿Eliminar la multa #{multa.Id}?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            Multas.Remove(multa);
            CargarMultasEnGrid(Multas);
        }

        private Multa ObtenerMultaSeleccionada()
        {
            if (dgvMultas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una multa de la lista.", "Gestión de Multas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            int id = Convert.ToInt32(dgvMultas.CurrentRow.Cells["Column1"].Value);
            var multa = Multas.FirstOrDefault(m => m.Id == id);

            if (multa == null)
            {
                MessageBox.Show("No se encontró la multa seleccionada.", "Gestión de Multas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return multa;
        }

        private void CargarMultasEnGrid(List<Multa> lista)
        {
            dgvMultas.Rows.Clear();

            foreach (var m in lista)
            {
                dgvMultas.Rows.Add(
                    m.Id,
                    m.IdPrestamo,
                    m.Lector,
                    m.Monto.ToString("0.00"),
                    m.Estado,
                    m.FechaGeneracion.ToShortDateString());
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMarcarPagada_Click_1(object sender, EventArgs e)
        {
            var multa = ObtenerMultaSeleccionada();
            if (multa == null) return;

            if (multa.Estado == "Pagada")
            {
                MessageBox.Show("Esta multa ya está pagada.", "Gestión de Multas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            multa.Estado = "Pagada";
            CargarMultasEnGrid(Multas);
        }
    }
}
