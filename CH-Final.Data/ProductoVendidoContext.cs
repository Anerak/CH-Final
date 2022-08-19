using CH_Final.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH_Final.Data
{
    public class ProductoVendidoContext : DbContext
    {
        public ProductoVendidoContext(string connectionString) : base(connectionString) { }

        #region Obtener producto vendido
        public ProductoVendido GetProductoVendido(int id)
        {
            ProductoVendido resultProductoVendido = new ProductoVendido();
            try
            {

                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM ProductoVendido WHERE Id = @id;";
                    cmd.Parameters.Add("id", System.Data.SqlDbType.BigInt).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                resultProductoVendido.Id = Convert.ToInt32(reader["Id"]);
                                resultProductoVendido.Stock = Convert.ToInt32(reader["Stock"]);
                                resultProductoVendido.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                                resultProductoVendido.IdVenta = Convert.ToInt32(reader["IdVenta"]);

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
            return resultProductoVendido;
        }

        #endregion

        #region Obtener productos vendidos
        public List<ProductoVendido> GetProductosVendidos()
        {
            List<ProductoVendido> productoVendidos = new List<ProductoVendido>();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM ProductoVendido;";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProductoVendido resultProdVendido = new ProductoVendido();
                                resultProdVendido.Id = Convert.ToInt32(reader["Id"]);
                                resultProdVendido.Stock = Convert.ToInt32(reader["Stock"]);
                                resultProdVendido.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                                resultProdVendido.IdVenta = Convert.ToInt32(reader["IdVenta"]);

                                productoVendidos.Add(resultProdVendido);
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
            return productoVendidos;
        }
        #endregion

        #region Insertar producto vendido
        public int Insertar(ProductoVendido productoVendido)
        {
            int result = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO ProductoVendido (Stock, IdProducto, IdVenta) VALUES(@stock, @idproducto, @idventa); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    cmd.Parameters.Add("stock", SqlDbType.Int).Value = productoVendido.Stock;
                    cmd.Parameters.Add("idproducto", SqlDbType.BigInt).Value = productoVendido.IdProducto;
                    cmd.Parameters.Add("idventa", SqlDbType.BigInt).Value = productoVendido.IdVenta;

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

        #region Eliminar producto vendido
        public int Eliminar(int id)
        {
            int result = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM ProductoVendido WHERE Id = @id;";
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
        
        public int EliminarFKProducto(int idProducto)
        {
            int result = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM ProductoVendido WHERE IdProducto = @id;";
                    cmd.Parameters.Add("id", SqlDbType.BigInt).Value = idProducto;

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

        public int EliminarFKVenta(int idVenta)
        {
            int result = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM ProductoVendido WHERE IdVenta = @id;";
                    cmd.Parameters.Add("id", SqlDbType.BigInt).Value = idVenta;

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

        #region Modificar venta
        public int Modificar(ProductoVendido productoVendido)
        {
            int result = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "UPDATE ProductoVendido SET Stock = @stock, IdProducto = @idproducto, IdVenta = @idventa WHERE Id = @id;";
                    cmd.Parameters.Add("id", SqlDbType.BigInt).Value = productoVendido.Id;
                    cmd.Parameters.Add("stock", SqlDbType.Int).Value = productoVendido.Stock;
                    cmd.Parameters.Add("idproducto", SqlDbType.BigInt).Value = productoVendido.IdProducto;
                    cmd.Parameters.Add("idventa", SqlDbType.BigInt).Value = productoVendido.IdVenta;
                    

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

        #region Obtener stock vendido

        public int GetStockVendido(int idProducto)
        {
            int result = 0;
            try
            {

                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = $"SELECT SUM(Stock) FROM ProductoVendido WHERE IdProducto = @id;";
                    cmd.Parameters.Add("id", System.Data.SqlDbType.BigInt).Value = idProducto;

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
    }
}
