using System;
using System.Collections.Generic;

#nullable disable

namespace Registro_Direcciones_Clientes.Models
{
    public partial class Pais
    {
        public Pais()
        {
            Provincia = new HashSet<Provincia>();
        }

        public decimal Idpais { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Provincia> Provincia { get; set; }
    }
}
