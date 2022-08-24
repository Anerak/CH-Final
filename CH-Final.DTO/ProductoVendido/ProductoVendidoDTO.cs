namespace CH_Final.DTO.ProductoVendido
{
    public class ProductoVendidoDTO
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }
        public Models.Producto Producto { get; set; }
    }
}
