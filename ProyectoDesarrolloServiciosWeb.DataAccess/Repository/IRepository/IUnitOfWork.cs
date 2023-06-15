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
        ICompanyRepository Company { get; }
        
        ICarritoRepository Carrito { get; }
        IApplicationUserRepository ApplicationUser { get; }
        void Save();

    }

}
