using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloServiciosWeb.Models
{
    public class CarritoCompras
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        [ValidateNever]
        public Producto Producto { get; set; }
        [Range(1, 1000, ErrorMessage = "Ingrese un valor entre 1 y 1000")]
        public int Cantidad { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
