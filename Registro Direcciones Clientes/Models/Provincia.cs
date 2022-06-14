using System;
using System.Collections.Generic;

#nullable disable

namespace Registro_Direcciones_Clientes.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Sectors = new HashSet<Sector>();
        }

        public decimal Idprovincia { get; set; }
        public string Descripcion { get; set; }
        public decimal Idpais { get; set; }

        public virtual Pais IdpaisNavigation { get; set; }
        public virtual ICollection<Sector> Sectors { get; set; }
    }
}
