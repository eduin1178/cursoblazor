using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITIENDA.BlazorServer.Data.Models
{
    public class FacturaModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }

        public string NombreCliente { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        public List<ItemFacturaModel> Items { get; set; } = new List<ItemFacturaModel>();

        public decimal  Total  => Items.Sum(x=>x.Subtotal);
        public decimal  Ganancia  => Items.Sum(x=>x.Margen);

    }

    public class ItemFacturaModel
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Costo { get; set; }
        public string Referencia { get; set; }

        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal => Cantidad * Precio;
        public decimal Margen => (Precio-Costo) * Cantidad;
    }
}
