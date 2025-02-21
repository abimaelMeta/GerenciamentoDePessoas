using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GerenciamentoDePessoas.Migrations
{
    /// <inheritdoc />
    public partial class Adicionando_Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d30246ad-09d2-4c45-bb57-0481ec5a124c", null, "operador", "OPERADOR" },
                    { "d9049725-594c-4c62-8c6b-9c36c2065395", null, "administrador", "ADMINISTRADOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d30246ad-09d2-4c45-bb57-0481ec5a124c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9049725-594c-4c62-8c6b-9c36c2065395");
        }
    }
}
