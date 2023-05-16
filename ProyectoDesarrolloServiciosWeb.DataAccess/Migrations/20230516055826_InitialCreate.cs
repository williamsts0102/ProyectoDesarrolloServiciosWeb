using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoDesarrolloServiciosWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(38)", maxLength: 38, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreProducto = table.Column<string>(type: "nvarchar(38)", maxLength: 38, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<double>(type: "float", nullable: false),
                    categoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.idProducto);
                    table.ForeignKey(
                        name: "FK_producto_categorias_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "categorias",
                        principalColumn: "idCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "idCategoria", "DisplayOrder", "nombre" },
                values: new object[,]
                {
                    { 1, 1, "Hamburguesas" },
                    { 2, 2, "Pizas" },
                    { 3, 3, "Papas" }
                });

            migrationBuilder.InsertData(
                table: "producto",
                columns: new[] { "idProducto", "categoriaId", "descripcion", "nombreProducto", "precio" },
                values: new object[,]
                {
                    { 1, 1, "Deliciosas hamburguesas con papas", "Hamburguesas", 50.0 },
                    { 2, 1, "Deliciosas hamburguesas con papas", "Hamburguesas", 50.0 },
                    { 3, 1, "Deliciosas hamburguesas con papas", "Hamburguesas", 50.0 },
                    { 4, 1, "Deliciosas hamburguesas con papas", "Hamburguesas", 50.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_producto_categoriaId",
                table: "producto",
                column: "categoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
