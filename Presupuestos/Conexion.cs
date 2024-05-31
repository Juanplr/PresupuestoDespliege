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
            string connectionString = "server=bahh1qqfgt63a6odemxa-mysql.services.clever-cloud.com;user=uprscmbmpp14utjr;password=e82X2glxPCOQxn2o87W6;database=bahh1qqfgt63a6odemxa";
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
            conexion.Close();
        }
    }
}