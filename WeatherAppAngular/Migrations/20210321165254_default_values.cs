using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherAppAngular.Migrations
{
    public partial class default_values : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Buenos Aires" },
                    { 2, "Tigre" },
                    { 3, "La Plata" },
                    { 4, "Rosario" },
                    { 5, "Córdoba" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "ApiCode", "Name" },
                values: new object[] { 1, "AR", "Argentina" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
