using CH_Final.Data;
using CH_Final.Instance;

namespace CH_Final.API.Repository
{
    public class VentaHandler
    {
        public static VentaContext Ventas { get { return ApplicationInstance.Ventas; } }
    }
}
