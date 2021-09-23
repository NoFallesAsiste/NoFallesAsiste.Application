using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoFallesAsiste.Application.Data.Migrations
{
    public partial class renameIdsClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ficha_Programa_ProgramId",
                table: "Ficha");

            migrationBuilder.DropTable(
                name: "Programa");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ficha",
                newName: "FichaId");

            migrationBuilder.CreateTable(
                name: "Program",
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
                    table.PrimaryKey("PK_Program", x => x.ProgramsId);
                });

            migrationBuilder.UpdateData(
                table: "Ficha",
                keyColumn: "FichaId",
                keyValue: 1,
                columns: new[] { "EndTraining", "StartPractice", "StartTraining" },
                values: new object[] { new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Ficha",
                keyColumn: "FichaId",
                keyValue: 2,
                columns: new[] { "EndTraining", "StartPractice", "StartTraining" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Program",
                columns: new[] { "ProgramsId", "Description", "Name", "TypeProgramId", "Version" },
                values: new object[,]
                {
                    { 1, "Programa para el estudio del ciclo de vida del software y su desarrollo", "Analisis y Desarrollo de sistemas de informacion", 1, 1.0 },
                    { 2, "Programa para el estudio del ciclo de vida del software y su desarrollo", "Analisis y Desarrollo de software", 1, 2.0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Ficha_Program_ProgramId",
                table: "Ficha",
                column: "ProgramId",
                principalTable: "Program",
                principalColumn: "ProgramsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ficha_Program_ProgramId",
                table: "Ficha");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.RenameColumn(
                name: "FichaId",
                table: "Ficha",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Programa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TypeProgramId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programa", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Ficha",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTraining", "StartPractice", "StartTraining" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Ficha",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTraining", "StartPractice", "StartTraining" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Description", "Name", "TypeProgramId", "Version" },
                values: new object[,]
                {
                    { 1, "Programa para el estudio del ciclo de vida del software y su desarrollo", "Analísis y Desarrollo de sistemas de información", 1, 1.0 },
                    { 2, "Programa para el estudio del ciclo de vida del software y su desarrollo", "Analísis y Desarrollo de software", 1, 2.0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Ficha_Programa_ProgramId",
                table: "Ficha",
                column: "ProgramId",
                principalTable: "Programa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
