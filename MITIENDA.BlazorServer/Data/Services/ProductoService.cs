using Microsoft.EntityFrameworkCore;
using MITIENDA.BlazorServer.Data.Entities;
using MITIENDA.BlazorServer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.BlazorServer.Data.Services
{
    public class ProductoService
    {
        private readonly MiTiendaDbContext _context;
        public ProductoService(MiTiendaDbContext context)
        {
            _context = context;
        }

        public ProductoModel Producto(int idProducto)
        {
            var model = _context.Productos
                .Where(x=>x.Id == idProducto)
                .Select(x=> new ProductoModel
                {
                    Id = x.Id,
                    IdCategoria = x.IdCategoria,
                    Referencia = x.Referencia,
                    Nombre = x.Nombre,
                    Costo = x.Costo,
                    Precio = x.Precio,
                    Stock = x.Stock,
                }).FirstOrDefault();

            return model;
        }

        public ProductoModel Producto(string busqueda)
        {
            var model = _context.Productos
                .Where(x=>x.Referencia.Contains(busqueda) || x.Nombre.Contains(busqueda) )
                .Select(x=> new ProductoModel
                {
                    Id = x.Id,
                    IdCategoria = x.IdCategoria,
                    Referencia = x.Referencia,
                    Nombre = x.Nombre,
                    Costo = x.Costo,
                    Precio = x.Precio,
                    Stock = x.Stock,
                }).FirstOrDefault();

            return model;
        }

        public List<ProductoModel> ListaProductos()
        {
            var model = _context.Productos
                .Select(x=> new ProductoModel
                {
                    Id = x.Id,
                    IdCategoria = x.IdCategoria,
                    Referencia = x.Referencia,
                    Nombre = x.Nombre,
                    Costo = x.Costo,
                    Precio = x.Precio,
                    Stock = x.Stock,
                }).ToList();

            return model;
        }

        public List<ProductoModel> ListaProductos(int idCategoria)
        {
            var model = _context.Productos
                .Where(x=>x.IdCategoria == idCategoria)
                .Select(x=> new ProductoModel
                {
                    Id = x.Id,
                    IdCategoria = x.IdCategoria,
                    Referencia = x.Referencia,
                    Nombre = x.Nombre,
                    Costo = x.Costo,
                    Precio = x.Precio,
                    Stock = x.Stock,
                }).ToList();

            return model;
        }

        public MsgResult Crear(ProductoModel model)
        {
            var result = new MsgResult();

            var entity = _context.Productos.FirstOrDefault(x=>x.Referencia == model.Referencia);

            if (entity!=null)
            {
                result.IsSuccess = false;
                result.Message = $"Ya existe un producto con la referencia especificada: {model.Referencia}";
                return result;
            }

            entity = new Producto
            {
                Nombre = model.Nombre,
                Costo = model.Costo,
                IdCategoria = model.IdCategoria,
                Precio = model.Precio,
                Referencia = model.Referencia,
                Stock = model.Stock,
            };

            _context.Productos.Add(entity);

            try
            {
                _context.SaveChanges();
                result.IsSuccess = true;
                result.Message = "Producto creado correctamente";

                //El ID se retorna para que pueda usarse en la vista para hacer algunas cosas con el.
                result.Code = entity.Id;
                model.Id = entity.Id;
                result.Objeto = model;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error al crear el producto";
                result.Error = ex;
            }

            return result;
        }

        public MsgResult Modificar(ProductoModel model)
        {
            var result = new MsgResult();

            var entity = _context.Productos.FirstOrDefault(x=>x.Id == model.Id);

            if (entity==null)
            {
                result.IsSuccess = false;
                result.Message = $"No se encontró el producto que intenta modificar";
                return result;
            }

            entity.Nombre = model.Nombre;
            entity.Precio = model.Precio;
            entity.Costo = model.Costo;
            entity.Stock = model.Stock;
            entity.Referencia = model.Referencia;
            entity.IdCategoria = model.IdCategoria;
            

            try
            {
                _context.SaveChanges();
                result.IsSuccess = true;
                result.Message = "Producto modificado correctamente";

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error al modificar el producto";
                result.Error = ex;
            }

            return result;
        }

        public MsgResult Eliminar(int idProducto)
        {
            var result = new MsgResult();

            var entity = _context.Productos
                .Include(x=>x.DetallesFacturas)
                .FirstOrDefault(x=>x.Id == idProducto);

            if (entity==null)
            {
                result.IsSuccess = false;
                result.Message = $"No se encontró el producto que intenta eliminar";
                result.Code = -1;
                return result;
            }

            if (entity.DetallesFacturas.Count >0)
            {
                result.IsSuccess = false;
                result.Message = $"No se puede eliminar el producto porque tiene facturas relacionadas.";
                result.Code = -2;
                return result;
            }

             _context.Productos.Remove(entity);        

            try
            {
                _context.SaveChanges();
                result.IsSuccess = true;
                result.Message = "Producto eliminado correctamente";

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error al eliminar el producto";
                result.Error = ex;
            }

            return result;
        }
    }
}
