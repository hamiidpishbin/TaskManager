using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddIsDeletedPropertToAllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Sprints_SprintId",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_Task_SprintId",
                table: "Tasks",
                newName: "IX_Tasks_SprintId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Sprints",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Issues",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "Tasks",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DailyTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TimeSpan = table.Column<TimeSpan>(type: "time", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyTasks_Tasks_TaskIdId",
                        column: x => x.TaskIdId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyTasks_TaskIdId",
                table: "DailyTasks",
                column: "TaskIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Sprints_SprintId",
                table: "Tasks",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Sprints_SprintId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "DailyTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_SprintId",
                table: "Task",
                newName: "IX_Task_SprintId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Task",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Sprints_SprintId",
                table: "Task",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
