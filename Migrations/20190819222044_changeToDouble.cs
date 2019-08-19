using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Migrations
{
    public partial class changeToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AvgRating",
                table: "destinations",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AvgRating",
                table: "destinations",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
