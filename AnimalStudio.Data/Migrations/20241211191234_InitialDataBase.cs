using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimalStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataBase : Migration
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
                    AnimalTypeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Type of the animal"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false, comment: "Description for the worker"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypes", x => x.Id);
                },
                comment: "An AnimalType entity");

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

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Procedure Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Procedure name"),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false, comment: "Description of the procedure"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Procedure Price"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.Id);
                },
                comment: "Procedure entity.");

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "worker Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Worker name"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false, comment: "Description for the worker")
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Animal Identifier"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "The name of the animal"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Age of the animal"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, comment: "Identifier of the owner of the order"),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the animal in the order"),
                    ProcedureId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the procedure in the order"),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of order creation."),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Order Price")
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

            migrationBuilder.InsertData(
                table: "AnimalTypes",
                columns: new[] { "Id", "AnimalTypeName", "Description", "ImageUrl", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "Cat", "A cat is a curious, independent creature with a knack for napping, playing, and purring. They may act aloof, but their playful antics and soft purrs melt hearts!", "/img/animal-types/cat.jpg", false },
                    { 2, "Dog", "A dog is a loyal, loving companion with a wagging tail and a heart full of joy. They’re always ready for a walk, a game, or a cuddle, making them the perfect best friend.", "/img/animal-types/dog.jpg", false },
                    { 3, "Sheep", "A sheep is a fluffy, four-legged ball of wool that loves to graze and baa. They may be quiet and laid-back, but they’ve got a whole flock of personality – and don’t forget their signature “baaa”!", "/img/animal-types/sheep.jpg", false },
                    { 4, "Duck", "A duck is a quacking, waddling expert in water and land. With their silly little feet and charming fluff, they’re always ready for a splash and a good time!", "/img/animal-types/duck.jpg", false },
                    { 5, "Parrot", "A parrot is a colorful, talkative bird with a personality as bright as its feathers. With a love for mimicry and a flair for the dramatic, they can turn any moment into a lively performance!", "/img/animal-types/parrot.jpg", false },
                    { 6, "Snake", "A snake is a sleek, slithering creature with a mysterious charm. With no legs but plenty of style, they glide through life with a smoothness that’s hard to match – and a hiss that keeps you on your toes!", "/img/animal-types/snake.jpg", false },
                    { 7, "Lizard", "A lizard is a small, scaly explorer with a cool, laid-back attitude. Whether they’re basking in the sun or darting around like tiny ninjas, they always bring a touch of reptilian charm.", "/img/animal-types/lizard.jpg", false },
                    { 8, "Guinea Pig", "A guinea pig is a small, friendly rodent that loves to squeak, snack on veggies, and cuddle. Despite its name, it’s not from the sea and isn’t a pig – it’s a fluffy bundle of joy!", "/img/animal-types/guineapig.png", false }
                });

            migrationBuilder.InsertData(
                table: "Procedures",
                columns: new[] { "Id", "Description", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Trimming or styling an animal's fur to maintain hygiene, comfort, and appearance.", false, "HairCut", 20.56m },
                    { 2, "Administering a vaccine to protect the animal from diseases and strengthen its immune system.", false, "Vaccination", 45.62m },
                    { 3, "A thorough wash of the animal using suitable shampoos, followed by rinsing and drying to ensure cleanliness and a healthy coat.", false, "Full Bath", 10.23m },
                    { 4, "A health check-up performed by a veterinarian to assess the animal’s overall condition and identify any potential medical issues.", false, "Medicine Exam", 12.50m },
                    { 5, "Removal of fleas, ticks, and other parasites", false, "External deworming", 55.86m },
                    { 6, "Cleaning around the eyes to remove tear stains, discharge, and debris, ensuring comfort and preventing infections.", false, "Eye care", 35.50m },
                    { 7, "A specialized grooming process to remove loose undercoat and reduce shedding, keeping the animal’s coat healthy and manageable.", false, "De-shedding treatment", 57.90m },
                    { 8, "The process of carefully cutting or filing the nails of animals to prevent overgrowth, injury, and discomfort.", false, "Nail trimming", 75.43m },
                    { 9, "A procedure where the animal's teeth are cleaned to remove plaque, tartar, and debris, helping to prevent dental disease and maintain oral health.", false, "Teeth cleaning", 155.40m },
                    { 10, "The process of gently cleaning the animal’s ears to remove dirt, wax, and debris, preventing infections and discomfort.", false, "Ear cleaning", 19.56m }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Description", "ImageUrl", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "Dr. Alan Jakson is a skilled veterinarian with years of training and experience in animal wellness, dedicated to making every pet feel their best at our Animal Studio.", "/img/workers/Alan_Jakson.jpg", false, "Alan Jakson" },
                    { 2, "With a strong background in animal care, Dr. Ana Lucia combines expertise and compassion to offer top-tier treatments at our Animal Studio.", "/img/workers/Ana_Lucia.jpg", false, "Ana Lucia" },
                    { 3, "Dr. Ben White, an experienced veterinarian, brings a wealth of knowledge and hands-on experience to our Animal Studio, ensuring the utmost comfort and healing for every pet.", "/img/workers/Ben_White.jpg", false, "Ben White" },
                    { 4, "Passionate about animal health, Dr. Debora Browning is an expert with extensive training who ensures that each visit to our Animal Studio is a soothing and therapeutic experience.", "/img/workers/Debora_Browning.jpg", false, "Debora Browning" },
                    { 5, "As a dedicated professional, Dr. Dru Bening provides expert veterinary care with years of practice and a deep understanding of animal needs at our Animal Studio.", "/img/workers/Dru_Bening.jpg", false, "Dru Bening" },
                    { 6, "Dr. Haris Young combines years of veterinary training and real-world experience to deliver exceptional care, making pets feel cared for and pampered.", "/img/workers/Haris_Young.jpg", false, "Haris Young" },
                    { 7, "With a rich background in animal health and well-being, Dr. Jake Nikson brings skill and dedication to every treatment at our Animal Studio.", "/img/workers/Jake_Nikson.jpg", false, "Jake Nikson" },
                    { 8, "Dr. Kate Smith is a committed veterinarian whose extensive experience ensures pets receive the highest standard of care and comfort during every visit.", "/img/workers/Kate_Smith.jpg", false, "Kate Smith" },
                    { 9, "A veterinarian with years of hands-on experience, Dr. Lili Palmer offers tailored treatments that prioritize each pet’s comfort and health at our Animal Studio", "/img/workers/Lili_Palmer.jpg", false, "Lili Palmer" },
                    { 10, "Dr. Rahit Mazin is an experienced veterinary professional who pairs his/her vast training with a love for animals, creating a welcoming and healing environment at our Animal Studio.", "/img/workers/Rahit_Mazin.jpg", false, "Rahit Mazin" },
                    { 11, "With significant training and a deep understanding of animal wellness, Dr. Stefan_Duglas delivers expert care and treatments that make every pet feel their best.", "", false, "Stefan Duglas" }
                });

            migrationBuilder.InsertData(
                table: "WorkersProcedures",
                columns: new[] { "ProcedureId", "WorkerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 1, 3 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 10, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AnimalTypeId",
                table: "Animals",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_OwnerId",
                table: "Animals",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserId",
                table: "Managers",
                column: "UserId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_WorkersProcedures_ProcedureId",
                table: "WorkersProcedures",
                column: "ProcedureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "WorkersProcedures");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "AnimalTypes");
        }
    }
}
