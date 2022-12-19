using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Importamos las interfaces
using AppVenta.Dominio.Interfaces;

namespace AppVenta.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioDetalle<TEntidad, TMovimnientoID>
        : IAgregar<TEntidad>, ITransaccion
    {
    }
}
