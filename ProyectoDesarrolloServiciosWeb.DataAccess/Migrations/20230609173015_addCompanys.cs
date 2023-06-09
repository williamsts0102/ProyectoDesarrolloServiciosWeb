using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoDesarrolloServiciosWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addCompanys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "company",
                columns: new[] { "Id", "Ciudad", "CodigoPostal", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Los Olivos", "52", "Jron Los Bajos", "Tres Ositos", "965214215" },
                    { 2, "Los Olivos", "52", "Jron Los Bajos", "Tres Ositos", "965214215" },
                    { 3, "Los Olivos", "52", "Jron Los Bajos", "Tres Ositos", "965214215" },
                    { 4, "Los Olivos", "52", "Jron Los Bajos", "Tres Ositos", "965214215" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "company",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "company",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "company",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "company",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
