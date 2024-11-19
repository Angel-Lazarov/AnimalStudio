using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDuplicationsFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "AnimalTypeInfo",
                value: "Duck");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "AnimalTypeInfo",
                value: "Dog");
        }
    }
}
