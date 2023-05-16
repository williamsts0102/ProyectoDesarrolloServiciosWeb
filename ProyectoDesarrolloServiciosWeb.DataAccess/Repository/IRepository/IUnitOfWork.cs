using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoriaRepository Categoria { get; }
        IProductoRepository Producto { get; }

        void Save();

    }

}
