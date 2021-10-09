using Microsoft.EntityFrameworkCore;
using MITIENDA.BlazorServer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.BlazorServer.Data.Services
{
    public class FacturasService
    {
        private readonly MiTiendaDbContext _context;

        public FacturasService(MiTiendaDbContext context)
        {
            _context = context;
        }

        public FacturaModel Factura(int idFactura)
        {
            var model = _context.Facturas
                .Include(x=>x.Cliente)
                .Include(x=>x.DetallesFacturas).ThenInclude(x=>x.Producto)
                .Where(x=>x.Id == idFactura)
                .Select(x=> new FacturaModel
                {
                    Id = x.Id,
                    Fecha = x.Fecha,
                    Numero = x.Numero,

                    //Cliente
                    IdCliente = x.IdCliente,
                    NombreCliente = x.Cliente.Nombres + " " + x.Cliente.Apellidos,
                    Direccion = x.Cliente.Direccion,
                    Email = x.Cliente.Email,
                    Telefono = x.Cliente.Telefono,

                    //Items
                    Items = x.DetallesFacturas
                    .Select(y=> new ItemFacturaModel
                    {
                        Id = y.Id,
                        IdFactura = y.IdFactura,
                        
                        //Productos
                        IdProducto = y.IdProducto,
                        NombreProducto = y.Producto.Nombre,
                        Cantidad = y.Cantidad,
                        Costo = y.Costo,
                        Precio = y.Precio,

                    }).ToList()

                }).FirstOrDefault();

            return model;
        }

        public List<FacturaModel> ListaFacturas(DateTime desde, DateTime hasta)
        {
            var model = _context.Facturas
                .Include(x=>x.Cliente)
                .Include(x=>x.DetallesFacturas).ThenInclude(x=>x.Producto)
                .Where(x=>x.Fecha >= desde && x.Fecha <= hasta)
                .Select(x=> new FacturaModel
                {
                    Id = x.Id,
                    Fecha = x.Fecha,
                    Numero = x.Numero,

                    //Cliente
                    IdCliente = x.IdCliente,
                    NombreCliente = x.Cliente.Nombres +" " + x.Cliente.Apellidos,
                    Direccion = x.Cliente.Direccion,
                    Email = x.Cliente.Email,
                    Telefono = x.Cliente.Telefono,

                    //Items
                    Items = x.DetallesFacturas
                    .Select(y=> new ItemFacturaModel
                    {
                        Id = y.Id,
                        IdFactura = y.IdFactura,
                        
                        //Productos
                        IdProducto = y.IdProducto,
                        NombreProducto = y.Producto.Nombre,
                        Cantidad = y.Cantidad,
                        Costo = y.Costo,
                        Precio = y.Precio,

                    }).ToList()

                }).ToList();

            return model;
        }

        //public MsgResult Crear(FacturaModel model)
        //{

        //}

        //public MsgResult Modificar(FacturaModel model)
        //{

        //}

        //public MsgResult Eliminar(int idFactura)
        //{

        //}
    }
}
