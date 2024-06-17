using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet(Name = "GetProductoVendido")]
        public IEnumerable<ProductoVendido> ProductosVendidos()
        {
            return ProductoVendidoBussines.GetProductoVendido().ToArray();
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerProductoVendido(int id)
        {
            ProductoVendido productoVen = ProductoVendidoBussines.ObtenerProductoVendido(id);

            return Ok(productoVen);
        }

        [HttpDelete(Name = "EliminarProductoVendido")]
        public void Delete([FromBody] int id)
        {
            ProductoVendidoBussines.EliminarProductoVendido(id);
        }

        /*[HttpPut(Name = "ModificarProductoVendido")]
        public void Put([FromBody] int id, ProductoVendido pv)
        {
            ProductoVendidoBussines.ModificarProductoVendido(id, pv);
        }*/

        [HttpPost(Name = "AltaProductoVendido")]
        public void Post([FromBody] ProductoVendido pv)
        {
            ProductoVendidoBussines.CrearProductoVendido(pv);
        }
    }
}
