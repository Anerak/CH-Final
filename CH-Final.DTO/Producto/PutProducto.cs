using CH_Final.Models;

namespace CH_Final.DTO.Producto
{
    public class PutProducto : ProductoDTO
    {
        public int Id { get; set; }

        public override bool Validate() => (base.Validate() && Id > 0);
    }
}
