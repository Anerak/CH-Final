namespace CH_Final.DTO.Usuario
{
    public class PutUsuario : UsuarioDTO
    {
        public int Id { get; set; }

        public override bool Validate() => (base.Validate() && Id.Equals(0)).Equals(false);
    }
}
