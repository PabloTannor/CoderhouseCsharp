using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class ProductoVendidoBussines
    {
        public static List<ProductoVendido> GetProductoVendido()
        {
            return ProductoVendidoData.ListarProductoVendidos();
        }

        public static ProductoVendido ObtenerProductoVendido(int idPv)
        {
            return ProductoVendidoData.ObtenerProductoVendido(idPv);
        }

        public static bool CrearProductoVendido(ProductoVendido pv)
        {
            return ProductoVendidoData.CrearProductoVendido(pv);
        }

        public static bool ModificarProductoVendido(int id, ProductoVendido pv)
        {
            return ProductoVendidoData.ModificarProductoVendido(id, pv);
        }

        public static bool EliminarProductoVendido(int pvId)
        {
            return ProductoVendidoData.EliminarProductoVendido(pvId);
        }
    }
}

