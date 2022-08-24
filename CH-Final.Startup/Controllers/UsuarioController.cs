using Microsoft.AspNetCore.Mvc;
using CH_Final.Repository;
using CH_Final.Models;
using CH_Final.DTO.Usuario;

namespace CH_Final.Startup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        HttpResponseMessage InformacionInvalida = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Conflict, ReasonPhrase = "Información inválida" };


        [HttpGet("{username}/{password}")]
        public dynamic Login(string username, string password) { 
            Usuario u = UsuarioHandler.GetUsuario(username, password);
            
            if (u.Id.Equals(0)) return InformacionInvalida;

            return u;
        }

        [HttpGet("{username}")]
        public dynamic GetUsuario(string username) {
            Usuario u = UsuarioHandler.GetUsuario(username);
            
            if (u.Id.Equals(0)) return InformacionInvalida;

            return u;
        }

        [HttpPost]
        public dynamic Create([FromBody] PostUsuario pU)
        {
            if (!pU.Validate()) return InformacionInvalida;

            Usuario u = new Usuario() { Nombre = pU.Nombre, Apellido = pU.Apellido, Mail = pU.Mail, NombreUsuario = pU.NombreUsuario, Contraseña = pU.Contraseña };

            u.Id = UsuarioHandler.Create(u).Id;

            if (u.Id == -1) return new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Conflict, ReasonPhrase = "Usuario ya existe" };

            return u;
        }

        [HttpPut]
        public dynamic Update([FromBody] PutUsuario pU)
        {
            if (!pU.Validate()) return InformacionInvalida;

            Usuario u = new Usuario() { Id = pU.Id, Nombre = pU.Nombre, Apellido = pU.Apellido, Mail = pU.Mail, NombreUsuario = pU.NombreUsuario, Contraseña = pU.Contraseña };

            return UsuarioHandler.Update(u);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id) => UsuarioHandler.Delete(id);
    }
}
