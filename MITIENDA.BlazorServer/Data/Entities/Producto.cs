using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.BlazorServer.Data.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Referencia { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public decimal? Stock { get; set; }

    }
}
