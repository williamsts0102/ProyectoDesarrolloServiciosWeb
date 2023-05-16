using ProyectoDesarrolloServiciosWeb.DataAccess.Data;
using ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository;
using ProyectoDesarrolloServiciosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloServiciosWeb.DataAccess.Repository
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private ApplicationDbContext _db;
        public ProductoRepository(ApplicationDbContext db): base (db) {
            _db = db;
        }


        public void Update(Producto producto)
        {
            _db.Update(producto);
        }
    }
}
