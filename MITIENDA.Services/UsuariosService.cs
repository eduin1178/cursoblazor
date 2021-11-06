using Microsoft.EntityFrameworkCore;
using MITIENDA.Core;
using MITIENDA.Data.Entities;
using MITIENDA.Data.SqlServer;
using MITIENDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.Services
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

            
            var newUser = _context.Usuarios                
                .FirstOrDefault(x => x.Email == usuario.Email);

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

        public MsgResult Login(LoginUsuarioModel model)
        {
            var result = new MsgResult();

            var user = _context.Usuarios
                .Include(x=>x.Rol)
                .FirstOrDefault(u=>u.Email==model.Email);

            if (user==null)
            {
                result.IsSuccess =false;
                result.Message = "Usuario no existe";

                return result;
            }

            var passwordHashed = model.Password.Encriptar();

            if (user.Clave != passwordHashed)
            {
                result.IsSuccess = false;
                result.Message = "Contraseña no válida";
                return result;
            }

            result.IsSuccess = true;
            result.Message = "Acceso concedido";
            result.Objeto = user;
            return result;
        }
    }
}
