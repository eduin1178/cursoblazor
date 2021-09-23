using MITIENDA.BlazorServer.Data.Entities;
using MITIENDA.BlazorServer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MITIENDA.BlazorServer.Data.Extensions;

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

            
            var newUser = _context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);

            if (newUser!=null)
            {
                res.IsSuccess = false;
                res.Message = "Ya existe un usuario con este email";
                return res;
            }

            //TODO: Pendiente validar confirmación de contraseña
            //TODO: Pendiente encryptar clave

            var claveEncriptada = usuario.Clave.Encriptar();

            newUser = new Usuario
            {
                IdRol = usuario.IdRol,
                Email = usuario.Email,
                Clave = claveEncriptada,
                Nombre = usuario.Nombre,
            };

            _context.Usuarios.Add(newUser);

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

        public MsgResult ValidarEmail(string email)
        {
            var res = new MsgResult();

            var existeEmail = _context.Usuarios.FirstOrDefault(x => x.Email == email);

            if (existeEmail==null)
            {
                res.IsSuccess = false;
            }
            else
            {
                res.IsSuccess = true;
            }

            return res;
        }
    }
}
