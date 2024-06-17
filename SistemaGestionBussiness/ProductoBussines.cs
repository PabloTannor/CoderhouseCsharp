using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class ProductoBussines
    {
        public static List<Producto> GetProductos()
        {
            return ProductoData.ListarProductos();
        }

        public static Producto ObtenerProducto(int idProducto)
        {
            return ProductoData.ObtenerProducto(idProducto);
        }

        public static bool CrearProducto(Producto produc)
        {
            return ProductoData.CrearProducto(produc);
        }

        public static bool ModificarProducto(int id, Producto product)
        {
            return ProductoData.ModificarProducto(id, product);
        }

        public static bool EliminarProducto(int productoId)
        {
            return ProductoData.EliminarProducto(productoId);
        }
    }
}
