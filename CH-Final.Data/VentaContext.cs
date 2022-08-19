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
    public class VentaContext : DbContext
    {
        public VentaContext(string connectionString) : base(connectionString) { }

        #region Obtener venta
        public Venta GetVenta(int id)
        {
            Venta resultVenta = new Venta();
            try
            {

                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM Venta WHERE Id = @id;";
                    cmd.Parameters.Add("id", System.Data.SqlDbType.BigInt).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                resultVenta.Id = Convert.ToInt32(reader["Id"]);
                                resultVenta.Comentarios = reader["Comentarios"].ToString();
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
            return resultVenta;
        }

        #endregion

        #region Obtener ventas
        public List<Venta> GetVentas()
        {
            List<Venta> ventas = new List<Venta>();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Venta;";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Venta resultVenta = new Venta();
                                resultVenta.Id = Convert.ToInt32(reader["Id"]);
                                resultVenta.Comentarios = reader["Comentarios"].ToString();
                                ventas.Add(resultVenta);
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
            return ventas;
        }

        public List<Venta> GetVentas(int iduser)
        {
            List<Venta> ventas = new List<Venta>();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Venta WHERE ;";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Venta resultVenta = new Venta()
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Comentarios = reader["Comentarios"].ToString()
                                };

                                ventas.Add(resultVenta);
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
            return ventas;
        }
        #endregion

        #region Insertar venta

        public int Insertar(Venta venta)
        {
            int result = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO Venta (Comentarios) VALUES(@comentarios); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    cmd.Parameters.Add("comentarios", SqlDbType.VarChar).Value = venta.Comentarios;

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

        #region Eliminar venta
        public int Eliminar(Venta venta)
        {
            int result = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM Venta WHERE Id = @id;";
                    cmd.Parameters.Add("id", SqlDbType.BigInt).Value = venta.Id;

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
        public int Modificar(Venta venta)
        {
            int result = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "UPDATE Venta SET Comentarios = @comentarios WHERE Id = @id;";
                    cmd.Parameters.Add("id", SqlDbType.BigInt).Value = venta.Id;
                    cmd.Parameters.Add("comentarios", SqlDbType.VarChar).Value = venta.Comentarios;

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
