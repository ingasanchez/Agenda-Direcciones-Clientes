using System;
using System.Collections.Generic;

#nullable disable

namespace Registro_Direcciones_Clientes.Models
{
    public partial class Sector
    {
        public Sector()
        {
            DireccionClientes = new HashSet<DireccionCliente>();
        }

        public decimal Idsector { get; set; }
        public string Descripcion { get; set; }
        public decimal Idprovincia { get; set; }

        public virtual Provincia IdprovinciaNavigation { get; set; }
        public virtual ICollection<DireccionCliente> DireccionClientes { get; set; }
    }
}
