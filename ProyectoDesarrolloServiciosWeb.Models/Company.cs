using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ProyectoDesarrolloServiciosWeb.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es obligatorio")]
        [DisplayName("Empresa")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "La dirección de la empresa es obligatoria")]
        [DisplayName("Nombre de Producto")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "La ciudad de la empresa es obligatoria")]
        [DisplayName("Ciudad")]
        public string? Ciudad { get; set; }
        [Required(ErrorMessage = "El código postal es obligatorio")]
        [DisplayName("Código Postal")]
        public string? CodigoPostal{ get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [DisplayName("Teléfono")]
        public string? Telefono { get; set; }

    }
}
