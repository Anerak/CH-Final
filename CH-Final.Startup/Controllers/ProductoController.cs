using CH_Final.DTO.Producto;
using CH_Final.Repository;
using CH_Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace CH_Final.Startup.Controllers
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

            Producto p = new Producto { Costo = pp.Costo, Descripciones = pp.Descripciones, PrecioVenta = pp.PrecioVenta, Stock = pp.Stock, IdUsuario = pp.IdUsuario };

            return ProductoHandler.Create(p);
        }

        [HttpPut]
        public bool Update([FromBody] PutProducto pp)
        {
            if (!pp.Validate()) return false;

            Producto p = new Producto { Id = pp.Id, Costo = pp.Costo, Descripciones = pp.Descripciones, PrecioVenta = pp.PrecioVenta, Stock = pp.Stock, IdUsuario = pp.IdUsuario };

            return ProductoHandler.Update(p);
        }
    }
}
