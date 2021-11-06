using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MITIENDA.Data.Entities;
using MITIENDA.Data.SqlServer;
using MITIENDA.Models;

namespace MITIENDA.Services
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
