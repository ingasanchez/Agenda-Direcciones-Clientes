using System;
using System.Collections.Generic;

#nullable disable

namespace Registro_Direcciones_Clientes.Models
{
    public partial class DireccionCliente
    {
        public decimal Iddircliente { get; set; }
        public decimal Idcliente { get; set; }
        public decimal Idsector { get; set; }
        public string Calle { get; set; }
        public string Direccion { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual Sector IdsectorNavigation { get; set; }
    }
}
