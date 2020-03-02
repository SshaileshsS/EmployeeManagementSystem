using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee.Migrations
{
    public partial class SeedDataEmployeeProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EmployeeProps",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "EmployeeProps",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 1, 1, "shailesh@gmail.com", "shailesh" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeProps",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EmployeeProps",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
