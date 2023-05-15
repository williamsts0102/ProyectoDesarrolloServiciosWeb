using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoDesarrolloServiciosWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToDbAndSeed : Migration
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

            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "idCategoria", "DisplayOrder", "nombre" },
                values: new object[,]
                {
                    { 1, 1, "Hamburguesas" },
                    { 2, 2, "Pizas" },
                    { 3, 3, "Papas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
