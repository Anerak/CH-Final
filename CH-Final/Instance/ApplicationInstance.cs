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

    public class Sesion
    {
        private Usuario _usuario = new Usuario();

        public bool Online { get { return this._usuario != null && this._usuario.Id > 0; } }


        public bool Conectar()
        {
            while (!this.Online)
            {
                Console.Write("Usuario: ");
                string user = Console.ReadLine() ?? String.Empty;
                Console.Write("Contraseña: ");
                string pass = Console.ReadLine() ?? String.Empty;

                this._usuario = ApplicationInstance.Usuarios.GetUsuario(user, pass);
            }
            return true;
        }

        #region Getters del usuario actual
        public int Id { get { return _usuario.Id; } }
        public string Nombre { get { return _usuario.Nombre; } }
        public string Apellido { get { return _usuario.Apellido; } }
        public string NombreUsuario { get { return _usuario.NombreUsuario; } }
        public string Mail { get { return _usuario.Mail; } }
        #endregion
    }

}
