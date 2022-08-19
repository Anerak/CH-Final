using CH_Final.API.Controllers.DTOS.Producto;
using CH_Final.Data;
using CH_Final.Instance;
using CH_Final.Models;

namespace CH_Final.API.Repository
{
    public class ProductoHandler
    {
        public static ProductoContext Productos { get { return ApplicationInstance.Productos; } }

        public static int Create(PostProducto pp)
        {
            Producto p = new Producto { Costo = pp.Costo, Descripciones = pp.Descripciones, PrecioVenta = pp.PrecioVenta, Stock = pp.Stock, IdUsuario = pp.IdUsuario };

            return Productos.Insertar(p);
        }

        public static bool Update(PutProducto pp)
        {
            Producto p = new Producto { Id = pp.Id, Costo = pp.Costo, Descripciones = pp.Descripciones, PrecioVenta = pp.PrecioVenta, Stock = pp.Stock, IdUsuario = pp.IdUsuario};

            return Productos.Modificar(p) > 0;
        }

        public static bool Delete(int id)
        {
            // We need to delete all the ProductosVendidos that are currently using this product.
            ApplicationInstance.ProductosVendidos.EliminarFKProducto(id);
            int result = Productos.Eliminar(id);

            return result > 0;
        }
    }
}
