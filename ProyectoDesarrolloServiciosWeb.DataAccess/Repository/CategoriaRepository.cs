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
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private ApplicationDbContext _db;
        public CategoriaRepository(ApplicationDbContext db): base (db) {
            _db = db;
        }


        public void Update(Categoria categoria)
        {
            _db.Update(categoria);
        }
    }
}
