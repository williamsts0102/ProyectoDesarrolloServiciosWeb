using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoDesarrolloServiciosWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addImagenUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "producto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "producto",
                keyColumn: "idProducto",
                keyValue: 1,
                columns: new[] { "ImageUrl", "descripcion", "precio" },
                values: new object[] { "", "Deliciosa combinación de carne jugosa, generalmente de res, cocinada a la parrilla o a la plancha", 15.0 });

            migrationBuilder.UpdateData(
                table: "producto",
                keyColumn: "idProducto",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "producto",
                keyColumn: "idProducto",
                keyValue: 3,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "producto",
                keyColumn: "idProducto",
                keyValue: 4,
                column: "ImageUrl",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "producto");

            migrationBuilder.UpdateData(
                table: "producto",
                keyColumn: "idProducto",
                keyValue: 1,
                columns: new[] { "descripcion", "precio" },
                values: new object[] { "Deliciosas hamburguesas con papas", 50.0 });
        }
    }
}
