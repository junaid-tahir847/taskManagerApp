using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagerApp.Migrations
{
    public partial class PersonModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedPersonId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedPersonId",
                table: "Tasks",
                column: "AssignedPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tasks_AssignedPersonId",
                table: "Tasks",
                column: "AssignedPersonId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            //  onDelete: ReferentialAction.SetNull
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tasks_AssignedPersonId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AssignedPersonId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AssignedPersonId",
                table: "Tasks");
        }
    }
}
