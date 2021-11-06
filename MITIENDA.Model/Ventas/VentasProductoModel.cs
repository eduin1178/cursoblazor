using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.Models
{
	public class VentasProductoModel
	{
		public string NumeroFactura { get; set; }
		public DateTime FechaFactura { get; set; }
		public string NombreClinte { get; set; }
		public decimal Cantidad { get; set; }
		public decimal Precio { get; set; }
		public decimal Costo { get; set; }

		public decimal Total => Cantidad*Precio;
		public decimal Margen => (Precio - Costo) * Cantidad;
	}
}
