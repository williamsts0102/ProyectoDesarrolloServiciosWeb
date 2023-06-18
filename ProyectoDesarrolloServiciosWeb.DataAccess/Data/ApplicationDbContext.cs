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

        /*crear la tabla carrito de compras*/
        public DbSet<CarritoCompras> carrito { get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetalle> OrderDetalles { get; set; }
        /*para definir a los usuarios*/
        public DbSet<ApplicationUser> applicationUser { get; set; }
        /*agregar datos iniciales, estamos sobreescribiendo en la base de datos DBContext, de esta manera
         podemos personalizar como crear una nueva categoria*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Company>().HasData(
              new Company
              {
                  Id = 1,
                  Nombre = "ABC Corporation",
                  Ciudad = "Ciudad A",
                  CodigoPostal = "12345",
                  Direccion = "Calle Principal 1",
                  Telefono = "123456789"
              },
               new Company
              {
                Id = 2,
                Nombre = "XYZ Industries",
                Ciudad = "Ciudad B",
                CodigoPostal = "54321",
                Direccion = "Avenida Central 2",
                Telefono = "987654321"
               },
                new Company
               {
                Id = 3,
                Nombre = "PQR Solutions",
                Ciudad = "Ciudad C",
                CodigoPostal = "67890",
                Direccion = "Plaza Mayor 3",
                Telefono = "456789123"
               },
                new Company
               {
                Id = 4,
                Nombre = "DEF Enterprises",
                Ciudad = "Ciudad D",
                CodigoPostal = "09876",
                Direccion = "Boulevard Secundario 4",
                Telefono = "321654987"
                },
               new Company
                {
                Id = 5,
                Nombre = "GHI Holdings",
                Ciudad = "Ciudad E",
                CodigoPostal = "13579",
                Direccion = "Calle Secundaria 5",
                Telefono = "159753852"
            },
            new Company
            {
                Id = 6,
                Nombre = "JKL Group",
                Ciudad = "Ciudad F",
                CodigoPostal = "97531",
                Direccion = "Avenida Principal 6",
                Telefono = "258369147"
            },
            new Company
            {
                Id = 7,
                Nombre = "MNO Incorporated",
                Ciudad = "Ciudad G",
                CodigoPostal = "75319",
                Direccion = "Plaza Central 7",
                Telefono = "741852963"
            },
            new Company
            {
                Id = 8,
                Nombre = "RST Ventures",
                Ciudad = "Ciudad H",
                CodigoPostal = "31975",
                Direccion = "Boulevard Principal 8",
                Telefono = "852963741"
            }
              );


            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { idCategoria = 1, nombre = "Hamburguesas", DisplayOrder = 1 },
                new Categoria { idCategoria = 2, nombre = "Pizzas", DisplayOrder = 2 },
                new Categoria { idCategoria = 3, nombre = "Papas fritas", DisplayOrder = 3 },
                new Categoria { idCategoria = 4, nombre = "Sandwiches", DisplayOrder = 4 },
                new Categoria { idCategoria = 5, nombre = "Ensaladas", DisplayOrder = 5 },
                new Categoria { idCategoria = 6, nombre = "Pollo frito", DisplayOrder = 6 },
                new Categoria { idCategoria = 7, nombre = "Hot dogs", DisplayOrder = 7 },
                new Categoria { idCategoria = 8, nombre = "Tacos", DisplayOrder = 8 },
                new Categoria { idCategoria = 9, nombre = "Postres", DisplayOrder = 9 }
                );

            
            modelBuilder.Entity<Producto>().HasData(

                new Producto
                {
                    idProducto = 101,
                    nombreProducto = "Cheeseburger",
                    descripcion = "Hamburguesa con queso, lechuga, tomate y salsa especial",
                    precio = 8.99,
                    categoriaId = 1,
                    ImageUrl=""
                },
                new Producto
                {
                    idProducto = 102,
                    nombreProducto = "Bacon Burger",
                    descripcion = "Hamburguesa con tocino, queso, cebolla y salsa barbacoa",
                    precio = 9.99,
                    categoriaId = 1,
                    ImageUrl = ""
                },
                new Producto
                {
                    idProducto = 103,
                    nombreProducto = "Pizza Margarita",
                    descripcion = "Pizza clásica con salsa de tomate, queso mozzarella y hojas de albahaca fresca",
                    precio = 18.99,
                    categoriaId = 2,
                    /*agregamos esto y luego una migracion addImage*/
                    ImageUrl = ""
                },
                new Producto
                {
                    idProducto = 104,
                    nombreProducto = "Pizza Pepperoni",
                    descripcion = "Pizza con salsa de tomate, queso mozzarella y pepperoni",
                    precio = 20.99,
                    categoriaId = 2,
                    ImageUrl = ""
                },
                new Producto
                {
                    idProducto = 105,
                    nombreProducto = "Pizza Hawaiana",
                    descripcion = "Pizza con salsa de tomate, queso mozzarella, jamón y piña",
                    precio = 23,
                    categoriaId = 2,
                    ImageUrl = ""
                },
                new Producto
                {
                    idProducto = 106,
                    nombreProducto = "Papas Fritas Clásicas",
                    descripcion = "Papas fritas tradicionales con sal y condimentos",
                    precio = 6,
                    categoriaId = 3,
                    ImageUrl = ""
                },
                new Producto
                {
                    idProducto = 107,
                    nombreProducto = "Papas Fritas con Queso",
                    descripcion = "Papas fritas cubiertas con queso derretido y salsa especial",
                    precio = 9,
                    categoriaId = 3,
                    ImageUrl = ""
                },
                new Producto
                {
                    idProducto = 108,
                    nombreProducto = "Piezas de Pollo",
                    descripcion = "Una pieza de pollo frito crujiente",
                    precio = 4.99,
                    categoriaId = 6,
                    ImageUrl = ""
                },
                new Producto
                {
                    idProducto = 109,
                    nombreProducto = "Tiras de Pollo",
                    descripcion = "Tiras de pollo rebozadas y fritas",
                    precio = 50,
                    categoriaId = 6,
                    ImageUrl = ""
                },
                new Producto
                {
                    idProducto = 110,
                    nombreProducto = "Taco de Carne Asada",
                    descripcion = "Taco relleno de carne asada, cebolla y cilantro",
                    precio = 18.99,
                    categoriaId = 8,
                    ImageUrl = ""
                },
                new Producto
                {
                    idProducto = 111,
                    nombreProducto = "Taco de Pollo",
                    descripcion = "Taco relleno de pollo desmenuzado, lechuga y queso",
                    precio = 15.99,
                    categoriaId = 8,
                    ImageUrl = ""
                }
                );
        }

    }
}
