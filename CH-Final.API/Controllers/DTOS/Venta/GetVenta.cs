using CH_Final.Models;
namespace CH_Final.API.Controllers.DTOS.Venta
{
    public class GetVenta
    {
        public int Id { get; set; }
        public string? Comentarios { get; set; }
        public List<Models.Producto> Productos { get; set; }
        public List<Models.ProductoVendido> ProductoVendido { get; set; }
    }
}
