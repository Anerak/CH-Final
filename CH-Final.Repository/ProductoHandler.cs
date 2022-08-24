using CH_Final.Data;
using CH_Final.Instance;
using CH_Final.Models;

namespace CH_Final.Repository
{
    public class ProductoHandler
    {
        public static ProductoContext Productos { get { return ApplicationInstance.Productos; } }

        public static int Create(Producto p) => Productos.Insertar(p);

        public static bool Update(Producto p) => Productos.Modificar(p) > 0;

        public static bool Delete(int id)
        {
            // We need to delete all the ProductosVendidos that are currently using this product.
            ApplicationInstance.ProductosVendidos.EliminarFKProducto(id);
            int result = Productos.Eliminar(id);

            return result > 0;
        }
    }
}
