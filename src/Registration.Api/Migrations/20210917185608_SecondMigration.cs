using Microsoft.EntityFrameworkCore.Migrations;

namespace Registration.Api.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "UserRegistration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "UserRegistration",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
