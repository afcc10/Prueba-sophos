using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba_sophos.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Venta = new HashSet<Ventas>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? Cantidad { get; set; }
        public int? Valor { get; set; }

        public virtual ICollection<Ventas> Venta { get; set; }
    }
}
