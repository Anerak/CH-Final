using CH_Final.Data;
using CH_Final.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH_Final.Instance
{
    public static class ApplicationInstance
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["SistemaGestion"].ConnectionString;
            }
        }

        public static ProductoContext Productos = new ProductoContext(ApplicationInstance.ConnectionString);
        public static ProductoVendidoContext ProductosVendidos = new ProductoVendidoContext(ApplicationInstance.ConnectionString);
        public static UsuarioContext Usuarios = new UsuarioContext(ApplicationInstance.ConnectionString);
        public static VentaContext Ventas = new VentaContext(ApplicationInstance.ConnectionString);
    }
}
