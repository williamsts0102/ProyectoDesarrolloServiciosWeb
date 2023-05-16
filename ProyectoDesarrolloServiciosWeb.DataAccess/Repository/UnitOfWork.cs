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
        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Categoria = new CategoriaRepository(_db);
            Producto = new ProductoRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
