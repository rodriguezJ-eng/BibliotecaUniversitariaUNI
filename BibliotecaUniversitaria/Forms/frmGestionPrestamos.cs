using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmGestionPrestamos : Form
    {
        /// <summary>
        /// Préstamos registrados. Static por la misma razón que Lectores en
        /// frmRegistroLector: debe sobrevivir a que esta ventana se cierre y se
        /// vuelva a abrir con una instancia nueva desde frmMenu.
        /// </summary>
        public static List<Prestamo> Prestamos { get; } = new List<Prestamo>();

        private static int _siguienteIdPrestamo = 1;

        /// <summary>Tarifa de multa en córdobas por cada día de atraso en la devolución.</summary>
        private const decimal TarifaPorDiaAtraso = 5m;

        public frmGestionPrestamos()
        {
            InitializeComponent();

            cmbPrestamos.Items.AddRange(new object[] { "Todos", "Activos", "Devueltos", "Atrasados" });
            cmbPrestamos.SelectedIndex = 0;

            dtpFechaPrestamo.Value = DateTime.Today;
            dtpFechaDevolucion.Enabled = false;

            CargarEjemplaresEnCombo();

            CargarPrestamosEnGrid(Prestamos);
        }

        /// <summary>
        /// Carga en cmbEjemplar únicamente los ejemplares en estado "Disponible", 
        /// cruzando el ISBN con la lista de libros para mostrar el Título.
        /// </summary>
        private void CargarEjemplaresEnCombo()
        {
            cmbEjemplar.Items.Clear();

            // Filtramos ejemplares cuya condición sea "Disponible"
            var ejemplaresDisponibles = frmRegistroEjemplar.Ejemplares
                .Where(ej => ej.Estado == "Disponible")
                .ToList();

            foreach (var ej in ejemplaresDisponibles)
            {
                // Buscamos el libro correspondiente para mostrar su título
                var libro = frmRegistroLibro.Libros.FirstOrDefault(l => l.ISBN == ej.ISBNLibro);
                string tituloLibro = libro != null ? libro.Titulo : "Libro Desconocido";

                // Agregamos el formato: [Código Ejemplar] - Título Libro
                cmbEjemplar.Items.Add($"{ej.Codigo} - {tituloLibro}");
            }
        }

        private void btnRegistroPrestamo_Click(object sender, EventArgs e)
        {
            string idLector = txtIdLector.Text.Trim();
            string ejemplar = cmbEjemplar.Text.Trim();

            if (string.IsNullOrWhiteSpace(idLector))
            {
                MessageBox.Show("Ingrese el ID del lector.", "Gestión de Préstamos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ejemplar))
            {
                MessageBox.Show("Ingrese el ejemplar a prestar.", "Gestión de Préstamos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDiasCredito.Text.Trim(), out int diasCredito) || diasCredito <= 0)
            {
                MessageBox.Show("Ingrese un número de días de crédito válido (mayor a 0).",
                    "Gestión de Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Lector lector = BuscarORegistrarLector(idLector);
            if (lector == null)
            {
                // El usuario cerró la ventana de registro sin completar el registro del lector.
                return;
            }

            DateTime fechaPrestamo = dtpFechaPrestamo.Value.Date;
            DateTime fechaDevolucion = fechaPrestamo.AddDays(diasCredito);

            var prestamo = new Prestamo
            {
                Id = _siguienteIdPrestamo++,
                IdLector = lector.IdLector,
                NombreLector = lector.NombreCompleto,
                Ejemplar = ejemplar,
                FechaPrestamo = fechaPrestamo,
                DiasCredito = diasCredito,
                FechaDevolucion = fechaDevolucion,
                Estado = "Activo"
            };
            Prestamos.Add(prestamo);

            dtpFechaDevolucion.Value = fechaDevolucion;
            CargarPrestamosEnGrid(FiltrarPrestamos());

            MessageBox.Show(
                $"Préstamo registrado para {lector.NombreCompleto}." +
                $"\nFecha de devolución: {fechaDevolucion:dd/MM/yyyy}.",
                "Gestión de Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Busca al lector por su ID en frmRegistroLector.Lectores. Si no existe,
        /// abre esa ventana (modal) para registrarlo; al cerrarla, vuelve a buscarlo.
        /// Devuelve null si el usuario cerró la ventana sin registrar al lector.
        /// </summary>
        private Lector BuscarORegistrarLector(string idLector)
        {
            var lector = frmRegistroLector.Lectores.FirstOrDefault(l => l.IdLector == idLector);
            if (lector != null) return lector;

            MessageBox.Show(
                "No se encontró un lector con ese ID. Se abrirá la ventana de registro.",
                "Lector no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            using (var frmLector = new frmRegistroLector { IdLectorSugerido = idLector })
            {
                frmLector.ShowDialog();
            }

            lector = frmRegistroLector.Lectores.FirstOrDefault(l => l.IdLector == idLector);
            if (lector == null)
            {
                MessageBox.Show(
                    "El lector no fue registrado, no se puede continuar con el préstamo.",
                    "Gestión de Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return lector;
        }

        private void btnBuscarLector_Click(object sender, EventArgs e)
        {
            string idLector = txtIdLector.Text.Trim();
            if (string.IsNullOrWhiteSpace(idLector))
            {
                MessageBox.Show("Ingrese un ID de lector para buscar.", "Buscar lector",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lector = frmRegistroLector.Lectores.FirstOrDefault(l => l.IdLector == idLector);
            if (lector != null)
            {
                MessageBox.Show($"Lector encontrado: {lector.NombreCompleto} ({lector.Tipo}).",
                    "Buscar lector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var respuesta = MessageBox.Show(
                "No existe un lector con ese ID. ¿Desea registrarlo ahora?",
                "Lector no encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                using var frmLector = new frmRegistroLector { IdLectorSugerido = idLector };
                frmLector.ShowDialog();
            }
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un préstamo de la lista.", "Gestión de Préstamos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvPrestamos.CurrentRow.Cells["IDPrestamo"].Value);
            var prestamo = Prestamos.FirstOrDefault(p => p.Id == id);
            if (prestamo == null) return;

            if (prestamo.Estado == "Devuelto")
            {
                MessageBox.Show("Este préstamo ya fue devuelto.", "Gestión de Préstamos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime hoy = DateTime.Today;
            int diasAtraso = (hoy - prestamo.FechaDevolucion).Days;

            prestamo.Estado = "Devuelto";

            if (diasAtraso > 0)
            {
                decimal monto = diasAtraso * TarifaPorDiaAtraso;

                frmGestionMultas.Multas.Add(new Multa
                {
                    Id = frmGestionMultas.SiguienteIdMulta(),
                    IdPrestamo = prestamo.Id,
                    Lector = prestamo.NombreLector,
                    Monto = monto,
                    Estado = "Pendiente",
                    FechaGeneracion = hoy
                });

                MessageBox.Show(
                    $"El préstamo tenía {diasAtraso} día(s) de atraso.\nSe generó una multa de C${monto:0.00}.",
                    "Multa generada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Devolución registrada dentro del plazo.", "Gestión de Préstamos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarPrestamosEnGrid(FiltrarPrestamos());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarPrestamosEnGrid(FiltrarPrestamos());
        }

        private List<Prestamo> FiltrarPrestamos()
        {
            DateTime hoy = DateTime.Today;

            return cmbPrestamos.SelectedItem?.ToString() switch
            {
                "Activos" => Prestamos.Where(p => p.Estado == "Activo" && p.FechaDevolucion >= hoy).ToList(),
                "Devueltos" => Prestamos.Where(p => p.Estado == "Devuelto").ToList(),
                "Atrasados" => Prestamos.Where(p => p.Estado == "Activo" && p.FechaDevolucion < hoy).ToList(),
                _ => Prestamos.ToList(),
            };
        }

        private void CargarPrestamosEnGrid(List<Prestamo> lista)
        {
            dgvPrestamos.Rows.Clear();

            foreach (var p in lista)
            {
                string estadoMostrado = p.Estado == "Activo" && p.FechaDevolucion < DateTime.Today
                    ? "Atrasado"
                    : p.Estado;

                dgvPrestamos.Rows.Add(
                    p.Id,
                    p.NombreLector,
                    p.Ejemplar,
                    p.FechaPrestamo.ToShortDateString(),
                    p.FechaDevolucion.ToShortDateString(),
                    estadoMostrado);
            }
        }

        private void lblUsuarios_Click(object sender, EventArgs e)
        {
        }

        private void lblPrestamos_Click(object sender, EventArgs e)
        {
        }
    }
}
