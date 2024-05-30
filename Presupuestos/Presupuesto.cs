using System;
using conexion;
using consultas;
using ipresupuesto;

namespace presupuesto
{
    public class Presupuesto : iPresupuesto
    {
        Conexion conexion = new Conexion();
        Consultas consultas = new Consultas();
        decimal cantidad = 0;
        public string agregarPresupuesto(int id, decimal monto)
        {
            string bandera = "";
            cantidad = consultas.ObtenerCantidad(id, conexion.crearConexion());
            if (monto <= 0)
            {
                bandera = "NO Puedes meter numeros negativos";
            }
            else
            {
                cantidad += monto;
                if (consultas.ActualizarCantidad(id, cantidad, conexion.crearConexion()))
                    bandera = "Se actualizo el presupuesto correctamente";
                else
                    bandera = "No se pudo actualizar El presupuesto";
            }
            return bandera;
        }

        public bool alcanzaElPresupuesto(int id, decimal monto)
        {
            cantidad = consultas.ObtenerCantidad(id, conexion.crearConexion());
            bool bandera = false;
            if (cantidad >= monto)
                bandera = true;
            else
                bandera = false;
            return bandera;
        }

        public decimal mostrarPresupuestoDisponible(int id)
        {
            cantidad = consultas.ObtenerCantidad(id, conexion.crearConexion());
            return cantidad;
        }

        public string sustraerPresupuesto(int id, decimal monto)
        {
            string bandera = "";
            cantidad = consultas.ObtenerCantidad(id, conexion.crearConexion());
            if (monto > cantidad)
            {
                bandera = "No puedes sacar mas de: $" + cantidad;
            }
            else
            {
                cantidad -= monto;
                if (consultas.ActualizarCantidad(id, cantidad, conexion.crearConexion()))
                    bandera = "Se actualizo el Presupuesto";
                else
                    bandera = "Nose pudo Actualizar el presupuesto";
            }
            return bandera;
        }
    }
}