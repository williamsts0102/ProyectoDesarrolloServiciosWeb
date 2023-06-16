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
    public class OrderDetallesRepository : Repository<OrderDetalle>, IOrderDetallesRepository
    {
        private ApplicationDbContext _db;
        public OrderDetallesRepository(ApplicationDbContext db): base (db) {
            _db = db;
        }


        public void Update(OrderDetalle objOrderDetalle)
        {
            _db.OrderDetalles.Update(objOrderDetalle);
        }
    }
}
