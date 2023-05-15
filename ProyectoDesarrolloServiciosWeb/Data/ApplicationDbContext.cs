using Microsoft.EntityFrameworkCore;
using ProyectoDesarrolloServiciosWeb.Models;

namespace ProyectoDesarrolloServiciosWeb.Data
{
    /*para decirle que la aplicacion usara EntityFrameworkCore,proporciona acceso y gestion 
     a una base de datos Entity..*/
    public class ApplicationDbContext : DbContext
    {
        /*constructor*/
        /*el constructor recibe un parametro options, este parametro recibe como debe establecerse
         la conexion a base de datos*/
        /*esto permite que esta clase interactue con la base de datos utilizando EntityFRamework*/
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base (options){
                
        }

        /*para definir una propiedad que representa una tabla en la base de datos*/
        public DbSet<Categoria> categorias { get; set; }

        /*agregar datos iniciales, estamos sobreescribiendo en la base de datos DBContext, de esta manera
         podemos personalizar como crear una nueva categoria*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { idCategoria = 1, nombre = "Hamburguesas", DisplayOrder = 1 },
                new Categoria { idCategoria = 2, nombre = "Pizas", DisplayOrder = 2 },
                new Categoria { idCategoria = 3, nombre = "Papas", DisplayOrder = 3 }
                );
        }

    }
}
