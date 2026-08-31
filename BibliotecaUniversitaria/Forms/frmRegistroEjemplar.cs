using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmRegistroEjemplar : Form
    {
        /// <summary>
        /// Ejemplares registrados. Static por la misma razón que Lectores en
        /// frmRegistroLector: debe sobrevivir a que esta ventana se cierre y se
        /// vuelva a abrir con una instancia nueva desde frmMenu.
        /// </summary>
        public static List<Ejemplar> Ejemplares { get; } = new List<Ejemplar>();

        /// <summary>Libros disponibles en el mismo orden en que aparecen en cmbLibro.</summary>
        private List<Libro> _librosParaCombo = new List<Libro>();

        public frmRegistroEjemplar()
        {
            InitializeComponent();

            cmbLibro.SelectedIndexChanged += cmbLibro_SelectedIndexChanged;

            CargarLibrosEnCombo();
            ActualizarGridEjemplares();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            cmbCodigo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Libro libro = ObtenerLibroSeleccionado();
            string codigo = cmbCodigo.Text.Trim();

            if (libro == null)
            {
                MessageBox.Show("Selecciona el libro al que pertenece el ejemplar.", "Campos vacíos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(codigo) || cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos vacíos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Ejemplares.Any(ej => ej.ISBNLibro == libro.ISBN &&
                                     ej.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe un ejemplar con ese código para este libro.", "Código duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCodigo.Focus();
                return;
            }

            var ejemplar = new Ejemplar
            {
                ISBNLibro = libro.ISBN,
                Codigo = codigo,
                Estado = cmbEstado.Text
            };

            Ejemplares.Add(ejemplar);
            ActualizarGridEjemplares();

            MessageBox.Show("El ejemplar se ha registrado exitosamente.", "Ejemplar Registrado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos(mantenerLibroSeleccionado: true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Libro libro = ObtenerLibroSeleccionado();

            if (libro == null)
            {
                MessageBox.Show("Selecciona el libro al que pertenece el ejemplar.", "Campos vacíos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvEjemplares.CurrentRow == null)
            {
                MessageBox.Show("Selecciona el ejemplar que deseas editar.", "Selección vacía",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codigoOriginal = Convert.ToString(dgvEjemplares.CurrentRow.Cells["dataGridViewTextBoxColumn1"].Value);
            var ejemplar = Ejemplares.FirstOrDefault(ej => ej.ISBNLibro == libro.ISBN && ej.Codigo == codigoOriginal);

            if (ejemplar == null)
            {
                MessageBox.Show("No se encontró el ejemplar seleccionado.", "Registro Ejemplar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nuevoCodigo = cmbCodigo.Text.Trim();

            if (string.IsNullOrWhiteSpace(nuevoCodigo) || cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos vacíos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!nuevoCodigo.Equals(codigoOriginal, StringComparison.OrdinalIgnoreCase) &&
                Ejemplares.Any(ej => ej.ISBNLibro == libro.ISBN &&
                                     ej.Codigo.Equals(nuevoCodigo, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe otro ejemplar con ese código para este libro.", "Código duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCodigo.Focus();
                return;
            }

            ejemplar.Codigo = nuevoCodigo;
            ejemplar.Estado = cmbEstado.Text;

            ActualizarGridEjemplares();

            MessageBox.Show("El ejemplar se ha actualizado exitosamente.", "Ejemplar Actualizado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos(mantenerLibroSeleccionado: true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Libro libro = ObtenerLibroSeleccionado();

            if (libro == null || dgvEjemplares.Rows.Count == 0 || dgvEjemplares.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona el ejemplar que deseas eliminar.", "Selección vacía",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow filaSeleccionada = dgvEjemplares.SelectedRows[0];
            string codigo = Convert.ToString(filaSeleccionada.Cells["dataGridViewTextBoxColumn1"].Value);

            DialogResult resultado = MessageBox.Show("¿Estás seguro de eliminar este ejemplar?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                var ejemplar = Ejemplares.FirstOrDefault(ej => ej.ISBNLibro == libro.ISBN && ej.Codigo == codigo);
                if (ejemplar != null)
                {
                    Ejemplares.Remove(ejemplar);
                }

                ActualizarGridEjemplares();

                MessageBox.Show("Ejemplar eliminado correctamente.", "Eliminado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos(mantenerLibroSeleccionado: true);
            }
        }

        private void cmbLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarGridEjemplares();
        }

        private void LimpiarCampos(bool mantenerLibroSeleccionado = false)
        {
            if (!mantenerLibroSeleccionado)
            {
                cmbLibro.SelectedIndex = -1;
            }

            cmbCodigo.SelectedIndex = -1;
            cmbCodigo.Text = string.Empty;
            cmbEstado.SelectedIndex = -1;
        }

        /// <summary>Carga en cmbLibro los libros registrados en frmRegistroLibro (ISBN - Título).</summary>
        private void CargarLibrosEnCombo()
        {
            string seleccionActual = cmbLibro.Text;

            _librosParaCombo = frmRegistroLibro.Libros.ToList();

            cmbLibro.Items.Clear();
            foreach (var libro in _librosParaCombo)
            {
                cmbLibro.Items.Add($"{libro.ISBN} - {libro.Titulo}");
            }

            int indice = cmbLibro.Items.IndexOf(seleccionActual);
            cmbLibro.SelectedIndex = indice;
        }

        private Libro ObtenerLibroSeleccionado()
        {
            if (cmbLibro.SelectedIndex < 0 || cmbLibro.SelectedIndex >= _librosParaCombo.Count)
            {
                return null;
            }

            return _librosParaCombo[cmbLibro.SelectedIndex];
        }

        /// <summary>Muestra en dgvEjemplares solo los ejemplares del libro seleccionado en cmbLibro.</summary>
        private void ActualizarGridEjemplares()
        {
            dgvEjemplares.Rows.Clear();
            cmbCodigo.Items.Clear();

            Libro libro = ObtenerLibroSeleccionado();
            if (libro == null)
            {
                return;
            }

            var ejemplaresDelLibro = Ejemplares.Where(ej => ej.ISBNLibro == libro.ISBN).ToList();

            foreach (var ejemplar in ejemplaresDelLibro)
            {
                dgvEjemplares.Rows.Add(ejemplar.Codigo, ejemplar.Estado);
                cmbCodigo.Items.Add(ejemplar.Codigo);
            }
        }
    }
}
