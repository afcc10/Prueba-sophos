using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba_sophos.Models
{
    public partial class Ventas
    {
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public int? ValorPagar { get; set; }

        public virtual Usuario IdClienteNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
