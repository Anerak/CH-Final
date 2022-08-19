using CH_Final.API.Controllers.DTOS.ProductoVendido;
using CH_Final.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CH_Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("{id}")]
        public List<ProductoVendidoDTO> GetProductoVendidos(int id) => ProductoVendidoHandler.GetProductos(id);
    }
}
