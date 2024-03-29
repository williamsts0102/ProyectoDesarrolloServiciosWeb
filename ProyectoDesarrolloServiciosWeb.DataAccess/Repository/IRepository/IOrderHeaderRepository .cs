﻿using ProyectoDesarrolloServiciosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository
{
    /*en ves de usar lo generico T usara la clase Categoria*/
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader orderHeader);
        void UpdateStatus(int id, string estadoPedido, string? estadoPago = null);
        void UpdateStripePaymentID(int id, string sessionId, string idPago );
    }
}





