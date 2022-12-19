﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces.Repositorios;
using AppVenta.Aplicaciones.Interfaces;

namespace AppVenta.Aplicaciones.Servicios
{
    public class ProductoServicio : IServicioBase<Producto, Guid>
    {
        private readonly IRepositorioBase<Producto, Guid> repoProducto;

        public ProductoServicio(IRepositorioBase<Producto, Guid> _repoProducto)
        {
            repoProducto = _repoProducto;
        }

        public Producto Agregar(Producto entidad)
        {
            //Logica de gestion de negocio
            if (entidad == null)
                throw new ArgumentNullException("El producto es requerido");
            var resultProducto = repoProducto.Agregar(entidad);
            repoProducto.GuardarTodosLosCambios();
            return resultProducto;
        }

        public void Editar(Producto entidad)
        {
            if (entidad== null) throw new ArgumentNullException("El producto es requerido");

            repoProducto.Editar(entidad);
            repoProducto.GuardarTodosLosCambios();

        }

        public void Eliminar(Guid entidadId)
        {
            repoProducto.Eliminar(entidadId);
            repoProducto.GuardarTodosLosCambios();
        }

        public List<Producto> Listar()
        {
            return repoProducto.Listar();
        }

        public Producto SeleccionarPorID(Producto entidadId)
        {
            return repoProducto.SeleccionarPorID(entidadId);
        }
    }
}
