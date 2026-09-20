using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaUniversitaria.Datos;
using Microsoft.Data.SqlClient;

namespace BibliotecaUniversitaria.Forms
{
    public partial class frmRegistroEjemplar : Form
    {
        private readonly EjemplarDatos _datosEjemplar = new EjemplarDatos();

        /// <summary>Libros disponibles en el mismo orden en que aparecen en cmbLibro.</summary>
        private List<Libro> _librosParaCombo = new List<Libro>();

        /// <summary>IDEjemplar de la fila seleccionada en el grid (null = modo "nuevo").</summary>
        private int? _idEjemplarSeleccionado = null;

        public frmRegistroEjemplar()
        {
            InitializeComponent();

            CargarLibrosParaCombo();
            cmbFiltroEstado.SelectedIndex = 0; // "Todos"

            ConsultarTodosYMostrar();
        }

        // CRUD

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtCodigo.Focus();
        }

        /// <summary>Crear un nuevo ejemplar.</summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Libro libro = ObtenerLibroSeleccionado();
            string codigo = txtCodigo.Text.Trim();

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

            var ejemplar = new Ejemplar
            {
                IDLibro = libro.IDLibro,
                Codigo = codigo,
                Estado = cmbEstado.Text
            };

            try
            {
                _datosEjemplar.Insertar(ejemplar);

                MessageBox.Show("El ejemplar se ha registrado exitosamente.", "Ejemplar registrado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos(mantenerLibroSeleccionado: true);
                ConsultarTodosYMostrar();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("Ya existe un ejemplar con ese código.", "Código duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar el ejemplar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Actualizar el ejemplar seleccionado en el grid.</summary>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_idEjemplarSeleccionado == null)
            {
                MessageBox.Show("Selecciona en el listado el ejemplar que deseas editar.", "Selección vacía",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Libro libro = ObtenerLibroSeleccionado();
            string codigo = txtCodigo.Text.Trim();

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

            var ejemplar = new Ejemplar
            {
                IDEjemplar = _idEjemplarSeleccionado.Value,
                IDLibro = libro.IDLibro,
                Codigo = codigo,
                Estado = cmbEstado.Text
            };

            try
            {
                _datosEjemplar.Actualizar(ejemplar);

                MessageBox.Show("El ejemplar se ha actualizado exitosamente.", "Ejemplar actualizado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                ConsultarTodosYMostrar();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("Ya existe otro ejemplar con ese código.", "Código duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al actualizar el ejemplar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Eliminar el ejemplar seleccionado en el grid.</summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idEjemplarSeleccionado == null)
            {
                MessageBox.Show("Selecciona en el listado el ejemplar que deseas eliminar.", "Selección vacía",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Estás seguro de eliminar este ejemplar?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _datosEjemplar.Eliminar(_idEjemplarSeleccionado.Value);

                MessageBox.Show("Ejemplar eliminado correctamente.", "Eliminado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                ConsultarTodosYMostrar();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                // Violación de una restricción FOREIGN KEY (por ejemplo, el
                // ejemplar tiene préstamos asociados).
                MessageBox.Show(
                    "No se puede eliminar este ejemplar porque tiene información relacionada " +
                    "(por ejemplo, préstamos) en otra tabla.",
                    "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al eliminar el ejemplar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // READ - Consultar / Filtros / Estadística


        /// <summary>Consulta todos los ejemplares y los muestra en el grid.</summary>
        private void ConsultarTodosYMostrar()
        {
            try
            {
                List<Ejemplar> lista = _datosEjemplar.ConsultarTodos();
                MostrarEnGrid(lista);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible consultar los ejemplares en la base de datos:\n" + ex.Message,
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            cmbFiltroEstado.SelectedIndex = 0; // "Todos"
            ConsultarTodosYMostrar();
        }

        /// <summary>Filtro 1: consulta los ejemplares por Estado.</summary>
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string estado = cmbFiltroEstado.Text;

            if (string.IsNullOrWhiteSpace(estado) || estado == "Todos")
            {
                ConsultarTodosYMostrar();
                return;
            }

            try
            {
                List<Ejemplar> lista = _datosEjemplar.ConsultarPorEstado(estado);
                MostrarEnGrid(lista);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al filtrar los ejemplares:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Filtro 2: cuenta los ejemplares agrupados por Estado.</summary>
        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            try
            {
                List<(string Estado, int Cantidad)> estadisticas = _datosEjemplar.ConsultarEstadisticasPorEstado();

                if (estadisticas.Count == 0)
                {
                    txtEstadisticas.Text = "No hay ejemplares registrados.";
                    return;
                }

                var lineas = new List<string>();
                foreach (var fila in estadisticas)
                {
                    lineas.Add($"{fila.Estado}: {fila.Cantidad}");
                }

                txtEstadisticas.Text = string.Join("   |   ", lineas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al calcular las estadísticas:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga en el grid una lista de ejemplares ya consultada. El título
        /// del libro no viene de la base de datos: se busca en la lista en
        /// memoria _librosParaCombo (entidad auxiliar), igual que hace el
        /// ComboBox.
        /// </summary>
        private void MostrarEnGrid(List<Ejemplar> lista)
        {
            dgvEjemplares.Rows.Clear();

            foreach (Ejemplar ejemplar in lista)
            {
                string tituloLibro = ObtenerTituloLibro(ejemplar.IDLibro);

                dgvEjemplares.Rows.Add(
                    ejemplar.IDEjemplar,
                    ejemplar.IDLibro,
                    ejemplar.Codigo,
                    ejemplar.Estado,
                    tituloLibro);
            }
        }

        /// <summary>Busca el título de un libro en la lista predeterminada en memoria, a partir de su IDLibro.</summary>
        private string ObtenerTituloLibro(int idLibro)
        {
            Libro libro = _librosParaCombo.Find(l => l.IDLibro == idLibro);
            return libro != null ? libro.Titulo : "(libro no encontrado)";
        }

        /// <summary>Al seleccionar una fila del grid, se cargan sus datos en los controles para editar o eliminar.</summary>
        private void dgvEjemplares_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila = dgvEjemplares.Rows[e.RowIndex];

            _idEjemplarSeleccionado = Convert.ToInt32(fila.Cells["colIDEjemplar"].Value);
            int idLibro = Convert.ToInt32(fila.Cells["colIDLibro"].Value);
            string codigo = Convert.ToString(fila.Cells["colCodigo"].Value);
            string estado = Convert.ToString(fila.Cells["colEstado"].Value);

            int indiceLibro = _librosParaCombo.FindIndex(l => l.IDLibro == idLibro);
            cmbLibro.SelectedIndex = indiceLibro;

            txtCodigo.Text = codigo;
            cmbEstado.SelectedItem = estado;
        }

        // Auxiliares

        private void LimpiarCampos(bool mantenerLibroSeleccionado = false)
        {
            if (!mantenerLibroSeleccionado)
            {
                cmbLibro.SelectedIndex = -1;
            }

            txtCodigo.Text = string.Empty;
            cmbEstado.SelectedIndex = -1;
            _idEjemplarSeleccionado = null;
        }

        /// <summary>
        /// Carga en cmbLibro los libros existentes. Libro es una entidad
        /// auxiliar (Ejemplar depende de ella mediante la clave foránea
        /// IDLibro)
        /// </summary>
        private void CargarLibrosParaCombo()
        {
            _librosParaCombo = ObtenerLibrosPredeterminados();

            cmbLibro.Items.Clear();
            foreach (Libro libro in _librosParaCombo)
            {
                cmbLibro.Items.Add($"{libro.IDLibro} - {libro.Titulo}");
            }
        }

        /// <summary>
        /// Lista predeterminada en memoria (entidad auxiliar Libro). Los
        /// mismos IDLibro deben existir realmente en la tabla Libro de la
        /// base de datos, ya que se usan como clave foránea al guardar un
        /// Ejemplar.
        /// </summary>
        private static List<Libro> ObtenerLibrosPredeterminados()
        {
            return new List<Libro>
            {
                new Libro { IDLibro = 1, Titulo = "Matemáticas Aplicadas a la Ingeniería" },
                new Libro { IDLibro = 2, Titulo = "El prodigio de los números : desafíos, paradojas y curiosidades matemáticas" },
                new Libro { IDLibro = 3, Titulo = "Matemática básica" },
                new Libro { IDLibro = 4, Titulo = "Matemáticas aplicadas : para administración, economía y ciencias sociales" },
                new Libro { IDLibro = 5, Titulo = "Fundamentos de programación : algoritmos y estructuras de datos" },
                new Libro { IDLibro = 6, Titulo = "Introducción a la programación estructurada en C" },
                new Libro { IDLibro = 7, Titulo = "Metodología y tecnología de la programación" },
                new Libro { IDLibro = 8, Titulo = "Mecánica para ingeniería: dinámica" },
                new Libro { IDLibro = 9, Titulo = "Mecánica de fluidos para ingenieros" },
                new Libro { IDLibro = 10, Titulo = "Redes de Computadoras" },
            };
        }

        private Libro ObtenerLibroSeleccionado()
        {
            if (cmbLibro.SelectedIndex < 0 || cmbLibro.SelectedIndex >= _librosParaCombo.Count)
            {
                return null;
            }

            return _librosParaCombo[cmbLibro.SelectedIndex];
        }

        /// <summary>
        /// Punto de acceso para otras pantallas del proyecto (por ejemplo,
        /// frmGestionPrestamos) que antes leían la lista estática en memoria
        /// "Ejemplares".
        /// </summary>
        public static List<Ejemplar> ObtenerEjemplaresDisponibles()
        {
            try
            {
                List<Ejemplar> disponibles = new EjemplarDatos().ConsultarPorEstado("Disponible");
                List<Libro> libros = ObtenerLibrosPredeterminados();

                foreach (Ejemplar ejemplar in disponibles)
                {
                    Libro libro = libros.Find(l => l.IDLibro == ejemplar.IDLibro);
                    ejemplar.TituloLibro = libro != null ? libro.Titulo : "(libro no encontrado)";
                }

                return disponibles;
            }
            catch (Exception)
            {
                return new List<Ejemplar>();
            }
        }
    }
}
