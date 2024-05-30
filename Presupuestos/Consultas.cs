using System;
using MySql.Data.MySqlClient;
namespace consultas
{
    public class Consultas
    {
        public Consultas(){
            
        }
        public decimal ObtenerCantidad(int id, MySqlConnection conexion)
        {
            decimal cantidad =0;
            string query = "SELECT cantidad FROM presupuesto WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        cantidad = rdr.GetDecimal("cantidad");
                        Console.WriteLine($"Cantidad del ID {id}: {cantidad}");
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró ningún registro con el ID {id}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la cantidad: " + ex.Message);
            }
            return cantidad;
        }

        public bool ActualizarCantidad(int id, decimal nuevaCantidad, MySqlConnection conexion)
        {
            bool bandera = false;
            string query = "UPDATE presupuesto SET cantidad = @nuevaCantidad WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nuevaCantidad", nuevaCantidad);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    bandera = true;
                }
                else
                {
                    bandera = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la cantidad: " + ex.Message);
            }
            return bandera;
        }
    }
}
