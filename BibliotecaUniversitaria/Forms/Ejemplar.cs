namespace BibliotecaUniversitaria.Forms
{
    /// <summary>
    /// Representa un ejemplar físico de un libro (una copia concreta que se
    /// puede prestar). Corresponde directamente a una fila de la tabla
    /// Ejemplar de la base de datos BibliotecaUniversitaria:
    /// </summary>
    public class Ejemplar
    {
        /// <summary>Clave primaria de la tabla Ejemplar (IDENTITY).</summary>
        public int IDEjemplar { get; set; }

        /// <summary>Clave foránea hacia Libro (IDLibro).</summary>
        public int IDLibro { get; set; }

        /// <summary>Código único que identifica físicamente al ejemplar.</summary>
        public string Codigo { get; set; } = string.Empty;

        /// <summary>"Disponible", "Prestado", "En reparación" o "Baja".</summary>
        public string Estado { get; set; } = string.Empty;

        /// <summary>
        /// Título del libro al que pertenece el ejemplar. No es una columna de
        /// la tabla Ejemplar: se obtiene mediante un JOIN con Libro únicamente
        /// para mostrarlo en el DataGridView.
        /// </summary>
        public string TituloLibro { get; set; } = string.Empty;
    }
}
