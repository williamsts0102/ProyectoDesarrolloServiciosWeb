using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoDesarrolloServiciosWeb.DataAccess.Data;
using ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloServiciosWeb.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public ICategoriaRepository Categoria { get; private set; }
        public IProductoRepository Producto { get; private set; }
        public ICompanyRepository Company { get; private set; } 
        public ICarritoRepository Carrito { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }

        public IOrderHeaderRepository OrderHeader { get; private set; }

        public IOrderDetallesRepository OrderDetalles { get; private set; }

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Categoria = new CategoriaRepository(_db);
            Producto = new ProductoRepository(_db);
            Company = new CompanyRepository(_db);
            Carrito = new CarritoComprasRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetalles=new OrderDetallesRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
