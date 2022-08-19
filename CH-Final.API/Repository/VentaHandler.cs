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

            venta.Id = Ventas.Insertar(venta);
            if (venta.Id <= 0) return -1;

            List<Producto> productosModificados = new List<Producto>();

            foreach(PostVenta post in ventas)
            {
                ProductoVendido pv = new ProductoVendido();
                pv.IdVenta = venta.Id;
                pv.IdProducto = post.Id;
                pv.Stock = post.Stock;

                ApplicationInstance.ProductosVendidos.Insertar(pv);

                Producto producto = productos.Where(p => p.Id.Equals(post.Id)).FirstOrDefault();
                producto.Stock = post.Stock > producto.Stock ? 0 : producto.Stock - post.Stock;

                ApplicationInstance.Productos.Modificar(producto);
            }

            return venta.Id;
        }

        public static List<GetVenta> GetVentas(int id)
        {
            List<GetVenta> resultVentas = new List<GetVenta>();

            List<Producto> productos = ApplicationInstance.Productos.GetProductos(id);
            List<ProductoVendido> productosVendidos = ApplicationInstance.ProductosVendidos.GetProductosVendidos().Where(pv => productos.Any(p => p.Id == pv.IdProducto)).ToList();
            List<Venta> ventas = Ventas.GetVentas().Where(v => productosVendidos.Any(pv => pv.IdVenta == v.Id)).ToList();

            foreach(Venta venta in ventas)
            {
                GetVenta gVenta = new GetVenta();

                gVenta.Id = venta.Id;
                gVenta.Comentarios = venta.Comentarios;

                gVenta.ProductoVendido = new List<ProductoVendido>();
                gVenta.ProductoVendido.AddRange(productosVendidos.Where(pv => pv.IdVenta == gVenta.Id));

                gVenta.Productos = new List<Producto>();
                gVenta.Productos.AddRange(productos.Where(p => gVenta.ProductoVendido.Any(pv => pv.IdProducto == p.Id)));

                resultVentas.Add(gVenta);
            }

            return resultVentas;
        }

        public static bool Delete(int id, DeleteVenta venta) {
            if (venta.Id <= 0) return false;

            List<ProductoVendido> productoVendidos = ApplicationInstance.ProductosVendidos.GetProductosVendidos().Where(pv => pv.IdVenta == venta.Id).ToList();
            List<Producto> productos = ApplicationInstance.Productos.GetProductos(id).Where(p => productoVendidos.Any(pv => pv.IdProducto == p.Id)).ToList();
            Venta v = Ventas.GetVenta(venta.Id);

            if (v.Id <= 0) return false;

            foreach(Producto producto in productos)
            {
                    int foo =productoVendidos.Aggregate(0, (val, pv) => pv.IdProducto == producto.Id ? val + pv.Stock : 0);
                producto.Stock += foo;
            }

            ApplicationInstance.Productos.Modificar(productos);
            ApplicationInstance.ProductosVendidos.EliminarFKVenta(v.Id);

            return Ventas.Eliminar(v) > 0;
        }
    }
}
