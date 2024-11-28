using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AnimalProcedureReplacedWithOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalsProcedures");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, comment: "The user who is owner of the animal"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "Id");
                },
                comment: "Order entity");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AnimalId",
                table: "Orders",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OwnerId",
                table: "Orders",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProcedureId",
                table: "Orders",
                column: "ProcedureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.CreateTable(
                name: "AnimalsProcedures",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalsProcedures", x => new { x.AnimalId, x.ProcedureId });
                    table.ForeignKey(
                        name: "FK_AnimalsProcedures_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimalsProcedures_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalsProcedures_ProcedureId",
                table: "AnimalsProcedures",
                column: "ProcedureId");
        }
    }
}
