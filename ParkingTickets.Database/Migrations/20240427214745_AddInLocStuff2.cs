using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingTickets.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddInLocStuff2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationCategoryId",
                table: "Locations",
                column: "LocationCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Locations_LocationCategoryId",
                table: "Locations",
                column: "LocationCategoryId",
                principalTable: "Locations",
                principalColumn: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Locations_LocationCategoryId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_LocationCategoryId",
                table: "Locations");
        }
    }
}
