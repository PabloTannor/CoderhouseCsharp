using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public class VentaData
    {
            
        static string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
        public static Venta ObtenerVenta(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string obtenerQuery = "SELECT * FROM Venta WHERE Id = @id";

                SqlCommand command = new SqlCommand(obtenerQuery, conn);
                command.Parameters.AddWithValue("id", id);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int ventaId = Convert.ToInt32(reader[0]);
                    string comentarios = reader.GetString(1);
                    int idusuario = Convert.ToInt32(reader[2]);

                    Venta venta = new Venta();
                    venta.Id = ventaId;
                    venta.Comentarios = comentarios;
                    venta.idUsuario = idusuario;

                    return venta;
                }
                throw new Exception("Venta no encontrada");
            }
        }

        public static List<Venta> ListarVenta()
        {
            List<Venta> listaDeVenta = new List<Venta>();

            string query = "SELECT Id, Comentarios, IdUsuario from Venta";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Venta venta = new Venta();

                            venta.Id = Convert.ToInt32(dataReader["Id"]);
                            venta.Comentarios = dataReader["Comentarios"].ToString();
                            venta.idUsuario = Convert.ToInt32(dataReader["Idusuario"]);

                            listaDeVenta.Add(venta);
                        }
                    }
                }

            }
            return listaDeVenta;

        }

        public static bool CrearVenta(Venta venta)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string crearQuery = "INSERT INTO Venta(Comentarios,IdUsuario) values (@s,@idUsuario);";

                SqlCommand command = new SqlCommand(crearQuery, conn);

                command.Parameters.AddWithValue("comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("idUduario", venta.idUsuario);

                conn.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool ModificarVenta(int id, Venta venta)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string modificarQuery = "UPDATE Venta SET Comentarios = @comentarios, IdUsuario= @idUsuario WHERE Id = @id";

                SqlCommand command = new SqlCommand(modificarQuery, connection);

                command.Parameters.AddWithValue("comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("apellido", venta.idUsuario);
                command.Parameters.AddWithValue("id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }

        }

        public static bool EliminarVenta(int ventaId)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string eliminarQuery = "DELETE FROM Venta WHERE Id= @ventaId";
                SqlCommand command = new SqlCommand(eliminarQuery, conn);
                conn.Open();
                command.Parameters.AddWithValue("ventaId", ventaId);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
