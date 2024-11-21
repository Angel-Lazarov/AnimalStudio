using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrdersAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AnimalsProcedures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AnimalsProcedures");
        }
    }
}
