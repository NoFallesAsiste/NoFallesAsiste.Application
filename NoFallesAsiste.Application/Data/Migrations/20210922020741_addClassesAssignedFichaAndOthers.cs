using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoFallesAsiste.Application.Data.Migrations
{
    public partial class addClassesAssignedFichaAndOthers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssignedFicha",
                columns: table => new
                {
                    AssignedFichaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusAssignedFichaId = table.Column<int>(type: "int", nullable: false),
                    FichaId = table.Column<int>(type: "int", nullable: false),
                    AspNetUsersId = table.Column<int>(type: "int", nullable: false),
                    AspNetUsersId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedFicha", x => x.AssignedFichaId);
                    table.ForeignKey(
                        name: "FK_AssignedFicha_AspNetUsers_AspNetUsersId1",
                        column: x => x.AspNetUsersId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssignedFicha_Ficha_FichaId",
                        column: x => x.FichaId,
                        principalTable: "Ficha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassStartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassRoom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FichaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Class_Ficha_FichaId",
                        column: x => x.FichaId,
                        principalTable: "Ficha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "ClassId", "ClassRoom", "ClassStartDateTime", "Description", "FichaId", "Name" },
                values: new object[] { 1, "Meet", new DateTime(2021, 9, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), "Manejo de framework Entity de .net", 1, "Programación profunda" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "ClassId", "ClassRoom", "ClassStartDateTime", "Description", "FichaId", "Name" },
                values: new object[] { 2, "Meet", new DateTime(2021, 9, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), "Future with will", 1, "English 2" });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedFicha_AspNetUsersId1",
                table: "AssignedFicha",
                column: "AspNetUsersId1");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedFicha_FichaId",
                table: "AssignedFicha",
                column: "FichaId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_FichaId",
                table: "Class",
                column: "FichaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedFicha");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "AspNetUsers");
        }
    }
}
