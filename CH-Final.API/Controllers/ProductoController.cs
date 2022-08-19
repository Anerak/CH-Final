using CH_Final.API.Controllers.DTOS.Producto;
using CH_Final.API.Repository;
using CH_Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace CH_Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        HttpResponseMessage InformacionInvalida = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Conflict, ReasonPhrase = "Información inválida" };

        [HttpGet("{id}")]
        public List<Producto> GetProductos(int id) => ProductoHandler.Productos.GetProductos(id);

        [HttpDelete("{id}")]
        public bool Delete(int id) => ProductoHandler.Delete(id);

        [HttpPost]
        public dynamic Create([FromBody] PostProducto pp)
        {
            if (!pp.Validate()) return InformacionInvalida;

            return ProductoHandler.Create(pp);
        }

        [HttpPut]
        public bool Update([FromBody] PutProducto pp)
        {
            if (!pp.Validate()) return false;

            return ProductoHandler.Update(pp);
        }
    }
}
