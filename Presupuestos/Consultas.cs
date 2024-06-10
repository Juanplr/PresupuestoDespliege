using System;
using System.Collections;
using System.Runtime.Serialization;
using MySql.Data.MySqlClient;
using departamento;
using System.Data;

namespace consultas
{
    [KnownType(typeof(Departamento))]
    public class Consultas
    {
        public Consultas() { }

        public decimal ObtenerCantidad(int id, MySqlConnection conexion)
        {
            decimal cantidad = 0;
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

        public List<Departamento> ObtenerDepartamentos(MySqlConnection conexion)
        {
            List<Departamento> departamentos = new List<Departamento>();
            string query = "SELECT * FROM presupuesto";
            MySqlCommand cmd = new MySqlCommand(query, conexion);

            try
            {
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Departamento departamento = new Departamento
                        {
                            ID = rdr.GetInt16("id"),
                            Monto = rdr.GetDecimal("cantidad"),
                            Nombre = rdr.GetString("nombre")
                        };
                        departamentos.Add(departamento);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la cantidad: " + ex.Message);
            }
            return departamentos;
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
                bandera = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la cantidad: " + ex.Message);
            }
            return bandera;
        }
    }
}