namespace CH_Final.API.Controllers.DTOS.Venta
{
    public class PostVenta
    {
        public decimal? Costo { get; set; }
        public string Descripciones { get; set; }
        public int Id { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }

        public bool Validate() => (Descripciones.Length > 0 && Id > 0 && PrecioVenta >= 0 && Stock > 0);
    }
}
