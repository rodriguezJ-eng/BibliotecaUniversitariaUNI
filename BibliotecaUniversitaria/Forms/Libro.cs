namespace BibliotecaUniversitaria.Forms
{
    /// <summary>Representa un libro registrado en el catálogo de la biblioteca.</summary>
    public class Libro
    {
        public string ISBN { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public int Anio { get; set; }
        public string Edicion { get; set; } = string.Empty;
        public string Editorial { get; set; } = string.Empty;
    }
}
