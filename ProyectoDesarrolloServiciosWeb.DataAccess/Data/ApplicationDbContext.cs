using ProyectoDesarrolloServiciosWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ProyectoDesarrolloServiciosWeb.DataAccess.Data
{
    /*para decirle que la aplicacion usara EntityFrameworkCore,proporciona acceso y gestion 
     a una base de datos Entity..*/
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        /*constructor*/
        /*el constructor recibe un parametro options, este parametro recibe como debe establecerse
         la conexion a base de datos*/
        /*esto permite que esta clase interactue con la base de datos utilizando EntityFRamework*/
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base (options){
              
        }

        /*para definir una propiedad que representa una tabla en la base de datos*/
        public DbSet<Categoria> categorias { get; set; }

        /*para definir una propiedad que representa una tabla en la base de datos*/
        public DbSet<Producto> producto { get; set; }

        public DbSet<Company> company { get; set; } 

        /*para definir a los usuarios*/
        public DbSet<ApplicationUser> applicationUser { get; set; }
        /*agregar datos iniciales, estamos sobreescribiendo en la base de datos DBContext, de esta manera
         podemos personalizar como crear una nueva categoria*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { idCategoria = 1, nombre = "Hamburguesas", DisplayOrder = 1 },
                new Categoria { idCategoria = 2, nombre = "Pizas", DisplayOrder = 2 },
                new Categoria { idCategoria = 3, nombre = "Papas", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Producto>().HasData(

                new Producto
                {
                    idProducto = 1,
                    nombreProducto = "Hamburguesas",
                    descripcion = "Deliciosa combinación de carne jugosa, generalmente de res, cocinada a la parrilla o a la plancha",
                    precio = 15,
                    categoriaId = 1,
                    ImageUrl=""
                },
                new Producto
                {
                    idProducto = 2,
                    nombreProducto = "Hamburguesas",
                    descripcion = "Deliciosas hamburguesas con papas",
                    precio = 50,
                    categoriaId = 1,
                    ImageUrl = ""
                },
                new Producto
                {
                    idProducto = 3,
                    nombreProducto = "Hamburguesas",
                    descripcion = "Deliciosas hamburguesas con papas",
                    precio = 50,
                    categoriaId = 1,
                    /*agregamos esto y luego una migracion addImage*/
                    ImageUrl = ""
                },
                new Producto
                {
                    idProducto = 4,
                    nombreProducto = "Hamburguesas",
                    descripcion = "Deliciosas hamburguesas con papas",
                    precio = 50,
                    categoriaId = 1,
                    ImageUrl = ""
                }
                );
        }

    }
}
