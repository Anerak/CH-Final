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
        [HttpGet]
        List<Venta> GetVentas() => VentaHandler.Ventas.GetVentas();

        [HttpGet("{id}")]
        List<Venta> GetVentas(int id) => VentaHandler.Ventas.GetVentas(id);

        [HttpPost("{id}")]
        public int Create(int id, [FromBody] List<PostVenta> ventas) => VentaHandler.Create(id, ventas);
    }
}
