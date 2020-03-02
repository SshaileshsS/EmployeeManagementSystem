using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee.Migrations
{
    public partial class photoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "EmployeeProps",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "EmployeeProps");
        }
    }
}
