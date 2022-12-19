using AppVenta.Dominio.Interfaces.Repositorios;
using AppVenta.Dominio;
using AppVenta.Infraestructura.Datos.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Infraestructura.Datos.Repositorios
{
    public class VentaRepositorio : IRepositorioMovimiento<Venta, Guid>
    {

        private VentaContexto db;

        public VentaRepositorio(VentaContexto _db)
        {
            db = _db;
        }

        public Venta Agregar(Venta entidad)
        {
            entidad.ventaID = Guid.NewGuid();
            db.Ventas.Add(entidad);
            return entidad;
        }

        public void Anular(Guid entidadId)
        {
            var ventaSeleccionada = db.Ventas.Where(c => c.ventaID == entidadId).FirstOrDefault();
            if (ventaSeleccionada == null)
                throw new NullReferenceException("Esta intentando anular una venta que no existe 😡😡😡");

            ventaSeleccionada.anulado = true;
            db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Venta> Listar()
        {
            return db.Ventas.ToList();
        }

        public Venta SeleccionarPorID(Guid entidadId)
        {
            var ventaSeleccionada = db.Ventas.Where(c => c.ventaID == entidadId).FirstOrDefault();
            return ventaSeleccionada;
        }
    }
}
