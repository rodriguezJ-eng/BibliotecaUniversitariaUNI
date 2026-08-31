namespace BibliotecaUniversitaria.Forms
{
    /// <summary>Representa un ejemplar físico de un libro (una copia concreta que se puede prestar).</summary>
    public class Ejemplar
    {
        /// <summary>ISBN del libro al que pertenece este ejemplar.</summary>
        public string ISBNLibro { get; set; } = string.Empty;

        /// <summary>Código único que identifica físicamente al ejemplar (etiqueta, código de barras, etc.).</summary>
        public string Codigo { get; set; } = string.Empty;

        /// <summary>"Disponible", "Prestado", "En reparación" o "Extraviado".</summary>
        public string Estado { get; set; } = string.Empty;
    }
}
