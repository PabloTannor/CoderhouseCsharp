using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVenta")]
        public IEnumerable<Venta> ventas()
        {
            return VentaBussines.GetVenta().ToArray();
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerVenta(int id)
        {
            Venta venta = VentaBussines.ObtenerVenta(id);

            return Ok(venta);
        }

        [HttpDelete(Name = "EliminarVenta")]
        public void Delete([FromBody] int id)
        {
            VentaBussines.EliminarVenta(id);
        }

        /*[HttpPut(Name = "ModificarVenta")]
        public void Put([FromBody] int id, Venta venta)
        {
            VentaBussines.ModificarVenta(id, venta);
        }*/

        [HttpPost(Name = "AltaVenta")]
        public void Post([FromBody]Venta venta)
        {
            VentaBussines.CrearVenta(venta);
        }

    }
}
