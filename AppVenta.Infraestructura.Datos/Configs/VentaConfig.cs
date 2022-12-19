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
    class VentaConfig : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("tblVentas");
            builder.HasKey(c => c.ventaID);

            builder.HasMany(venta => venta.VentaDetalles).WithOne(detalle => detalle.Venta);
        }
    }
}
