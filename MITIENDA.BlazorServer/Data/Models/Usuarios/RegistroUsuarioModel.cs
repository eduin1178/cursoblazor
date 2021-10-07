using MITIENDA.BlazorServer.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.BlazorServer.Data.Models
{
    public class RegistroUsuarioModel
    {
        public int Id { get; set; }
        public int IdRol { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        public string Nombre { get; set; }


        [Required(ErrorMessage ="El email es requerido")]
        [DataType(DataType.EmailAddress, ErrorMessage ="La dirección no es válida")]
        public string Email { get; set; }


        [Required(ErrorMessage ="La contraseña es requerida")]
        [MinLength(6, ErrorMessage ="Mínimo 6 caracteres")]
        public string Clave { get; set; }

        
        [Required(ErrorMessage ="La confirmación de la contraseña es requerida")]
        [MinLength(6, ErrorMessage ="Mínimo 6 caracteres")]
        [Compare("Clave", ErrorMessage ="La confirmación no coincide con la contraseña")]
        public string ConfirmPassword { get; set; }
    }
}
