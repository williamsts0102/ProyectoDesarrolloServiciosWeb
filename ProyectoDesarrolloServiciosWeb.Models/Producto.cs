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
    public class Producto
    {
        /*clave primaria de la entidad Categoria, Entity Framework lo utilizará para generar la 
         sentencia Sql, indicando que la columna id es la llave primaria*/
        [Key]
        public int idProducto { get; set; }

        /*campo requerido*/
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [MaxLength(38)]
        [DisplayName("Nombre de Producto")]
        public string? nombreProducto { get; set; }


        [Required(ErrorMessage = "La descripción es obligatoria")]
        [DisplayName("Descripción de Producto")]
        public string? descripcion { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio")]
        [DisplayName("Precio del Producto")]
        public double precio { get; set; }


        [Required(ErrorMessage = "La categoría es obligatoria")]
        [DisplayName("Categoría")]
        public int categoriaId { get; set; }
        [ForeignKey("categoriaId")]
        [ValidateNever]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "La imágen es obligatoria")]
        [DisplayName("Imágen")]
        [ValidateNever]
        public string ImageUrl { get; set; }


    }
}
