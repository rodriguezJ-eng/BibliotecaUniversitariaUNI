using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmRegistroLibro : Form
    {
        /// <summary>
        /// Libros registrados. Static por la misma razón que Lectores en
        /// frmRegistroLector: debe sobrevivir a que esta ventana se cierre y se
        /// vuelva a abrir con una instancia nueva desde frmMenu, y otras ventanas
        /// (como frmConsultasReportes) necesitan leer este catálogo.
        /// </summary>
        public static List<Libro> Libros { get; } = new List<Libro>();

        /// <summary>Autores registrados, disponibles para asociarse a un libro.</summary>
        public static List<Autor> Autores { get; } = new List<Autor>();

        public frmRegistroLibro()
        {
            InitializeComponent();
            CargarCategorias();
            ActualizarComboAutores();
            CargarLibrosEnGrid(Libros);
            CargarAutoresEnGrid(Autores);
        }


        private void CargarCategorias()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(new string[]
            {
                "Ingeniería",
                "Matemáticas",
                "Ciencias Básicas",
                "Tecnología",
                "Economía",
                "Literatura"
            });
        }

        // Datos generales del libro

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCamposLibro();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtISBN.Text) ||
                string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                string.IsNullOrWhiteSpace(cmbAutor.Text) ||
                cmbCategoria.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtAnio.Text) ||
                string.IsNullOrEmpty(txtEdicion.Text) ||
                string.IsNullOrWhiteSpace(txtEditorial.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos vacíos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtAnio.Text.Trim(), out int anio))
            {
                MessageBox.Show("El año debe ser un número entero válido.", "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnio.Focus();
                return;
            }

            if (Libros.Any(l => l.ISBN.Equals(txtISBN.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe un libro registrado con ese ISBN.", "ISBN duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtISBN.Focus();
                return;
            }

            var libro = new Libro
            {
                ISBN = txtISBN.Text.Trim(),
                Titulo = txtTitulo.Text.Trim(),
                Autor = cmbAutor.Text.Trim(),
                Categoria = cmbCategoria.Text,
                Anio = anio,
                Edicion = txtEdicion.Text.Trim(),
                Editorial = txtEditorial.Text.Trim()
            };

            Libros.Add(libro);
            CargarLibrosEnGrid(Libros);

            MessageBox.Show("El libro se ha registrado exitosamente.", "Libro Registrado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCamposLibro();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLibros.CurrentRow == null)
            {
                MessageBox.Show("Selecciona el libro que deseas editar.", "Selección vacía",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtISBN.Text) ||
                string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                string.IsNullOrWhiteSpace(cmbAutor.Text) ||
                cmbCategoria.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtAnio.Text) ||
                string.IsNullOrWhiteSpace(txtEditorial.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos vacíos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtAnio.Text.Trim(), out int anio))
            {
                MessageBox.Show("El año debe ser un número entero válido.", "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnio.Focus();
                return;
            }

            string isbnOriginal = Convert.ToString(dgvLibros.CurrentRow.Cells["dataGridViewTextBoxColumn1"].Value);
            var libro = Libros.FirstOrDefault(l => l.ISBN == isbnOriginal);

            if (libro == null)
            {
                MessageBox.Show("No se encontró el libro seleccionado.", "Registro Libro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nuevoIsbn = txtISBN.Text.Trim();
            if (!nuevoIsbn.Equals(isbnOriginal, StringComparison.OrdinalIgnoreCase) &&
                Libros.Any(l => l.ISBN.Equals(nuevoIsbn, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe otro libro registrado con ese ISBN.", "ISBN duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtISBN.Focus();
                return;
            }

            libro.ISBN = nuevoIsbn;
            libro.Titulo = txtTitulo.Text.Trim();
            libro.Autor = cmbAutor.Text.Trim();
            libro.Categoria = cmbCategoria.Text;
            libro.Anio = anio;
            libro.Editorial = txtEditorial.Text.Trim();

            CargarLibrosEnGrid(Libros);

            MessageBox.Show("El libro se ha actualizado exitosamente.", "Libro Actualizado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCamposLibro();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLibros.Rows.Count == 0 || dgvLibros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona la fila del libro que deseas eliminar.", "Selección vacía",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow filaSeleccionada = dgvLibros.SelectedRows[0];
            string isbn = Convert.ToString(filaSeleccionada.Cells["dataGridViewTextBoxColumn1"].Value);

            DialogResult resultado = MessageBox.Show("¿Estás seguro de eliminar este libro?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                var libro = Libros.FirstOrDefault(l => l.ISBN == isbn);
                if (libro != null)
                {
                    Libros.Remove(libro);
                }

                CargarLibrosEnGrid(Libros);

                MessageBox.Show("Libro eliminado correctamente.", "Eliminado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCamposLibro();
            }
        }

        private void LimpiarCamposLibro()
        {
            txtISBN.Clear();
            txtTitulo.Clear();
            cmbAutor.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
            txtAnio.Clear();
            txtEdicion.Clear();
            txtEditorial.Clear();
            txtISBN.Focus();
        }

        private void CargarLibrosEnGrid(List<Libro> lista)
        {
            dgvLibros.Rows.Clear();

            foreach (var libro in lista)
            {
                dgvLibros.Rows.Add(
                    libro.ISBN,
                    libro.Titulo,
                    libro.Autor,
                    libro.Categoria,
                    libro.Anio,
                    libro.Edicion,
                    libro.Editorial
                );
            }
        }

        // Autores

        private void btnNuevoAutor_Click_1(object sender, EventArgs e)
        {
            LimpiarCamposAutor();
        }

        private void btnGuardarAutor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdAutor.Text) ||
               string.IsNullOrWhiteSpace(txtNombreAutor.Text) ||
               string.IsNullOrWhiteSpace(txtApellidoAutor.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos vacíos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Autores.Any(a => a.Id.Equals(txtIdAutor.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe un autor registrado con ese ID.", "ID duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdAutor.Focus();
                return;
            }

            var autor = new Autor
            {
                Id = txtIdAutor.Text.Trim(),
                Nombre = txtNombreAutor.Text.Trim(),
                Apellido = txtApellidoAutor.Text.Trim()
            };

            Autores.Add(autor);
            CargarAutoresEnGrid(Autores);
            ActualizarComboAutores();

            MessageBox.Show("El autor se ha registrado exitosamente.", "Autor Registrado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCamposAutor();
        }

        private void btnEditarAutor_Click(object sender, EventArgs e)
        {
            if (dgvRegistroAutores.CurrentRow == null)
            {
                MessageBox.Show("Selecciona el autor que deseas editar.", "Selección vacía",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIdAutor.Text) ||
                string.IsNullOrWhiteSpace(txtNombreAutor.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoAutor.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos vacíos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idOriginal = Convert.ToString(dgvRegistroAutores.CurrentRow.Cells["Column2"].Value);
            var autor = Autores.FirstOrDefault(a => a.Id == idOriginal);

            if (autor == null)
            {
                MessageBox.Show("No se encontró el autor seleccionado.", "Registro Autor",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nuevoId = txtIdAutor.Text.Trim();
            if (!nuevoId.Equals(idOriginal, StringComparison.OrdinalIgnoreCase) &&
                Autores.Any(a => a.Id.Equals(nuevoId, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe otro autor registrado con ese ID.", "ID duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdAutor.Focus();
                return;
            }

            autor.Id = nuevoId;
            autor.Nombre = txtNombreAutor.Text.Trim();
            autor.Apellido = txtApellidoAutor.Text.Trim();

            CargarAutoresEnGrid(Autores);
            ActualizarComboAutores();

            MessageBox.Show("El autor se ha actualizado exitosamente.", "Autor Actualizado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCamposAutor();
        }

        private void btnEliminarAutor_Click(object sender, EventArgs e)
        {
            if (dgvRegistroAutores.Rows.Count == 0 || dgvRegistroAutores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona la fila del autor que deseas eliminar.", "Selección vacía",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow filaSeleccionada = dgvRegistroAutores.SelectedRows[0];
            string id = Convert.ToString(filaSeleccionada.Cells["Column2"].Value);

            DialogResult resultado = MessageBox.Show("¿Estás seguro de eliminar este autor?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                var autor = Autores.FirstOrDefault(a => a.Id == id);
                if (autor != null)
                {
                    Autores.Remove(autor);
                }

                CargarAutoresEnGrid(Autores);
                ActualizarComboAutores();

                MessageBox.Show("Autor eliminado correctamente.", "Eliminado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCamposAutor();
            }
        }

        private void LimpiarCamposAutor()
        {
            txtIdAutor.Clear();
            txtNombreAutor.Clear();
            txtApellidoAutor.Clear();
            txtIdAutor.Focus();
        }

        private void CargarAutoresEnGrid(List<Autor> lista)
        {
            dgvRegistroAutores.Rows.Clear();

            foreach (var autor in lista)
            {
                dgvRegistroAutores.Rows.Add(autor.Id, autor.Nombre, autor.Apellido);
            }
        }

        /// <summary>Refresca el combo de autores de la pestaña "Datos generales" con la lista actual.</summary>
        private void ActualizarComboAutores()
        {
            string seleccionActual = cmbAutor.Text;

            cmbAutor.Items.Clear();
            cmbAutor.Items.AddRange(Autores.Select(a => a.NombreCompleto).ToArray());

            int indice = cmbAutor.Items.IndexOf(seleccionActual);
            cmbAutor.SelectedIndex = indice;
        }
    }
}
