using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RemoveExtraPropertiesFromSprint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfIssues",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "NumberOfTasks",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "TaskHoursSum",
                table: "Sprints");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfIssues",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTasks",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskHoursSum",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
