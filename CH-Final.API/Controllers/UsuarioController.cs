using Microsoft.AspNetCore.Mvc;
using CH_Final.API.Repository;
using CH_Final.Models;
using CH_Final.API.Controllers.DTOS.Usuario;

namespace CH_Final.API.Controllers
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

            Usuario u = UsuarioHandler.Create(pU);

            if (u.Id == -1) return new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Conflict, ReasonPhrase = "Usuario ya existe" };

            return u;
        }

        [HttpPut]
        public dynamic Update([FromBody] PutUsuario pU)
        {
            if (!pU.Validate()) return InformacionInvalida;

            return UsuarioHandler.Update(pU);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id) => UsuarioHandler.Delete(id);
    }
}
