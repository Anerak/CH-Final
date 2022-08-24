using CH_Final.DTO.ProductoVendido;
using CH_Final.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CH_Final.Startup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("{id}")]
        public List<ProductoVendidoDTO> GetProductoVendidos(int id) => ProductoVendidoHandler.GetProductos(id);
    }
}
