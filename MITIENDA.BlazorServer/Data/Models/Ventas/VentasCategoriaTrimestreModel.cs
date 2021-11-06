using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.BlazorServer.Data.Models
{
	public class VentasCategoriaTrimestreModel
	{
		public int IdCategoria { get; set; }
		public string Categoria { get; set; }
		public decimal VentasQ1 { get; set; }
		public decimal PVQ1 => VentasQ1 / VentasTotales;
		public decimal VentasQ2 { get; set; }
		public decimal PVQ2 => VentasQ2 / VentasTotales;
		public decimal VentasQ3 { get; set; }
		public decimal PVQ3 => VentasQ3 / VentasTotales;
		public decimal VentasQ4 { get; set; }
		public decimal PVQ4 => VentasQ4 / VentasTotales;
		public decimal VentasTotales { get; set; }
		public decimal PVTotales => PVQ1 + PVQ2 + PVQ3 + PVQ4;
	}
}
