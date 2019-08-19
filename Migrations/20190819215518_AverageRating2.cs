using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Migrations
{
    public partial class AverageRating2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_Destinations_DestinationId",
                table: "reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations");

            migrationBuilder.RenameTable(
                name: "Destinations",
                newName: "destinations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_destinations",
                table: "destinations",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_destinations_DestinationId",
                table: "reviews",
                column: "DestinationId",
                principalTable: "destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_destinations_DestinationId",
                table: "reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_destinations",
                table: "destinations");

            migrationBuilder.RenameTable(
                name: "destinations",
                newName: "Destinations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_Destinations_DestinationId",
                table: "reviews",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
