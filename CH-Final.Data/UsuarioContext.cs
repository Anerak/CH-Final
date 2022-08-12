using CH_Final.Models;
using System.Data;
using System.Data.SqlClient;

namespace CH_Final.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(string connectionString) : base(connectionString) { }

        #region Obtener usuario
        public Usuario GetUsuario(int id)
        {
            Usuario resultUsuario = new Usuario();
            try
            {

                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM Usuario WHERE Id = @id;";
                    cmd.Parameters.Add("id", SqlDbType.BigInt).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                resultUsuario.Id = Convert.ToInt32(reader["Id"]);
                                resultUsuario.Nombre = reader["Nombre"].ToString();
                                resultUsuario.Apellido = reader["Apellido"].ToString();
                                resultUsuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                resultUsuario.Contraseña = reader["Contraseña"].ToString();
                                resultUsuario.Mail = reader["Mail"].ToString();
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return resultUsuario;
        }

        public Usuario GetUsuario(string username, string password)
        {
            Usuario resultUsuario = new Usuario();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @user AND Contraseña = @pass;";
                    cmd.Parameters.Add("user", System.Data.SqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("pass", System.Data.SqlDbType.VarChar).Value = password;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                resultUsuario.Id = Convert.ToInt32(reader["Id"]);
                                resultUsuario.Nombre = reader["Nombre"].ToString();
                                resultUsuario.Apellido = reader["Apellido"].ToString();
                                resultUsuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                resultUsuario.Contraseña = reader["Contraseña"].ToString();
                                resultUsuario.Mail = reader["Mail"].ToString();
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return resultUsuario;
        }

        #endregion

        #region Obtener usuarios
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Usuario;";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Usuario resultUsuario = new Usuario();
                                resultUsuario.Id = Convert.ToInt32(reader["Id"]);
                                resultUsuario.Nombre = reader["Nombre"].ToString();
                                resultUsuario.Apellido = reader["Apellido"].ToString();
                                resultUsuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                resultUsuario.Contraseña = reader["Contraseña"].ToString();
                                resultUsuario.Mail = reader["Mail"].ToString();
                                usuarios.Add(resultUsuario);
                            }
                        }
                    }

                    connection.Close();
                }
                usuarios.ForEach(u => Console.WriteLine(u.Nombre));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return usuarios;
        }
        #endregion

        #region Insertar usuario
        public int Insertar(Usuario usuario)
        {
            int result = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES(@nombre, @apellido, @nombreusuario, @contraseña, @mail); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    cmd.Parameters.Add("nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                    cmd.Parameters.Add("apellido", SqlDbType.VarChar).Value = usuario.Apellido;
                    cmd.Parameters.Add("nombreusuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
                    cmd.Parameters.Add("contraseña", SqlDbType.VarChar).Value = usuario.Contraseña;
                    cmd.Parameters.Add("mail", SqlDbType.VarChar).Value = usuario.Mail;

                    result = Convert.ToInt32(cmd.ExecuteScalar());

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        #endregion

        #region Eliminar usuario
        public int Eliminar(Usuario usuario)
        {
            int result = -1;

            try {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM Usuario WHERE Id = @id;";
                    cmd.Parameters.Add("id", SqlDbType.BigInt).Value = usuario.Id;

                    result = cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
        #endregion

        #region Modificar usuario
        public int Modificar(Usuario usuario)
        {
            int result = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "UPDATE Usuario SET Nombre = @nombre, Apellido = @apellido, NombreUsuario = @nombreusuario, Contraseña = @contraseña, Mail = @mail WHERE Id = @id;";
                    cmd.Parameters.Add("id", SqlDbType.BigInt).Value = usuario.Id;
                    cmd.Parameters.Add("nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                    cmd.Parameters.Add("apellido", SqlDbType.VarChar).Value = usuario.Apellido;
                    cmd.Parameters.Add("nombreusuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
                    cmd.Parameters.Add("contraseña", SqlDbType.VarChar).Value = usuario.Contraseña;
                    cmd.Parameters.Add("mail", SqlDbType.VarChar).Value = usuario.Mail;

                    result = cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
        #endregion
    }
}