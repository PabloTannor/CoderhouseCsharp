using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class UsuarioBussiness
    {
        public static List<Usuario> GetUsuarios()
        {
            return UsuarioData.ListarUsuarios();
        }

        public static Usuario ObtenerUsuario(int idUser)
        {
            return UsuarioData.ObtenerUsuario(idUser);
        }

        public static bool CrearUsuario(Usuario user)
        {
            return UsuarioData.CrearUsuario(user);
        }

        public static bool ModificarUsuario(int id, Usuario user)
        {
            return UsuarioData.ModificarUsuario(id,user);
        }

        public static bool EliminarUsuario(int userId)
        {
            return UsuarioData.EliminarUsuario(userId);
        }
    }
}
