using CH_Final.Models;
using System.Data;
using System.Data.SqlClient;

namespace CH_Final.Data
{
    public class ProductoContext : DbContext
    {
        public ProductoContext(string connectionString) : base(connectionString) { }

        #region Obtener producto
        public Producto GetProducto(int id)
        {
            Producto resultProducto = new Producto();
            try
            {

                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM Producto WHERE Id = @id;";
                    cmd.Parameters.Add("id", System.Data.SqlDbType.BigInt).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                resultProducto.Id = Convert.ToInt32(reader["Id"]);
                                resultProducto.Descripciones = reader["Descripciones"].ToString();
                                resultProducto.Costo = Convert.ToDecimal(reader["Costo"]);
                                resultProducto.PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]);
                                resultProducto.Stock = Convert.ToInt32(reader["Contraseña"]);
                                resultProducto.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
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
            return resultProducto;
        }

        #endregion

        #region Obtener Productos
        public List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Producto;";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Producto resultProducto = new Producto();
                                resultProducto.Id = Convert.ToInt32(reader["Id"]);
                                resultProducto.Descripciones = reader["Descripciones"].ToString();
                                resultProducto.Costo = Convert.ToDecimal(reader["Costo"]);
                                resultProducto.PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]);
                                resultProducto.Stock = Convert.ToInt32(reader["Contraseña"]);
                                resultProducto.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                                productos.Add(resultProducto);
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
            return productos;
        }
        public List<Producto> GetProductos(int idUser)
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Producto WHERE IdUsuario = @idusuario;";
                    cmd.Parameters.Add("idusuario", SqlDbType.BigInt).Value = idUser;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Producto resultProducto = new Producto();
                                resultProducto.Id = Convert.ToInt32(reader["Id"]);
                                resultProducto.Descripciones = reader["Descripciones"].ToString();
                                resultProducto.Costo = Convert.ToDecimal(reader["Costo"]);
                                resultProducto.PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]);
                                resultProducto.Stock = Convert.ToInt32(reader["Stock"]);
                                resultProducto.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                                productos.Add(resultProducto);
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
            return productos;
        }
        #endregion

        #region Insertar Producto

        public int Insertar(Producto producto)
        {
            int result = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES(@descripciones, @costo, @precioventa, @stock, @idusuario); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    cmd.Parameters.Add("descripciones", SqlDbType.VarChar).Value = producto.Descripciones;
                    cmd.Parameters.Add("costo", SqlDbType.Money).Value = producto.Costo;
                    cmd.Parameters.Add("precioventa", SqlDbType.Money).Value = producto.PrecioVenta;
                    cmd.Parameters.Add("stock", SqlDbType.Int).Value = producto.Stock;
                    cmd.Parameters.Add("idusuario", SqlDbType.BigInt).Value = producto.IdUsuario;

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

        #region Eliminar producto
        public int Eliminar(Producto producto)
        {
            int result = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM Producto WHERE Id = @id;";
                    cmd.Parameters.Add("id", SqlDbType.BigInt).Value = producto.Id;

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
        
        public int Eliminar(int id)
        {
            int result = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM Producto WHERE Id = @id;";
                    cmd.Parameters.Add("id", SqlDbType.BigInt).Value = id;

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

        #region Modificar producto
        public int Modificar(Producto producto)
        {
            int result = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "UPDATE Producto SET Descripciones = @descripciones, Costo = @costo, PrecioVenta = @precioventa, Stock = @stock, IdUsuario = @idusuario WHERE Id = @id;";
                    cmd.Parameters.Add("id", SqlDbType.BigInt).Value = producto.Id;
                    cmd.Parameters.Add("descripciones", SqlDbType.VarChar).Value = producto.Descripciones;
                    cmd.Parameters.Add("costo", SqlDbType.Money).Value = producto.Costo;
                    cmd.Parameters.Add("precioventa", SqlDbType.Money).Value = producto.PrecioVenta;
                    cmd.Parameters.Add("stock", SqlDbType.Int).Value = producto.Stock;
                    cmd.Parameters.Add("idusuario", SqlDbType.BigInt).Value = producto.IdUsuario;

                    result = cmd.ExecuteNonQuery();

                    connection.Close();
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public int Modificar(List<Producto> productos)
        {
            int result = 0;

            foreach (Producto producto in productos)
            {
                result += this.Modificar(producto);
            }

            return result;
        }
        #endregion
    }
}