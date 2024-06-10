using System;
using System.Collections.Generic;
using System.ServiceModel;
using departamento;

namespace ipresupuesto
{
    [ServiceContract]
    public interface iPresupuesto
    {
        [OperationContract]
        decimal mostrarPresupuestoDisponible(int id);

        [OperationContract]
        string agregarPresupuesto(int id, decimal monto);

        [OperationContract]
        string sustraerPresupuesto(int id, decimal monto);

        [OperationContract]
        bool alcanzaElPresupuesto(int id, decimal monto);

        [OperationContract]
        List<Departamento> mostrarDepartamentos(); // Cambiado a List<Departamento>
    }
}
