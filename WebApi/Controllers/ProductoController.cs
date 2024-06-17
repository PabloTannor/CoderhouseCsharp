using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProducto")]
        public IEnumerable<Producto> Productos()
        {
            return ProductoBussines.GetProductos().ToArray();
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerProducto(int id)
        {
            Producto producto = ProductoBussines.ObtenerProducto(id);

            return Ok(producto);
        }

        [HttpDelete(Name = "EliminarProducto")]
        public void Delete([FromBody] int id)
        {
            ProductoBussines.EliminarProducto(id);
        }

        /*[HttpPut(Name = "ModificarProducto")]
        public void Put([FromBody] int id,Producto p)
        {
            ProductoBussines.ModificarProducto(id, p);
        }*/

        [HttpPost(Name = "AltaProducto")]
        public void Post([FromBody]Producto p)
        {
            ProductoBussines.CrearProducto(p);
        }
    }
}
