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
        [Required(ErrorMessage = "El nombre de la categoria es obligatorio")]
        [MaxLength(38)]
        [DisplayName("Nombre de Categoria")]
        public string? nombre { get; set; }

        /*para mostrar el orden en que se mostraran los campos*/
        [DisplayName("Orden de Visualización")]
        [Range(1,100, ErrorMessage = "Orden de visualización tiene un rango del 1 al 100")]
        public int DisplayOrder { get; set; }
    }
}
