using CH_Final.DTO.Venta;
using CH_Final.Repository;
using CH_Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace CH_Final.Startup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet("{id}")]
        public List<GetVenta> GetVentas(int id) => VentaHandler.GetVentas(id);

        [HttpPost("{id}")]
        public int Create(int id, [FromBody] List<PostVenta> ventas) => VentaHandler.Create(id, ventas);

        [HttpDelete("{id}")]
        public bool Delete(int id, [FromBody] DeleteVenta venta) => VentaHandler.Delete(id, venta);
    }
}
