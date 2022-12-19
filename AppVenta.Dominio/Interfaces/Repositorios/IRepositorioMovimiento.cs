﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

//importamos las interfaces
using AppVenta.Dominio.Interfaces;

namespace AppVenta.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioMovimiento<TEntidad, TEntidadID>
    
    :IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, ITransaccion {
        void Anular(TEntidadID entidadId);
    }
}
