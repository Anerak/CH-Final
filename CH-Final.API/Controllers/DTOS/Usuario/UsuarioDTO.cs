namespace CH_Final.API.Controllers.DTOS.Usuario
{
    public abstract class UsuarioDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Mail { get; set; }
        public string Contraseña { get; set; }

        public virtual bool Validate() => (Nombre.Equals(String.Empty) || Apellido.Equals(String.Empty) || NombreUsuario.Equals(String.Empty) || Mail.Equals(String.Empty) || Contraseña.Equals(String.Empty)).Equals(false);
    }
}
