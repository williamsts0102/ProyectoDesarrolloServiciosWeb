using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoDesarrolloServiciosWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoriaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "idCategoria",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "idCategoria",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "idCategoria",
                keyValue: 3);
        }
    }
}
