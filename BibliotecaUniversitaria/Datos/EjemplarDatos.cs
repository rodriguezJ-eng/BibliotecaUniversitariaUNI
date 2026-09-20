using System;
using System.Collections.Generic;
using System.Configuration;
using BibliotecaUniversitaria.Forms;
using Microsoft.Data.SqlClient;

namespace BibliotecaUniversitaria.Datos
{
    /// <summary>
    /// Clase de acceso a datos para la tabla Ejemplar. Implementa las cuatro
    /// operaciones del CRUD (Insertar, ConsultarTodos, Actualizar, Eliminar)
    /// más dos consultas adicionales (filtro por estado y estadística por
    /// estado), todas mediante ADO.NET (SqlConnection/SqlCommand) e
    /// instrucciones Transact-SQL parametrizadas.
    ///
    /// la cadena de conexión se lee una sola vez en el constructor desde App.config, y
    /// CrearConexion() la usa para armar cada SqlConnection.
    /// </summary>
    /// 
    public class EjemplarDatos
    {
        private readonly string Cadena;

        public EjemplarDatos()
        {
            Cadena = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        }

        private SqlConnection CrearConexion()
        {
            return new SqlConnection(Cadena);
        }

        /// <summary>Crear. Inserta un nuevo ejemplar en la base de datos.</summary>
        public void Insertar(Ejemplar ejemplar)
        {
            const string sql = @"
                INSERT INTO Ejemplar (IDLibro, Codigo, Estado)
                VALUES (@IDLibro, @Codigo, @Estado);";

            using (SqlConnection conexion = CrearConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@IDLibro", ejemplar.IDLibro);
                comando.Parameters.AddWithValue("@Codigo", ejemplar.Codigo);
                comando.Parameters.AddWithValue("@Estado", ejemplar.Estado);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Leer. Consulta todos los ejemplares registrados.
        /// </summary>
        public List<Ejemplar> ConsultarTodos()
        {
            const string sql = @"
                SELECT IDEjemplar, IDLibro, Codigo, Estado
                FROM Ejemplar
                ORDER BY IDEjemplar;";

            List<Ejemplar> lista = new List<Ejemplar>();

            using (SqlConnection conexion = CrearConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(MapearEjemplar(lector));
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Filtro/consulta 1
        /// </summary>
        public List<Ejemplar> ConsultarPorEstado(string estado)
        {
            const string sql = @"
                SELECT IDEjemplar, IDLibro, Codigo, Estado
                FROM Ejemplar
                WHERE Estado = @Estado
                ORDER BY IDEjemplar;";

            List<Ejemplar> lista = new List<Ejemplar>();

            using (SqlConnection conexion = CrearConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@Estado", estado);

                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(MapearEjemplar(lector));
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Filtro/consulta 2: cuenta cuántos ejemplares existen por
        /// cada valor de Estado, usando una instrucción de agregación
        /// (COUNT + GROUP BY) directamente en SQL Server.
        /// </summary>
        public List<(string Estado, int Cantidad)> ConsultarEstadisticasPorEstado()
        {
            const string sql = @"
                SELECT Estado, COUNT(*) AS Cantidad
                FROM Ejemplar
                GROUP BY Estado
                ORDER BY Estado;";

            List<(string Estado, int Cantidad)> resultado = new List<(string, int)>();

            using (SqlConnection conexion = CrearConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        string estado = lector.GetString(lector.GetOrdinal("Estado"));
                        int cantidad = lector.GetInt32(lector.GetOrdinal("Cantidad"));
                        resultado.Add((estado, cantidad));
                    }
                }
            }

            return resultado;
        }

        /// <summary>Actualizar. Guarda los cambios de un ejemplar existente.</summary>
        public void Actualizar(Ejemplar ejemplar)
        {
            const string sql = @"
                UPDATE Ejemplar
                SET IDLibro = @IDLibro,
                    Codigo  = @Codigo,
                    Estado  = @Estado
                WHERE IDEjemplar = @IDEjemplar;";

            using (SqlConnection conexion = CrearConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@IDLibro", ejemplar.IDLibro);
                comando.Parameters.AddWithValue("@Codigo", ejemplar.Codigo);
                comando.Parameters.AddWithValue("@Estado", ejemplar.Estado);
                comando.Parameters.AddWithValue("@IDEjemplar", ejemplar.IDEjemplar);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        /// <summary>Eliminar. Borra un ejemplar según su identificador.</summary>
        public void Eliminar(int idEjemplar)
        {
            const string sql = "DELETE FROM Ejemplar WHERE IDEjemplar = @IDEjemplar;";

            using (SqlConnection conexion = CrearConexion())
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@IDEjemplar", idEjemplar);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Convierte la fila actual del SqlDataReader en un objeto Ejemplar.
        /// </summary>
        private static Ejemplar MapearEjemplar(SqlDataReader lector)
        {
            return new Ejemplar
            {
                IDEjemplar = lector.GetInt32(lector.GetOrdinal("IDEjemplar")),
                IDLibro = lector.GetInt32(lector.GetOrdinal("IDLibro")),
                Codigo = lector.GetString(lector.GetOrdinal("Codigo")),
                Estado = lector.GetString(lector.GetOrdinal("Estado"))
            };
        }
    }
}
