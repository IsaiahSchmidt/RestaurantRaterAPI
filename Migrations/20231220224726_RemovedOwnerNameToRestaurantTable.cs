using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantRaterAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemovedOwnerNameToRestaurantTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Restaurants",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Restaurants",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
