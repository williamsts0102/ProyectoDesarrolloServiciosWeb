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
    public class OrderHeader
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime FechaOrden { get; set; }
        public DateTime FechaEnvio { get; set; }
        public double TotalPedido { get; set; }
        public string? EstadoPedido { get; set; }
        public string? EstadoPago { get; set; }

        public DateTime FechaPago { get; set; }
        public DateTime FechaVencimientoPago { get; set; }

        public string? SessionId { get; set; }
        public string? IdPago { get; set; }

        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        public string CodigoPostal { get; set; }
        [Required]
        public string Nombre { get; set; }

    }
}
