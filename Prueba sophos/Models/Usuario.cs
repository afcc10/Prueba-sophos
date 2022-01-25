using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba_sophos.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Venta = new HashSet<Ventas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Documento { get; set; }

        public virtual ICollection<Ventas> Venta { get; set; }
    }
}
