using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoFallesAsiste.Application.Data.Migrations
{
    public partial class addClassesAssignedFichaAndOther : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ficha",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTraining", "StartPractice", "StartTraining" },
                values: new object[] { new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Ficha",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTraining", "StartPractice", "StartTraining" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Programa",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Analisis y Desarrollo de sistemas de informacion");

            migrationBuilder.UpdateData(
                table: "Programa",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Analisis y Desarrollo de software");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Programa",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Analísis y Desarrollo de sistemas de información");

            migrationBuilder.UpdateData(
                table: "Programa",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Analísis y Desarrollo de software");
        }
    }
}
