using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.BlazorServer.Data.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
    }
}
