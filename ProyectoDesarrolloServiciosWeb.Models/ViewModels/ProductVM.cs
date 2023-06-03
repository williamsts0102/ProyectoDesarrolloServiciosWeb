using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoDesarrolloServiciosWeb.Models.ViewModels
{
    public class ProductVM
    { 
        public Producto producto { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> listacat { get; set; }
    }
}
