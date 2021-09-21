using Microsoft.EntityFrameworkCore.Migrations;

namespace NoFallesAsiste.Application.Data.Migrations
{
    public partial class changeNameClassProgramForPrograms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ficha_Program_ProgramId",
                table: "Ficha");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Program",
                table: "Program");

            migrationBuilder.RenameTable(
                name: "Program",
                newName: "Programs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programs",
                table: "Programs",
                column: "ProgramsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ficha_Programs_ProgramId",
                table: "Ficha",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "ProgramsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ficha_Programs_ProgramId",
                table: "Ficha");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Programs",
                table: "Programs");

            migrationBuilder.RenameTable(
                name: "Programs",
                newName: "Program");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Program",
                table: "Program",
                column: "ProgramsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ficha_Program_ProgramId",
                table: "Ficha",
                column: "ProgramId",
                principalTable: "Program",
                principalColumn: "ProgramsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
