using System;
using System.Collections.Generic; // Cambiado de ArrayList a List
using conexion;
using consultas;
using departamento;
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
                bandera = "NO Puedes meter números negativos";
            }
            else
            {
                cantidad += monto;
                if (consultas.ActualizarCantidad(id, cantidad, conexion.crearConexion()))
                    bandera = "Se actualizó el presupuesto correctamente";
                else
                    bandera = "No se pudo actualizar el presupuesto";
            }
            return bandera;
        }

        public bool alcanzaElPresupuesto(int id, decimal monto)
        {
            cantidad = consultas.ObtenerCantidad(id, conexion.crearConexion());
            return cantidad >= monto;
        }

        public decimal mostrarPresupuestoDisponible(int id)
        {
            return consultas.ObtenerCantidad(id, conexion.crearConexion());
        }

        public string sustraerPresupuesto(int id, decimal monto)
        {
            string bandera = "";
            cantidad = consultas.ObtenerCantidad(id, conexion.crearConexion());
            if (monto > cantidad)
            {
                bandera = $"No puedes sacar más de: ${cantidad}";
            }
            else
            {
                cantidad -= monto;
                if (consultas.ActualizarCantidad(id, cantidad, conexion.crearConexion()))
                    bandera = "Se actualizó el presupuesto";
                else
                    bandera = "No se pudo actualizar el presupuesto";
            }
            return bandera;
        }

        public List<Departamento> mostrarDepartamentos() // Cambiado a List<Departamento>
        {
            return consultas.ObtenerDepartamentos(conexion.crearConexion());
        }
    }
}
