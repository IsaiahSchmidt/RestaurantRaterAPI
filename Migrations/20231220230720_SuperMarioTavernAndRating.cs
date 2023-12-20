using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantRaterAPI.Migrations
{
    /// <inheritdoc />
    public partial class SuperMarioTavernAndRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 1, "1Up Lane", "Super Mario Pasta Cavern" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "CleanlinessScore", "EnvironmentScore", "FoodScore", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 10.0, 8.8000000000000007, 7.5, 1 },
                    { 2, 10.0, 10.0, 8.0, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
