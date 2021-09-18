using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MITIENDA.BlazorServer.Data.Entities;

namespace MITIENDA.BlazorServer.Data.Services
{
    public class RolesService
    {
        private readonly MiTiendaDbContext _context;

        public RolesService(MiTiendaDbContext context)
        {
            _context = context;
        }

        public List<Rol> ListaRoles()
        {
            var lista =  _context.Roles.ToList();

            return lista;
        }
    }
}
