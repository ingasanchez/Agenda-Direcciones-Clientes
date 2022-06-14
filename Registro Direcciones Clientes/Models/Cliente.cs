using System;
using System.Collections.Generic;

#nullable disable

namespace Registro_Direcciones_Clientes.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            DireccionClientes = new HashSet<DireccionCliente>();
        }

        public decimal Idcliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual ICollection<DireccionCliente> DireccionClientes { get; set; }
    }
}
