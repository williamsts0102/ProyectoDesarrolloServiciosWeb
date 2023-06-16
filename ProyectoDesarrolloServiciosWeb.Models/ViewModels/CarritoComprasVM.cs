using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloServiciosWeb.Models.ViewModels
{
    public class CarritoComprasVM
    {
        public IEnumerable<CarritoCompras> carritoList { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
