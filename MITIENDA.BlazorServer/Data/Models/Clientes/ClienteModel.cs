using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.BlazorServer.Data.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo obligatorio")]
        public string Nombres { get; set; }

        [Required(ErrorMessage ="Campo obligatorio")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage ="Campo obligatorio")]
        public string Identificacion { get; set; }
        
        [Required(ErrorMessage ="Campo obligatorio")]
        public string Direccion { get; set; }
        
        [Required(ErrorMessage ="Campo obligatorio")]
        public string Telefono { get; set; }
        
        [Required(ErrorMessage ="Campo obligatorio")]
        [DataType(DataType.EmailAddress,  ErrorMessage ="Email no valido")]
        public string Email { get; set; }
    }
}
