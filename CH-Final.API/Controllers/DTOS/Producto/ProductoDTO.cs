namespace CH_Final.API.Controllers.DTOS.Producto
{
    public abstract class ProductoDTO
    {
        public string Descripciones { get; set; }
        public decimal? Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
        public virtual bool Validate() => (Descripciones.Length > 0 && PrecioVenta > 0 && Stock >= 0 && IdUsuario > 0);
    }
}
