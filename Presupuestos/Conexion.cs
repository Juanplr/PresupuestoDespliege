using System;
using MySql.Data.MySqlClient;

namespace conexion
{
    public class Conexion
    {
        public Conexion()
        {
        }

        public MySqlConnection crearConexion()
        {
            string connectionString = "server=monorail.proxy.rlwy.net;port=32933;user=root;password=KWuHBUErQDxsXYAGPdZdxxOCqdUNDIuA;database=prueba";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            try
            {
                conexion.Open();
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Conexión exitosa a la base de datos MySQL!");
                }
                else
                {
                    Console.WriteLine("La conexión a la base de datos MySQL no se pudo abrir.");
                }
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos MySQL: " + ex.Message);
                return null;
            }
        }

        public void cerrarConexion(MySqlConnection conexion)
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
                Console.WriteLine("Conexión cerrada correctamente.");
            }
        }
    }
}
