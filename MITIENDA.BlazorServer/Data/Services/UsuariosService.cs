using MITIENDA.BlazorServer.Data.Entities;
using MITIENDA.BlazorServer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.BlazorServer.Data.Services
{
    public class UsuariosService
    {
        private readonly MiTiendaDbContext _context;

        public UsuariosService(MiTiendaDbContext context)
        {
            _context = context;
        }
        
        public MsgResult  Registrar(RegistroUsuarioModel usuario)
        {
            var res = new MsgResult();

            //TODO: Pendiente verificar que no exista otro usuario con el mismo email
            //TODO: Pendiente validar confirmación de contraseña
            //TODO: Pendiente encryptar clave

            _context.Usuarios.Add(usuario);

            try
            {
                _context.SaveChanges();

                res.IsSuccess = true;
                res.Message = "Usuario registrado correctamente";
            }
            catch (Exception ex)
            {   
                res.IsSuccess = false;
                res.Message = "Error al registrar el usuario";
                res.Error = ex;
            }

            return res;
        }


    }
}
