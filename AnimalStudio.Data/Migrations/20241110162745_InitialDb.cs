using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimalStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "AnimalType Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalTypeInfo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Type of the animal")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "worker Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Worker name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                },
                comment: "Worker entity.");

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Animal Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "The name of the animal"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Age of the animal"),
                    AnimalTypeId = table.Column<int>(type: "int", nullable: false, comment: "Animal type Id"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, comment: "The user who is owner of the animal")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_AnimalTypes_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "AnimalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "An animal entity");

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Procedure Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Animal name"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Procedure Price"),
                    WorkerId = table.Column<int>(type: "int", nullable: false, comment: "Worker Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Procedures_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Animal procedure description.");

            migrationBuilder.CreateTable(
                name: "AnimalProcedures",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalProcedures", x => new { x.AnimalId, x.ProcedureId });
                    table.ForeignKey(
                        name: "FK_AnimalProcedures_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimalProcedures_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AnimalTypes",
                columns: new[] { "Id", "AnimalTypeInfo" },
                values: new object[,]
                {
                    { 1, "Cat" },
                    { 2, "Dog" },
                    { 3, "Sheep" },
                    { 4, "Dog" },
                    { 5, "Parrot" },
                    { 6, "Snake" },
                    { 7, "Lizard" }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Smith" },
                    { 3, "Alex Johnson" },
                    { 4, "Emily Davis" },
                    { 5, "Michael Brown" },
                    { 6, "Sarah Wilson" },
                    { 7, "David Lee" },
                    { 8, "Laura Garcia" },
                    { 9, "Chris Martin" },
                    { 10, "Anna Thompson" }
                });

            migrationBuilder.InsertData(
                table: "Procedures",
                columns: new[] { "Id", "Name", "Price", "WorkerId" },
                values: new object[,]
                {
                    { 1, "HairCut", 20.56m, 1 },
                    { 2, "Vaccination", 45.62m, 2 },
                    { 3, "Full Bath", 10.23m, 4 },
                    { 4, "Medicine Exam", 12.50m, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalProcedures_ProcedureId",
                table: "AnimalProcedures",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AnimalTypeId",
                table: "Animals",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_OwnerId",
                table: "Animals",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_WorkerId",
                table: "Procedures",
                column: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalProcedures");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "AnimalTypes");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
