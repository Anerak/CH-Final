using CH_Final.Data;
using CH_Final.Instance;

namespace CH_Final.API.Repository
{
    public class ProductoVendidoHandler
    {
        public static ProductoVendidoContext ProductosVendidos { get { return ApplicationInstance.ProductosVendidos; } }
    }
}
