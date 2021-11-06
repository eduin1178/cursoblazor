using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int? CantidadProductos { get; set; }
    }
}
