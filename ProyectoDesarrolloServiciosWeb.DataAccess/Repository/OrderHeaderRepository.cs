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
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db): base (db) {
            _db = db;
        }
        

        public void Update(OrderHeader objOrderHeader)
        {
            _db.OrderHeaders.Update(objOrderHeader);
        }

        public void UpdateStatus(int id, string estadoPedido, string? estadoPago = null)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.EstadoPedido = estadoPedido;
                if (!string.IsNullOrEmpty(estadoPago))
                {
                    orderFromDb.EstadoPago = estadoPago;
                }
            }
        }
        public void UpdateStripePaymentID(int id, string sessionId, string idPago)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (!string.IsNullOrEmpty(sessionId))
            {
                orderFromDb.SessionId = sessionId;
            }
            if (!string.IsNullOrEmpty(idPago))
            {
                orderFromDb.IdPago = idPago;
                orderFromDb.FechaPago = DateTime.Now;
            }
            
        }
        
    }
}
