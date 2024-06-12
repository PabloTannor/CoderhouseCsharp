using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public class UsuarioData
    {
        static string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
        public static Usuario ObtenerUsuario(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string obtenerQuery = "SELECT * FROM Usuario WHERE Id = @id";

                SqlCommand command = new SqlCommand(obtenerQuery, conn);
                command.Parameters.AddWithValue("id", id);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int userId = Convert.ToInt32(reader[0]);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    string nombreUsuario = reader.GetString(3);
                    string pass = reader.GetString(4);
                    string mail = reader.GetString(5);

                    Usuario usuario = new Usuario();
                    usuario.Id = userId;
                    usuario.Nombre = nombre;
                    usuario.Apellido = apellido;
                    usuario.NombreUsuario = nombreUsuario;
                    usuario.Contrasenia = pass;
                    usuario.Mail = mail;

                    return usuario;
                }
                throw new Exception("Id no encontrado");
            }
        }

        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> listaDeUsuarios = new List<Usuario>();

            string query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail from Usuario";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows) 
                            {
                                while (dataReader.Read())
                                {
                                    Usuario user = new Usuario();

                                    user.Id = Convert.ToInt32(dataReader["Id"]);
                                    user.Nombre = dataReader["Nombre"].ToString();
                                    user.Apellido = dataReader["Apellido"].ToString();
                                    user.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                    user.Contrasenia = dataReader["Contraseña"].ToString();
                                    user.Mail = dataReader["Mail"].ToString();

                                    listaDeUsuarios.Add(user);
                                }
                            }
                            return listaDeUsuarios;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return listaDeUsuarios;
            }
            

        }

        public static bool CrearUsuario(Usuario user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string crearQuery = "INSERT INTO Usuario(Nombre,Apellido,NombreUsuario,Contraseña,Mail) values (@nombre,@apellido,@nombreUsuario,@pass,@mail);";

                SqlCommand command = new SqlCommand(crearQuery, conn);

                command.Parameters.AddWithValue("nombre", user.Nombre);
                command.Parameters.AddWithValue("apellido", user.Apellido);
                command.Parameters.AddWithValue("nombreUsuario", user.NombreUsuario);
                command.Parameters.AddWithValue("pass", user.Contrasenia);
                command.Parameters.AddWithValue("mail", user.Mail);

                conn.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool ModificarUsuario(int id, Usuario user)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string modificarQuery = "UPDATE Usuario SET Nombre = @nombre, Apellido= @apellido, NombreUsuario= @nombreUsuario, Contraseña= @pass, Mail= @mail WHERE Id = @id";

                SqlCommand command = new SqlCommand(modificarQuery, connection);

                command.Parameters.AddWithValue("nombre", user.Nombre);
                command.Parameters.AddWithValue("apellido", user.Apellido);
                command.Parameters.AddWithValue("nombreUsuario", user.NombreUsuario);
                command.Parameters.AddWithValue("pass", user.Contrasenia);
                command.Parameters.AddWithValue("mail", user.Mail);
                command.Parameters.AddWithValue("id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }

        }

        public static bool EliminarUsuario(int userId)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string eliminarQuery = "DELETE FROM Usuario WHERE Id= @idUser";
                SqlCommand command = new SqlCommand(eliminarQuery, conn);
                conn.Open();
                command.Parameters.AddWithValue("idUser", userId);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
