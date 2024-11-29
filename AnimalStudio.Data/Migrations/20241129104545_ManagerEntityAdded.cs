using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class ManagerEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A cat is a curious, independent creature with a knack for napping, playing, and purring. They may act aloof, but their playful antics and soft purrs melt hearts!");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserId",
                table: "Managers",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A cat is a curious, independent creature with a knack for napping, playing, and purring. They may act aloof, but their playful antics and soft purrs melt hearts.");
        }
    }
}
