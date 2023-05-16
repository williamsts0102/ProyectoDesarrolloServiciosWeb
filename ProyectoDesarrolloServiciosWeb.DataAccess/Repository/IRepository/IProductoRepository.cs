﻿using ProyectoDesarrolloServiciosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository
{
    /*en ves de usar lo generico T usara la clase Producto*/
    public interface IProductoRepository : IRepository<Producto>
    {
        void Update(Producto producto);
    }
}




