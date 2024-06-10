using System;
using System.Runtime.Serialization;

namespace departamento
{
    [DataContract]
    public class Departamento
    {
        private int id;
        private decimal monto;
        private string nombre;

        public Departamento() { }

        public Departamento(int idD, decimal montoD, string nombreD)
        {
            id = idD;
            monto = montoD;
            nombre = nombreD;
        }

        [DataMember]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public decimal Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
