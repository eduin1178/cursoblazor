using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.Data.Entities
{
    public class DetalleFactura
    {
        public int Id { get; set; }

        public int IdFactura { get; set; }
        public virtual Factura Factura { get; set; }

        public int IdProducto { get; set; }
        public virtual Producto Producto { get; set; }

        public decimal Costo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }

    }
}
