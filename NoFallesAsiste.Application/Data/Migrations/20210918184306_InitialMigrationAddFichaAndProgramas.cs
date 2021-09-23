using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoFallesAsiste.Application.Data.Migrations
{
    public partial class InitialMigrationAddFichaAndProgramas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Version = table.Column<double>(type: "float", nullable: false),
                    TypeProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ficha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTraining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTraining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartPractice = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraryId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ficha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ficha_Programa_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Description", "Name", "TypeProgramId", "Version" },
                values: new object[] { 1, "Programa para el estudio del ciclo de vida del software y su desarrollo", "Analísis y Desarrollo de sistemas de información", 1, 1.0 });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Description", "Name", "TypeProgramId", "Version" },
                values: new object[] { 2, "Programa para el estudio del ciclo de vida del software y su desarrollo", "Analísis y Desarrollo de software", 1, 2.0 });

            migrationBuilder.InsertData(
                table: "Ficha",
                columns: new[] { "Id", "EndTraining", "HoraryId", "ProgramId", "StartPractice", "StartTraining" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Ficha",
                columns: new[] { "Id", "EndTraining", "HoraryId", "ProgramId", "StartPractice", "StartTraining" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Ficha_ProgramId",
                table: "Ficha",
                column: "ProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ficha");

            migrationBuilder.DropTable(
                name: "Programa");
        }
    }
}
