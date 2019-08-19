using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Migrations
{
    public partial class DestinationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_destinations_DestinationId",
                table: "reviews");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationId",
                table: "reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "DestinationId",
                table: "reviews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_destinations_DestinationId",
                table: "reviews",
                column: "DestinationId",
                principalTable: "destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
