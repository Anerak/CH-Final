using CH_Final.Instance;
using CH_Final.Data;
using CH_Final.Models;
using CH_Final.DTO.ProductoVendido;

namespace CH_Final.Repository
{
    public class ProductoVendidoHandler
    {
        public static ProductoVendidoContext ProductosVendidos { get { return ApplicationInstance.ProductosVendidos; } }

        public static List<ProductoVendidoDTO> GetProductos(int id)
        {
            List<ProductoVendidoDTO> result = new List<ProductoVendidoDTO>();

            List<Producto> products = ApplicationInstance.Productos.GetProductos(id);
            List<ProductoVendido> productoVendidos = ProductosVendidos.GetProductosVendidos().Where(pv => products.Any(p => p.Id == pv.IdProducto)).ToList();

            foreach(ProductoVendido pv in productoVendidos)
            {
                ProductoVendidoDTO pDTO = new ProductoVendidoDTO
                {
                    IdProducto = pv.IdProducto,
                    IdVenta = pv.IdVenta,
                    Id = pv.Id,
                    Stock = pv.Stock,
                    Producto = products.Where(p => p.Id == pv.IdProducto).FirstOrDefault()
                };
                result.Add(pDTO);
            }

            return result;
        }
    }
}
