using MITIENDA.Data.Entities;
using MITIENDA.Data.SqlServer;
using MITIENDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.Services
{
    public class ClientesService
    {
        private readonly MiTiendaDbContext _context;

        public ClientesService(MiTiendaDbContext context)
        {
            _context = context;
        }

        public ClienteModel Cliente(int idCliente)
        {
            var model = _context.Clientes
                 .Where(x => x.Id == idCliente)
                 .Select(x => new ClienteModel
                 {
                     Id = x.Id,
                     Nombres = x.Nombres,
                     Apellidos = x.Apellidos,
                     Direccion = x.Direccion,
                     Email = x.Email,
                     Identificacion = x.Identificacion,
                     Telefono = x.Telefono,
                 }).FirstOrDefault();

            return model;

        }

        public List<ClienteModel> ListaClientes()
        {
            var model = _context.Clientes
                .Select(x => new ClienteModel
                {
                    Id = x.Id,
                    Nombres = x.Nombres,
                    Apellidos = x.Apellidos,
                    Direccion = x.Direccion,
                    Email = x.Email,
                    Identificacion = x.Identificacion,
                    Telefono = x.Telefono,
                }).ToList();

            return model;
        }

        public MsgResult Crear(ClienteModel model)
        {
            var result = new MsgResult();

            var entity = _context.Clientes.FirstOrDefault(x => x.Identificacion == model.Identificacion);

            if (entity != null)
            {
                result.IsSuccess = false;
                result.Message = $"Ya existe un cliente creado con la identifación {model.Identificacion}";
                return result;
            }

            entity = new Cliente
            {
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                Telefono = model.Telefono,
                Identificacion = model.Identificacion,
                Direccion = model.Direccion,
                Email = model.Email
            };

            _context.Clientes.Add(entity);

            try
            {
                _context.SaveChanges();

                result.IsSuccess = true;
                result.Message = "Cliente registrado correctamente";
                result.Code = entity.Id;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error al crear el cliente";
                result.Error = ex;
            }

            return result;

        }

        public MsgResult Modificar(ClienteModel model)
        {
            var result = new MsgResult();

            var entity = _context.Clientes.FirstOrDefault(x => x.Id == model.Id);

            if (entity == null)
            {
                result.IsSuccess = false;
                result.Message = $"Cliente no encontrado";
                return result;
            }

            entity.Nombres = model.Nombres;
            entity.Apellidos = model.Apellidos;
            entity.Identificacion = model.Identificacion;
            entity.Direccion = model.Direccion;
            entity.Email = model.Email;
            entity.Telefono = model.Telefono;
            
            try
            {
                _context.SaveChanges();

                result.IsSuccess = true;
                result.Message = "Cliente modificado correctamente";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error al modificar el cliente";
                result.Error = ex;
            }

            return result;

        }

        public MsgResult Eliminar(int idCliente)
        {
            var result = new MsgResult();

            var entity = _context.Clientes.FirstOrDefault(x => x.Id == idCliente);

            if (entity == null)
            {
                result.IsSuccess = false;
                result.Message = $"Cliente no encontrado";
                return result;
            }

            //TODO: Validar relaciones

            _context.Clientes.Remove(entity);

            try
            {
                _context.SaveChanges();

                result.IsSuccess = true;
                result.Message = "Cliente eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error al eliminar el cliente";
                result.Error = ex;
            }

            return result;
        }
    }
}
