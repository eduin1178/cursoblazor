using Microsoft.EntityFrameworkCore;
using MITIENDA.Data.Entities;
using MITIENDA.Data.SqlServer;
using MITIENDA.Models;
using MITIENDA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.Services
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
				.Include(x => x.Cliente)
				.Include(x => x.DetallesFacturas).ThenInclude(x => x.Producto)
				.Where(x => x.Id == idFactura)
				.Select(x => new FacturaModel
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
					.Select(y => new ItemFacturaModel
					{
						Id = y.Id,
						IdFactura = y.IdFactura,

						//Productos                        
						Referencia = y.Producto.Referencia,
						IdProducto = y.IdProducto,
						NombreProducto = y.Producto.Nombre,
						Cantidad = y.Cantidad,
						Costo = y.Costo,
						Precio = y.Precio,

					}).ToList()

				}).FirstOrDefault();

			return model;
		}

		public List<FacturaModel> ListaFacturas(DateTime desde, DateTime hasta, int? idCliente = null)
		{
			var model = _context.Facturas
				.Include(x => x.Cliente)
				.Include(x => x.DetallesFacturas).ThenInclude(x => x.Producto)
				.Where(x => x.Fecha >= desde && x.Fecha <= hasta
				&& (x.IdCliente == idCliente || idCliente == null))

				.Select(x => new FacturaModel
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
					.Select(y => new ItemFacturaModel
					{
						Id = y.Id,
						IdFactura = y.IdFactura,

						//Productos
						Referencia = y.Producto.Referencia,
						IdProducto = y.IdProducto,
						NombreProducto = y.Producto.Nombre,
						Cantidad = y.Cantidad,
						Costo = y.Costo,
						Precio = y.Precio,

					}).ToList()

				}).ToList();

			return model;
		}

		public MsgResult Crear(FacturaModel model)
		{
			var result = new MsgResult();

			var entity = _context.Facturas
				.Include(x => x.DetallesFacturas)
				.FirstOrDefault(x => x.Numero == model.Numero);

			if (entity != null)
			{
				result.IsSuccess = false;
				result.Message = $"Ya existe una factura con el número {model.Numero}";
				return result;
			}

			entity = new Factura
			{
				Fecha = model.Fecha,
				Numero = model.Numero,
				IdCliente = model.IdCliente,
				DetallesFacturas = model.Items
				.Select(x => new DetalleFactura
				{
					IdFactura = x.IdFactura,
					IdProducto = x.IdProducto,
					Precio = x.Precio,
					Costo = x.Costo,
					Cantidad = x.Cantidad,
				}).ToList(),
			};

			_context.Facturas.Add(entity);

			try
			{
				_context.SaveChanges();
				result.IsSuccess = true;
				result.Message = "Factura creada correctamente";
				result.Code = entity.Id;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = "Error al crear la factura";
				result.Error = ex;
			}

			return result;
		}

		public MsgResult Modificar(FacturaModel model)
		{
			var result = new MsgResult();

			var entity = _context.Facturas
				.Include(x => x.DetallesFacturas)
				.FirstOrDefault(x => x.Id == model.Id);

			if (entity == null)
			{
				result.IsSuccess = false;
				result.Message = $"La factura que intenta modificar no existe";
				return result;
			}

			entity.Numero = model.Numero;
			entity.Fecha = model.Fecha;
			entity.IdCliente = model.IdCliente;

			var itemsFactura = entity.DetallesFacturas.ToList();

			foreach (var itemModel in model.Items)
			{
				var itemFactura = itemsFactura.FirstOrDefault(x => x.Id == itemModel.Id);
				if (itemFactura != null)
				{
					itemFactura.Cantidad = itemModel.Cantidad;
					itemFactura.Precio = itemModel.Precio;
				}
			}


			try
			{
				_context.SaveChanges();
				result.IsSuccess = true;
				result.Message = "Factura guardada correctamente";
				result.Code = entity.Id;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = "Error al guardar la factura";
				result.Error = ex;
			}

			return result;
		}

		public MsgResult Eliminar(int idFactura)
		{
			var result = new MsgResult();

			var entity = _context.Facturas.FirstOrDefault(x => x.Id == idFactura);

			if (entity == null)
			{
				result.IsSuccess = false;
				result.Message = $"La factura que intenta eliminar no existe";
				return result;
			}

			_context.Facturas.Remove(entity);

			try
			{
				_context.SaveChanges();
				result.IsSuccess = true;
				result.Message = "Factura eliminada correctamente";
				result.Code = entity.Id;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = "Error al eliminar la factura";
				result.Error = ex;
			}

			return result;
		}

		//Elementos de la factura
		public MsgResult AgregarProducto(ItemFacturaModel model)
		{
			var result = new MsgResult();

			var entity = _context.Facturas
				.Include(x => x.DetallesFacturas)
				.FirstOrDefault(x => x.Id == model.IdFactura);

			if (entity == null)
			{
				result.IsSuccess = false;
				result.Message = "No existe la factura a la cual desea agregar el producto";
				return result;
			}


			var item = new DetalleFactura
			{
				IdFactura = model.IdFactura,
				IdProducto = model.IdProducto,
				Costo = model.Costo,
				Cantidad = model.Cantidad,
				Precio = model.Precio,
			};

			entity.DetallesFacturas.Add(item);

			try
			{
				_context.SaveChanges();
				result.IsSuccess = true;
				result.Message = "Elemento agregado correctamente";
				result.Code = item.Id;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = "Error al agregar el producto a la factura.";
				result.Error = ex;
			}


			return result;

		}

		public MsgResult EliminarProducto(ItemFacturaModel model)
		{
			var result = new MsgResult();

			var entity = _context.DetallesFacturas
				.FirstOrDefault(x => x.Id == model.Id);

			if (entity == null)
			{
				result.IsSuccess = false;
				result.Message = "No existe el producto que desea eliminar";
				return result;
			}

			_context.DetallesFacturas.Remove(entity);

			try
			{
				_context.SaveChanges();
				result.IsSuccess = true;
				result.Message = "Elemento eliminado correctamente";
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = "Error al eliminar el producto a la factura.";
				result.Error = ex;
			}


			return result;

		}

		//Consutlas
		public List<VentasClientesModel> VentasCliente(int idCliente, DateTime desde, DateTime hasta)
		{
			var ventas = _context.DetallesFacturas
				.Where(x => x.Factura.IdCliente == idCliente
				&& (x.Factura.Fecha <= hasta && x.Factura.Fecha >= desde))
				.Select(x => new VentasClientesModel
				{
					NumeroFactura = x.Factura.Numero,
					FechaFactura = x.Factura.Fecha,
					Cantidad = x.Cantidad,
					Precio = x.Precio,
					Costo = x.Costo,
					NombreProducto = x.Producto.Nombre,
				}).ToList();

			return ventas;
		}

		public List<VentasProductoModel> VentasProducto(int idProducto, DateTime desde, DateTime hasta)
		{
			var ventas = _context.DetallesFacturas
				.Include(x => x.Factura).ThenInclude(x => x.Cliente)
				.Where(x => x.Producto.Id == idProducto
				&& (x.Factura.Fecha <= hasta && x.Factura.Fecha >= desde))
				.ToList()
				.Select(x => new VentasProductoModel
				{
					NumeroFactura = x.Factura.Numero,
					FechaFactura = x.Factura.Fecha,
					Cantidad = x.Cantidad,
					Precio = x.Precio,
					Costo = x.Costo,
					NombreClinte = $"{x.Factura.Cliente.Apellidos} {x.Factura.Cliente.Nombres}",
				}).ToList();

			return ventas;
		}

		public List<ResumenVentaModel> ProductosMasVentidos(int? top = null)
		{
			if (top==null)
			{
				top = 5;
			}

			var litmit = Convert.ToInt32(top);

			var productos = _context.Productos
				.Select(x=> new ResumenVentaModel
				{
					Descripcion = x.Nombre,
					Unidades = x.DetallesFacturas.Sum(y=>y.Cantidad),
					Valor = x.DetallesFacturas.Sum(y=>y.Cantidad*y.Precio)
				})
				.OrderByDescending(x=>x.Unidades)
				.Take(litmit)
				.ToList();

			return productos;
		}

		public List<ResumenVentaModel> MejoresClientes(int? top = null)
		{
			if (top==null)
			{
				top = 5;
			}

			var litmit = Convert.ToInt32(top);

			var clientes = _context.Clientes
				.Select(x=> new ResumenVentaModel
				{
					Descripcion = x.Apellidos + " " + x.Nombres,

					Unidades = x.Facturas.SelectMany(y =>y.DetallesFacturas).Sum(y=>y.Cantidad),

					Valor = x.Facturas.SelectMany(y =>y.DetallesFacturas).Sum(y=>y.Cantidad * y.Precio),
				})
				.OrderByDescending(x=>x.Valor)
				.Take(litmit)
				.ToList();

			return clientes;
		}

		public List<ResumenVentaModel> MejoresCategorias(int? top = null)
		{
			if (top==null)
			{
				top = 5;
			}

			var litmit = Convert.ToInt32(top);

			var categorias = _context.Categorias
				.Select(x=> new ResumenVentaModel
				{
					Descripcion = x.Nombre,

					Unidades = x.Productos.SelectMany(y =>y.DetallesFacturas).Sum(y=>y.Cantidad),

					Valor = x.Productos.SelectMany(y =>y.DetallesFacturas).Sum(y=>y.Cantidad * y.Precio),
				})
				.OrderByDescending(x=>x.Unidades)
				.Take(litmit)
				.ToList();

			return categorias;
		}

		public List<ResumenVentaModel> VentasPorMes(int año, int? top = null)
		{
			if (top==null)
			{
				top = 5;
			}

			var litmit = Convert.ToInt32(top);

			var query = _context.DetallesFacturas
				.Include(x=>x.Factura)
				.Where(x=>x.Factura.Fecha.Year == año)
				.ToList();

			var lista = query.Select(x=> new
			{
				IdMes = x.Factura.Fecha.Month,
				Mes = x.Factura.Fecha.ToString("MMMM").ToUpper(),
				Unidades = x.Cantidad,
				Valor = x.Cantidad * x.Precio
			}).GroupBy( g => new { g.IdMes, g.Mes })
			.Select(x=> new ResumenVentaModel
			{
				Orden = x.Key.IdMes,
				Descripcion = x.Key.Mes,
				Unidades = x.Sum(y=>y.Unidades),
				Valor = x.Sum(y=>y.Valor)
			}).OrderBy(x=>x.Orden).ToList();


			return lista;
		}

		public List<VentasCategoriaTrimestreModel> VentasPorTrimestreCategoria(int año)
		{
			
			var query = _context.DetallesFacturas
				.Include(x=>x.Factura)
				.Include(x=>x.Producto).ThenInclude(x=>x.Categoria)
				.Where(x=>x.Factura.Fecha.Year == año)
				.ToList();

			var lista = query.Select(x=> new
			{
				IdCategoria = x.Producto.IdCategoria,
				Categoria = x.Producto.Categoria.Nombre,
				IdTrimestre = x.Factura.Fecha.GetQuarter(),
				Trimestre = x.Factura.Fecha.GetQuarterName(),
				Unidades = x.Cantidad,
				Valor = x.Cantidad * x.Precio
			}).ToList();

			var pivot = lista.GroupBy(g=> new
			{
				g.IdCategoria,
				g.Categoria,
			}).Select(x=> new VentasCategoriaTrimestreModel
			{
				IdCategoria = x.Key.IdCategoria,
				Categoria = x.Key.Categoria,
				VentasQ1 = x.Where(x=>x.IdTrimestre == 1).Sum(x=>x.Valor),
				VentasQ2 = x.Where(x=>x.IdTrimestre == 2).Sum(x=>x.Valor),
				VentasQ3 = x.Where(x=>x.IdTrimestre == 3).Sum(x=>x.Valor),
				VentasQ4 = x.Where(x=>x.IdTrimestre == 4).Sum(x=>x.Valor),
				VentasTotales = x.Sum(x=>x.Valor)
			}).ToList();

			return pivot;
		}
	}
}
