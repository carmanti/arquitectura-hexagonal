using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Dominio
{
    public class Venta
    {
        public Guid ventaID { get; set; }
        public long numeroVenta { get; set; }
        public string concepto { get; set; }
        public decimal subtotal { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }
        public Boolean anulado { get; set; }
        public List<VentaDetalle> VentaDetalles { get; set; }

    }
}
