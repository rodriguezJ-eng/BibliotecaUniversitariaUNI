namespace BibliotecaUniversitaria.Forms
{
    /// <summary>Representa un libro registrado en el catálogo de la biblioteca.</summary>
    public class Libro
    {
        /// <summary>Clave primaria real de la tabla Libro (IDLibro). Se usa como
        /// clave foránea al registrar un Ejemplar en la base de datos.</summary>
        public int IDLibro { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public int Anio { get; set; }
        public string Edicion { get; set; } = string.Empty;
        public string Editorial { get; set; } = string.Empty;
    }
}
