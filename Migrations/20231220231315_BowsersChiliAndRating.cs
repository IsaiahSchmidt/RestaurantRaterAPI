using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantRaterAPI.Migrations
{
    /// <inheritdoc />
    public partial class BowsersChiliAndRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CleanlinessScore", "EnvironmentScore", "FoodScore" },
                values: new object[] { 9.9000000000000004, 9.8000000000000007, 8.5 });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 2, "123 GRRR CT", "Bowsers Hot Chili Shop" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "CleanlinessScore", "EnvironmentScore", "FoodScore", "RestaurantId" },
                values: new object[,]
                {
                    { 3, 10.0, 5.7999999999999998, 3.5, 2 },
                    { 4, 7.0, 6.7999999999999998, 6.5, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CleanlinessScore", "EnvironmentScore", "FoodScore" },
                values: new object[] { 10.0, 10.0, 8.0 });
        }
    }
}
