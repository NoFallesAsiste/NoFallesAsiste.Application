using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoFallesAsiste.WebApp.Data.Migrations
{
    public partial class initialMigrationDb : Migration
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
                name: "Programs",
                columns: table => new
                {
                    ProgramsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Version = table.Column<double>(type: "float", nullable: false),
                    TypeProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.ProgramsId);
                });

            migrationBuilder.CreateTable(
                name: "Ficha",
                columns: table => new
                {
                    FichaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTraining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTraining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartPractice = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraryId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    ProgramsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ficha", x => x.FichaId);
                    table.ForeignKey(
                        name: "FK_Ficha_Programs_ProgramsId",
                        column: x => x.ProgramsId,
                        principalTable: "Programs",
                        principalColumn: "ProgramsId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        principalColumn: "FichaId",
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
                        principalColumn: "FichaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ficha",
                columns: new[] { "FichaId", "EndTraining", "HoraryId", "ProgramId", "ProgramsId", "StartPractice", "StartTraining" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, null, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramsId", "Description", "Name", "TypeProgramId", "Version" },
                values: new object[,]
                {
                    { 1, "Programss para el estudio del ciclo de vida del software y su desarrollo", "Analisis y Desarrollo de sistemas de informacion", 1, 1.0 },
                    { 2, "Programss para el estudio del ciclo de vida del software y su desarrollo", "Analisis y Desarrollo de software", 1, 2.0 }
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "ClassId", "ClassRoom", "ClassStartDateTime", "Description", "FichaId", "Name" },
                values: new object[] { 1, "Meet", new DateTime(2021, 9, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), "Manejo de framework Entity de .net", 1, "Programssción profunda" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Ficha_ProgramsId",
                table: "Ficha",
                column: "ProgramsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedFicha");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Ficha");

            migrationBuilder.DropTable(
                name: "Programs");

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
