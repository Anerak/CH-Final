using CH_Final.Instance;
using CH_Final.Data;
using CH_Final.Models;
using CH_Final.API.Controllers.DTOS.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace CH_Final.API.Repository
{
    public static class UsuarioHandler
    {
        public static UsuarioContext Usuarios { get { return ApplicationInstance.Usuarios; } }

        public static Usuario GetUsuario(string username, string password) => Usuarios.GetUsuario(username, password);
        public static Usuario GetUsuario(string username) => Usuarios.GetUsuario(username);

        public static Usuario Create(PostUsuario pU)
        {
            Usuario u = new Usuario()
            {
                Nombre = pU.Nombre,
                Apellido = pU.Apellido,
                Mail = pU.Mail,
                NombreUsuario = pU.NombreUsuario,
                Contraseña = pU.Contraseña
            };
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

        public static bool Update(PutUsuario pU)
        {
            Usuario u = new Usuario()
            {
                Id = pU.Id,
                Nombre = pU.Nombre,
                Apellido = pU.Apellido,
                Mail = pU.Mail,
                NombreUsuario = pU.NombreUsuario,
                Contraseña = pU.Contraseña
            };

            int result = Usuarios.Modificar(u);

            return result > 0;
        }

        public static bool Delete(int id) => Usuarios.Eliminar(id) > 0;

    }
}
