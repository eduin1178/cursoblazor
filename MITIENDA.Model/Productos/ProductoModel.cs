using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo obligatorio")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage ="Campo obligatorio")]
        public string Referencia { get; set; }
        
        [Required(ErrorMessage ="Campo obligatorio")]
        [MinLength(5, ErrorMessage ="Minimo 5 caracteres")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage ="Campo obligatorio")]
        public decimal Precio { get; set; }
        
        [Required(ErrorMessage ="Campo obligatorio")]
        public decimal Costo { get; set; }
        
        public decimal? Stock { get; set; }

        public decimal? Margen => (Precio - Costo);
    }
}
