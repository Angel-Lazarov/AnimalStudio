using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWorkerProcedureToManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalProcedures_Animals_AnimalId",
                table: "AnimalProcedures");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimalProcedures_Procedures_ProcedureId",
                table: "AnimalProcedures");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Workers_WorkerId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_WorkerId",
                table: "Procedures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimalProcedures",
                table: "AnimalProcedures");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Procedures");

            migrationBuilder.RenameTable(
                name: "AnimalProcedures",
                newName: "AnimalsProcedures");

            migrationBuilder.RenameIndex(
                name: "IX_AnimalProcedures_ProcedureId",
                table: "AnimalsProcedures",
                newName: "IX_AnimalsProcedures_ProcedureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimalsProcedures",
                table: "AnimalsProcedures",
                columns: new[] { "AnimalId", "ProcedureId" });

            migrationBuilder.CreateTable(
                name: "WorkersProcedures",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkersProcedures", x => new { x.WorkerId, x.ProcedureId });
                    table.ForeignKey(
                        name: "FK_WorkersProcedures_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkersProcedures_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkersProcedures_ProcedureId",
                table: "WorkersProcedures",
                column: "ProcedureId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalsProcedures_Animals_AnimalId",
                table: "AnimalsProcedures",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalsProcedures_Procedures_ProcedureId",
                table: "AnimalsProcedures",
                column: "ProcedureId",
                principalTable: "Procedures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalsProcedures_Animals_AnimalId",
                table: "AnimalsProcedures");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimalsProcedures_Procedures_ProcedureId",
                table: "AnimalsProcedures");

            migrationBuilder.DropTable(
                name: "WorkersProcedures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimalsProcedures",
                table: "AnimalsProcedures");

            migrationBuilder.RenameTable(
                name: "AnimalsProcedures",
                newName: "AnimalProcedures");

            migrationBuilder.RenameIndex(
                name: "IX_AnimalsProcedures_ProcedureId",
                table: "AnimalProcedures",
                newName: "IX_AnimalProcedures_ProcedureId");

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Procedures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Worker Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimalProcedures",
                table: "AnimalProcedures",
                columns: new[] { "AnimalId", "ProcedureId" });

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 2,
                column: "WorkerId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 3,
                column: "WorkerId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 4,
                column: "WorkerId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_WorkerId",
                table: "Procedures",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalProcedures_Animals_AnimalId",
                table: "AnimalProcedures",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalProcedures_Procedures_ProcedureId",
                table: "AnimalProcedures",
                column: "ProcedureId",
                principalTable: "Procedures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Workers_WorkerId",
                table: "Procedures",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
