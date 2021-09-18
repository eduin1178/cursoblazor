using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.BlazorServer.Data.Entities
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
