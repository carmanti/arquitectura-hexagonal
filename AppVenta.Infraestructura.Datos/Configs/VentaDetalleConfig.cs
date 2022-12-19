using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVenta.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppVenta.Infraestructura.Datos.Configs
{
    internal class VentaDetalleConfig : IEntityTypeConfiguration<VentaDetalle>
    {
        public void Configure(EntityTypeBuilder<VentaDetalle> builder)
        {
            builder.ToTable("tblVentasDetalle");
            builder.HasKey(c=> new {c.productoID, c.ventaID});
            builder.HasOne(detalle => detalle.Producto).WithMany(venta => venta.VentaDetalles);
        }
    }
}
