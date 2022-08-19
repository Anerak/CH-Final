using CH_Final.API.Controllers.DTOS.Producto;
using CH_Final.API.Controllers.DTOS.Venta;
using CH_Final.Data;
using CH_Final.Instance;
using CH_Final.Models;

namespace CH_Final.API.Repository
{
    public class VentaHandler
    {
        public static VentaContext Ventas { get { return ApplicationInstance.Ventas; } }

        public static int Create(int idUsuario, List<PostVenta> ventas)
        {
            List<Producto> productos = ApplicationInstance.Productos.GetProductos(idUsuario).Where(p => ventas.Any(pv => pv.Id.Equals(p.Id))).ToList();
            if (productos.Count <= 0) return -1;

            Venta venta = new Venta();
            venta.Comentarios = $"Venta realizada por {idUsuario}";

            int idVenta = Ventas.Insertar(venta);
            if (idVenta <= 0) return -1;

            List<Producto> productosModificados = new List<Producto>();

            foreach(PostVenta post in ventas)
            {
                ProductoVendido pv = new ProductoVendido();
                pv.IdVenta = idVenta;
                pv.IdProducto = post.Id;
                pv.Stock = post.Stock;

                ApplicationInstance.ProductosVendidos.Insertar(pv);

                Producto producto = productos.Where(p => p.Id.Equals(post.Id)).FirstOrDefault();
                producto.Stock = post.Stock > producto.Stock ? 0 : producto.Stock - post.Stock;

                ApplicationInstance.Productos.Modificar(producto);
            }

            return venta.Id;
        }
    }
}
