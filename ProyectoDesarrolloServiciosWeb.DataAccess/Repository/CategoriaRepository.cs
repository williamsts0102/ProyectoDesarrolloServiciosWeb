﻿using ProyectoDesarrolloServiciosWeb.DataAccess.Data;
using ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository;
using ProyectoDesarrolloServiciosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloServiciosWeb.DataAccess.Repository
{
    public class CarritoComprasRepository : Repository<CarritoCompras>, ICarritoRepository
    {
        private ApplicationDbContext _db;
        public CarritoComprasRepository(ApplicationDbContext db): base (db) {
            _db = db;
        }


        public void Update(CarritoCompras objCarrito)
        {
            _db.carrito.Update(objCarrito);
        }
    }
}
