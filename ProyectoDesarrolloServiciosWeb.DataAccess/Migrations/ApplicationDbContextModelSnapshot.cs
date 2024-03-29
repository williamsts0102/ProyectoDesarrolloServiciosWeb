﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoDesarrolloServiciosWeb.DataAccess.Data;

#nullable disable

namespace ProyectoDesarrolloServiciosWeb.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProyectoDesarrolloServiciosWeb.Models.CarritoCompras", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ProductoId");

                    b.ToTable("carrito");
                });

            modelBuilder.Entity("ProyectoDesarrolloServiciosWeb.Models.Categoria", b =>
                {
                    b.Property<int>("idCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCategoria"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(38)
                        .HasColumnType("nvarchar(38)");

                    b.HasKey("idCategoria");

                    b.ToTable("categorias");

                    b.HasData(
                        new
                        {
                            idCategoria = 1,
                            DisplayOrder = 1,
                            nombre = "Hamburguesas"
                        },
                        new
                        {
                            idCategoria = 2,
                            DisplayOrder = 2,
                            nombre = "Pizzas"
                        },
                        new
                        {
                            idCategoria = 3,
                            DisplayOrder = 3,
                            nombre = "Papas fritas"
                        },
                        new
                        {
                            idCategoria = 4,
                            DisplayOrder = 4,
                            nombre = "Sandwiches"
                        },
                        new
                        {
                            idCategoria = 5,
                            DisplayOrder = 5,
                            nombre = "Ensaladas"
                        },
                        new
                        {
                            idCategoria = 6,
                            DisplayOrder = 6,
                            nombre = "Pollo frito"
                        },
                        new
                        {
                            idCategoria = 7,
                            DisplayOrder = 7,
                            nombre = "Hot dogs"
                        },
                        new
                        {
                            idCategoria = 8,
                            DisplayOrder = 8,
                            nombre = "Tacos"
                        },
                        new
                        {
                            idCategoria = 9,
                            DisplayOrder = 9,
                            nombre = "Postres"
                        });
                });

            modelBuilder.Entity("ProyectoDesarrolloServiciosWeb.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("company");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ciudad = "Ciudad A",
                            CodigoPostal = "12345",
                            Direccion = "Calle Principal 1",
                            Nombre = "ABC Corporation",
                            Telefono = "123456789"
                        },
                        new
                        {
                            Id = 2,
                            Ciudad = "Ciudad B",
                            CodigoPostal = "54321",
                            Direccion = "Avenida Central 2",
                            Nombre = "XYZ Industries",
                            Telefono = "987654321"
                        },
                        new
                        {
                            Id = 3,
                            Ciudad = "Ciudad C",
                            CodigoPostal = "67890",
                            Direccion = "Plaza Mayor 3",
                            Nombre = "PQR Solutions",
                            Telefono = "456789123"
                        },
                        new
                        {
                            Id = 4,
                            Ciudad = "Ciudad D",
                            CodigoPostal = "09876",
                            Direccion = "Boulevard Secundario 4",
                            Nombre = "DEF Enterprises",
                            Telefono = "321654987"
                        },
                        new
                        {
                            Id = 5,
                            Ciudad = "Ciudad E",
                            CodigoPostal = "13579",
                            Direccion = "Calle Secundaria 5",
                            Nombre = "GHI Holdings",
                            Telefono = "159753852"
                        },
                        new
                        {
                            Id = 6,
                            Ciudad = "Ciudad F",
                            CodigoPostal = "97531",
                            Direccion = "Avenida Principal 6",
                            Nombre = "JKL Group",
                            Telefono = "258369147"
                        },
                        new
                        {
                            Id = 7,
                            Ciudad = "Ciudad G",
                            CodigoPostal = "75319",
                            Direccion = "Plaza Central 7",
                            Nombre = "MNO Incorporated",
                            Telefono = "741852963"
                        },
                        new
                        {
                            Id = 8,
                            Ciudad = "Ciudad H",
                            CodigoPostal = "31975",
                            Direccion = "Boulevard Principal 8",
                            Nombre = "RST Ventures",
                            Telefono = "852963741"
                        });
                });

            modelBuilder.Entity("ProyectoDesarrolloServiciosWeb.Models.OrderDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("OrderHeaderId")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderHeaderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetalles");
                });

            modelBuilder.Entity("ProyectoDesarrolloServiciosWeb.Models.OrderHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoPedido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEnvio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaOrden")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVencimientoPago")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPedido")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("OrderHeaders");
                });

            modelBuilder.Entity("ProyectoDesarrolloServiciosWeb.Models.Producto", b =>
                {
                    b.Property<int>("idProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idProducto"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("categoriaId")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreProducto")
                        .IsRequired()
                        .HasMaxLength(38)
                        .HasColumnType("nvarchar(38)");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.HasKey("idProducto");

                    b.HasIndex("categoriaId");

                    b.ToTable("producto");

                    b.HasData(
                        new
                        {
                            idProducto = 101,
                            ImageUrl = "",
                            categoriaId = 1,
                            descripcion = "Hamburguesa con queso, lechuga, tomate y salsa especial",
                            nombreProducto = "Cheeseburger",
                            precio = 8.9900000000000002
                        },
                        new
                        {
                            idProducto = 102,
                            ImageUrl = "",
                            categoriaId = 1,
                            descripcion = "Hamburguesa con tocino, queso, cebolla y salsa barbacoa",
                            nombreProducto = "Bacon Burger",
                            precio = 9.9900000000000002
                        },
                        new
                        {
                            idProducto = 103,
                            ImageUrl = "",
                            categoriaId = 2,
                            descripcion = "Pizza clásica con salsa de tomate, queso mozzarella y hojas de albahaca fresca",
                            nombreProducto = "Pizza Margarita",
                            precio = 18.989999999999998
                        },
                        new
                        {
                            idProducto = 104,
                            ImageUrl = "",
                            categoriaId = 2,
                            descripcion = "Pizza con salsa de tomate, queso mozzarella y pepperoni",
                            nombreProducto = "Pizza Pepperoni",
                            precio = 20.989999999999998
                        },
                        new
                        {
                            idProducto = 105,
                            ImageUrl = "",
                            categoriaId = 2,
                            descripcion = "Pizza con salsa de tomate, queso mozzarella, jamón y piña",
                            nombreProducto = "Pizza Hawaiana",
                            precio = 23.0
                        },
                        new
                        {
                            idProducto = 106,
                            ImageUrl = "",
                            categoriaId = 3,
                            descripcion = "Papas fritas tradicionales con sal y condimentos",
                            nombreProducto = "Papas Fritas Clásicas",
                            precio = 6.0
                        },
                        new
                        {
                            idProducto = 107,
                            ImageUrl = "",
                            categoriaId = 3,
                            descripcion = "Papas fritas cubiertas con queso derretido y salsa especial",
                            nombreProducto = "Papas Fritas con Queso",
                            precio = 9.0
                        },
                        new
                        {
                            idProducto = 108,
                            ImageUrl = "",
                            categoriaId = 6,
                            descripcion = "Una pieza de pollo frito crujiente",
                            nombreProducto = "Piezas de Pollo",
                            precio = 4.9900000000000002
                        },
                        new
                        {
                            idProducto = 109,
                            ImageUrl = "",
                            categoriaId = 6,
                            descripcion = "Tiras de pollo rebozadas y fritas",
                            nombreProducto = "Tiras de Pollo",
                            precio = 50.0
                        },
                        new
                        {
                            idProducto = 110,
                            ImageUrl = "",
                            categoriaId = 8,
                            descripcion = "Taco relleno de carne asada, cebolla y cilantro",
                            nombreProducto = "Taco de Carne Asada",
                            precio = 18.989999999999998
                        },
                        new
                        {
                            idProducto = 111,
                            ImageUrl = "",
                            categoriaId = 8,
                            descripcion = "Taco relleno de pollo desmenuzado, lechuga y queso",
                            nombreProducto = "Taco de Pollo",
                            precio = 15.99
                        });
                });

            modelBuilder.Entity("ProyectoDesarrolloServiciosWeb.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoPostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("CompanyId");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoDesarrolloServiciosWeb.Models.CarritoCompras", b =>
                {
                    b.HasOne("ProyectoDesarrolloServiciosWeb.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoDesarrolloServiciosWeb.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("ProyectoDesarrolloServiciosWeb.Models.OrderDetalle", b =>
                {
                    b.HasOne("ProyectoDesarrolloServiciosWeb.Models.OrderHeader", "OrderHeader")
                        .WithMany()
                        .HasForeignKey("OrderHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoDesarrolloServiciosWeb.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderHeader");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("ProyectoDesarrolloServiciosWeb.Models.OrderHeader", b =>
                {
                    b.HasOne("ProyectoDesarrolloServiciosWeb.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("ProyectoDesarrolloServiciosWeb.Models.Producto", b =>
                {
                    b.HasOne("ProyectoDesarrolloServiciosWeb.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("categoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ProyectoDesarrolloServiciosWeb.Models.ApplicationUser", b =>
                {
                    b.HasOne("ProyectoDesarrolloServiciosWeb.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}
