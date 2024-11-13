using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProcedureDescriptionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Procedures",
                comment: "Procedure entity.",
                oldComment: "Animal procedure description.");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Procedures",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                defaultValue: "",
                comment: "Description of the procedure");

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Some description here");

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Some description here");

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Some description here");

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Some description here");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Procedures");

            migrationBuilder.AlterTable(
                name: "Procedures",
                comment: "Animal procedure description.",
                oldComment: "Procedure entity.");
        }
    }
}
