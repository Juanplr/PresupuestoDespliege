using System;
using System.ServiceModel;

namespace ipresupuesto
{
    [ServiceContract]
    public interface iPresupuesto
    {
        [OperationContract]
        public decimal mostrarPresupuestoDisponible(int id);
        [OperationContract]
        public string agregarPresupuesto(int id, decimal monto);
        [OperationContract]
        public string sustraerPresupuesto(int id, decimal monto);
        [OperationContract]
        public bool alcanzaElPresupuesto(int id, decimal monto);

    }
}