using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimalStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedWorkersProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkersProcedures",
                columns: new[] { "ProcedureId", "WorkerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 2, 3 },
                    { 2, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkersProcedures",
                keyColumns: new[] { "ProcedureId", "WorkerId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "WorkersProcedures",
                keyColumns: new[] { "ProcedureId", "WorkerId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "WorkersProcedures",
                keyColumns: new[] { "ProcedureId", "WorkerId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "WorkersProcedures",
                keyColumns: new[] { "ProcedureId", "WorkerId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "WorkersProcedures",
                keyColumns: new[] { "ProcedureId", "WorkerId" },
                keyValues: new object[] { 2, 4 });
        }
    }
}
