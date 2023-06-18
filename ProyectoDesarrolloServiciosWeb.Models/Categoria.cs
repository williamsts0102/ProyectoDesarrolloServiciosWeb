using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDesarrolloServiciosWeb.Models
{
    public class Categoria
    {
        /*clave primaria de la entidad Categoria, Entity Framework lo utilizará para generar la 
         sentencia Sql, indicando que la columna id es la llave primaria*/
        [Key]
        public int idCategoria { get; set; }

        /*campo requerido*/
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [MaxLength(38)]
        [DisplayName("Nombre de Categoría")]
        public string nombre { get; set; }

        /*para mostrar el orden en que se mostraran los campos*/
        [Required(ErrorMessage = "El orden de visualización es obligatorio")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo se permiten números en el orden de visualización")]
        [Range(1, 100, ErrorMessage = "El orden de visualización debe estar en un rango del 1 al 100")]
        [DisplayName("Orden de Visualización")]
        public int DisplayOrder { get; set; }
    }
}
