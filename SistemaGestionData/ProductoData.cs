using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public class ProductoData
    {

        static string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
        public static Producto ObtenerProducto(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string obtenerQuery = "SELECT * FROM Producto WHERE Id = @id";

                SqlCommand command = new SqlCommand(obtenerQuery, conn);
                command.Parameters.AddWithValue("id", id);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int productoId = Convert.ToInt32(reader[0]);
                    string descripcion = reader.GetString(1);
                    double costo = Convert.ToDouble(reader[2]);
                    double precioVenta = Convert.ToDouble(reader[3]);
                    int stock = Convert.ToInt32(reader[4]);
                    int idUsuario = Convert.ToInt32(reader[5]);

                    Producto producto = new Producto();
                    producto.Id = productoId;
                    producto.Descripcion = descripcion;
                    producto.Costo = costo;
                    producto.PrecioVenta = precioVenta;
                    producto.Stock = stock;
                    producto.idUsuario = idUsuario;

                    return producto;
                }
                throw new Exception("Producto no encontrado");
            }
        }

        public static List<Producto> ListarProductos()
        {
            List<Producto> listaDeProducto = new List<Producto>();

            string query = "SELECT Id, Descripcion, Costo, PrecioVenta, Stock, IdUsuario from Producto";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Producto producto = new Producto();

                            producto.Id = Convert.ToInt32(dataReader["Id"]);
                            producto.Descripcion = dataReader["Descripcion"].ToString();
                            producto.Costo = Convert.ToDouble(dataReader["Costo"]);
                            producto.PrecioVenta = Convert.ToDouble(dataReader["PrecioVenta"]);
                            producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                            producto.idUsuario = Convert.ToInt32(dataReader["IdUsuario"]);

                            listaDeProducto.Add(producto);
                        }
                    }
                }

            }
            return listaDeProducto;

        }

        public static bool CrearProducto(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string crearQuery = "INSERT INTO Producto(Descripcion,Costo,PrecioVenta,Stock,IdUsuario) values (@descripcion,@costo,@precioVenta,@stock,@idUsuario);";

                SqlCommand command = new SqlCommand(crearQuery, conn);

                command.Parameters.AddWithValue("descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("costo", producto.Costo);
                command.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("stock", producto.Stock);
                command.Parameters.AddWithValue("idUsuario", producto.idUsuario);

                conn.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool ModificarProducto(int id, Producto producto)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string modificarQuery = "UPDATE Producto SET Descripcion= @descripcion, Costo= @costo, PrecioVenta= @precioVenta, Stock= @stock, IdUsuario= @idUsuario WHERE Id = @id";

                SqlCommand command = new SqlCommand(modificarQuery, connection);

                command.Parameters.AddWithValue("descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("costo", producto.Costo);
                command.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("stock", producto.Stock);
                command.Parameters.AddWithValue("IdUsuario", producto.idUsuario);
                command.Parameters.AddWithValue("id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }

        }

        public static bool EliminarProducto(int productoId)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string eliminarQuery = "DELETE FROM Producto WHERE Id= @idProducto";
                SqlCommand command = new SqlCommand(eliminarQuery, conn);
                conn.Open();
                command.Parameters.AddWithValue("idProducto", productoId);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
