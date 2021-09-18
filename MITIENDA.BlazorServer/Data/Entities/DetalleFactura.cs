using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.BlazorServer.Data.Entities
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
