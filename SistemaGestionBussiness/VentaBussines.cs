using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class VentaBussines
    {
        public static List<Venta> GetVenta()
        {
            return VentaData.ListarVenta();
        }

        public static Venta ObtenerVenta(int idVenta)
        {
            return VentaData.ObtenerVenta(idVenta);
        }

        public static bool CrearVenta(Venta venta)
        {
            return VentaData.CrearVenta(venta);
        }

        public static bool ModificarVenta(int id, Venta venta)
        {
            return VentaData.ModificarVenta(id, venta);
        }

        public static bool EliminarVenta(int ventaId)
        {
            return VentaData.EliminarVenta(ventaId);
        }
    }
}
