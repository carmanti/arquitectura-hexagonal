using System;
using System.Collections.Generic;
using System.Text;

using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces.Repositorios;
using AppVenta.Aplicaciones.Interfaces;

namespace AppVenta.Aplicaciones.Servicios
{
    public class VentaServicio : IServicioMovimiento<Venta, Guid>
    {
        IRepositorioMovimiento<Venta, Guid> repoVenta;
        IRepositorioBase<Producto, Guid> repoProducto;
        IRepositorioDetalle<VentaDetalle, Guid> repoDetalle;

        public VentaServicio(
            IRepositorioMovimiento<Venta, Guid> _repoVenta, 
            IRepositorioBase<Producto, Guid> _repoProducto, 
            IRepositorioDetalle<VentaDetalle, Guid> _repoDetalle)
        {
            this.repoVenta = _repoVenta;
            this.repoProducto = _repoProducto;
            this.repoDetalle = _repoDetalle;
        }

        public Venta Agregar(Venta entidad)
        {
            if(entidad == null)
            {
                throw new ArgumentNullException("La venta es requerida");
            }

            var ventaAgregada = repoVenta.Agregar(entidad);

            entidad.VentaDetalles.ForEach(detalle =>
            {
                var productoSeleccionado = repoProducto.SeleccionarPorID(detalle.Producto);
                if (productoSeleccionado == null)
                {
                    throw new NullReferenceException("Ustes esta intentando vender un producto que no existe");
                }

                detalle.costoUnitario = productoSeleccionado.costo;
                detalle.precioUnitario = productoSeleccionado.precio;
                detalle.subtotal = detalle.precioUnitario * detalle.cantidadVendida;
                detalle.impuesto = detalle.subtotal * 15 / 100;
                detalle.total = detalle.subtotal + detalle.impuesto;
                repoDetalle.Agregar(detalle);

                productoSeleccionado.cantidadEnStock -= detalle.cantidadVendida;
                repoProducto.Editar(productoSeleccionado);

                entidad.subtotal += detalle.subtotal;
                entidad.impuesto += detalle.impuesto;
                entidad.total += detalle.total;

            });

            repoVenta.GuardarTodosLosCambios();
            return entidad;
        }

        public void Anular(Guid entidadId)
        {
            repoVenta.Anular(entidadId);
            repoVenta.GuardarTodosLosCambios();

        }

        public List<Venta> Listar()
        {
            return repoVenta.Listar();
        }

        public Venta SeleccionarPorID(Venta entidadId)
        {
            return repoVenta.SeleccionarPorID(entidadId);
        }
    }
}