using CH_Final.Instance;
using CH_Final.Data;
using CH_Final.Models;

namespace CH_Final.Repository
{
    public static class UsuarioHandler
    {
        public static UsuarioContext Usuarios { get { return ApplicationInstance.Usuarios; } }

        public static Usuario GetUsuario(string username, string password) => Usuarios.GetUsuario(username, password);
        public static Usuario GetUsuario(string username) => Usuarios.GetUsuario(username);

        public static Usuario Create(Usuario u)
        {
            
            bool exists = Usuarios.GetUsuario(u.NombreUsuario).Id > 0;
            if (exists)
            {
                u.Id = -1;
            }
            else
            {
                int id = Usuarios.Insertar(u);
                u.Id = id;
            }

            return u;
        }

        public static bool Update(Usuario u) => Usuarios.Modificar(u) > 0;

        public static bool Delete(int id) => Usuarios.Eliminar(id) > 0;

    }
}
