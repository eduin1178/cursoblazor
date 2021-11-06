using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.Models
{
    public class LoginUsuarioModel
    {
        [Required(ErrorMessage ="Campo obligatorio")]
        [DataType(DataType.EmailAddress, ErrorMessage ="El email no es válido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Campo obligatorio")]
        [MinLength(6, ErrorMessage ="Minimo 6 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
        public bool RememberMe { get; set; }
    }
}
