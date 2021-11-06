using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.BlazorServer.Data.Models
{
	public class ResumenVentaModel
	{
		public int Orden { get; set; }
		public string Descripcion { get; set; }
		public decimal Unidades { get; set; }
		public decimal Valor { get; set; }
	}
}

