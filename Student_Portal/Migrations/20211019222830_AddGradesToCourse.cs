using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Portal.Migrations
{
    public partial class AddGradesToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Courses",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "creditRequirements",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "credits",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "creditRequirements",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "credits",
                table: "Courses");
        }
    }
}
