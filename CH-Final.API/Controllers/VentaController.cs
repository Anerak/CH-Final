using CH_Final.API.Controllers.DTOS.Venta;
using CH_Final.API.Repository;
using CH_Final.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CH_Final.API.Controllers
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
