using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public class ProductoVendidoData
    {
        static string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
        public static ProductoVendido ObtenerProductoVendido(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string obtenerQuery = "SELECT * FROM ProductoVendido WHERE Id = @id";

                SqlCommand command = new SqlCommand(obtenerQuery, conn);
                command.Parameters.AddWithValue("id", id);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int pvId = Convert.ToInt32(reader[0]);
                    int stock = Convert.ToInt32(reader[1]);
                    int idproducto = Convert.ToInt32(reader[2]);
                    int idventa = Convert.ToInt32(reader[3]);

                    ProductoVendido pventa = new ProductoVendido();
                    pventa.Id = pvId;
                    pventa.Stock = stock;
                    pventa.idProducto = idproducto;
                    pventa.idVenta = idventa;

                    return pventa;
                }
                throw new Exception("Id no encontrado");
            }
        }

        public static List<ProductoVendido> ListarProductoVendidos()
        {
            List<ProductoVendido> listaDeProductosVendidos = new List<ProductoVendido>();

            string query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            ProductoVendido pv = new ProductoVendido();

                            pv.Id = Convert.ToInt32(dataReader["Id"]);
                            pv.Stock = Convert.ToInt32(dataReader["Stock"]);
                            pv.idProducto = Convert.ToInt32(dataReader["IdProducto"]);
                            pv.idVenta = Convert.ToInt32(dataReader["IdVenta"]);

                            listaDeProductosVendidos.Add(pv);
                        }
                    }
                }

            }
            return listaDeProductosVendidos;

        }

        public static bool CrearProductoVendido(ProductoVendido pVendido)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string crearQuery = "INSERT INTO ProductoVendido(Stock,IdProducto,IdVenta) values (@stock,@idProducto,@idVenta);";

                SqlCommand command = new SqlCommand(crearQuery, conn);

                command.Parameters.AddWithValue("stock", pVendido.Stock);
                command.Parameters.AddWithValue("idProducto", pVendido.idProducto);
                command.Parameters.AddWithValue("idVenta", pVendido.idVenta);

                conn.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool ModificarProductoVendido(int id, ProductoVendido pVendido)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string modificarQuery = "UPDATE ProductoVendido SET Stock= @stock, IdProducto= @idProducto, IdVenta= @idVenta WHERE Id = @id";

                SqlCommand command = new SqlCommand(modificarQuery, connection);

                command.Parameters.AddWithValue("stock", pVendido.Stock);
                command.Parameters.AddWithValue("idProducto", pVendido.idProducto);
                command.Parameters.AddWithValue("idVenta", pVendido.idVenta);
                command.Parameters.AddWithValue("id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }

        }

        public static bool EliminarProductoVendido(int pvId)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string eliminarQuery = "DELETE FROM ProductoVendido WHERE Id= @pvId";
                SqlCommand command = new SqlCommand(eliminarQuery, conn);
                conn.Open();
                command.Parameters.AddWithValue("pvId", pvId);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
