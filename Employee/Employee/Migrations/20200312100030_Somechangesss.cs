using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee.Migrations
{
    public partial class Somechangesss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMPId",
                table: "EMPLeaves");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EMPId",
                table: "EMPLeaves",
                nullable: false,
                defaultValue: 0);
        }
    }
}
