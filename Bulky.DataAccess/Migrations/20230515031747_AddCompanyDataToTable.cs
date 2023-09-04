using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyDataToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNuber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Kolkata", "Trnsport", "666666666", "700001", "West Bengal", "Kolkata" },
                    { 2, "Kolkata", "Trnsport1", "77777777", "700001", "West Bengal", "Kolkata" },
                    { 3, "Kolkata", "Trnsport2", "88888888", "700001", "West Bengal", "Kolkata" },
                    { 4, "Kolkata", "Trnsport4", "999999999", "700001", "West Bengal", "Kolkata" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
