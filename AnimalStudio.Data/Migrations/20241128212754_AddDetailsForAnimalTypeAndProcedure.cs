using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimalStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDetailsForAnimalTypeAndProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Workers",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                defaultValue: "",
                comment: "Description for the worker");

            migrationBuilder.AlterColumn<int>(
                name: "ProcedureId",
                table: "Orders",
                type: "int",
                nullable: false,
                comment: "Identifier of the procedure in the order",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Orders",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                comment: "Identifier of the owner of the order",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldComment: "The user who is owner of the animal");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Orders",
                type: "int",
                nullable: false,
                comment: "Identifier of the animal in the order",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AnimalTypes",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                defaultValue: "",
                comment: "Description for the worker");

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A cat is a curious, independent creature with a knack for napping, playing, and purring. They may act aloof, but their playful antics and soft purrs melt hearts.");

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "A dog is a loyal, loving companion with a wagging tail and a heart full of joy. They’re always ready for a walk, a game, or a cuddle, making them the perfect best friend.");

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "A sheep is a fluffy, four-legged ball of wool that loves to graze and baa. They may be quiet and laid-back, but they’ve got a whole flock of personality – and don’t forget their signature “baaa”!");

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "A duck is a quacking, waddling expert in water and land. With their silly little feet and charming fluff, they’re always ready for a splash and a good time!");

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "A parrot is a colorful, talkative bird with a personality as bright as its feathers. With a love for mimicry and a flair for the dramatic, they can turn any moment into a lively performance!");

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "A snake is a sleek, slithering creature with a mysterious charm. With no legs but plenty of style, they glide through life with a smoothness that’s hard to match – and a hiss that keeps you on your toes!");

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "A lizard is a small, scaly explorer with a cool, laid-back attitude. Whether they’re basking in the sun or darting around like tiny ninjas, they always bring a touch of reptilian charm.");

            migrationBuilder.InsertData(
                table: "AnimalTypes",
                columns: new[] { "Id", "AnimalTypeName", "Description", "ImageUrl" },
                values: new object[] { 8, "Guinea Pig", "A guinea pig is a small, friendly rodent that loves to squeak, snack on veggies, and cuddle. Despite its name, it’s not from the sea and isn’t a pig – it’s a fluffy bundle of joy!", "/img/animal-types/guineapig.png" });

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Trimming or styling an animal's fur to maintain hygiene, comfort, and appearance.");

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Administering a vaccine to protect the animal from diseases and strengthen its immune system.");

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "A thorough wash of the animal using suitable shampoos, followed by rinsing and drying to ensure cleanliness and a healthy coat.");

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "A health check-up performed by a veterinarian to assess the animal’s overall condition and identify any potential medical issues.");

            migrationBuilder.InsertData(
                table: "Procedures",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 5, "Removal of fleas, ticks, and other parasites", "External deworming", 55.86m },
                    { 6, "Cleaning around the eyes to remove tear stains, discharge, and debris, ensuring comfort and preventing infections.", "Eye care", 35.50m },
                    { 7, "A specialized grooming process to remove loose undercoat and reduce shedding, keeping the animal’s coat healthy and manageable.", "De-shedding treatment", 57.90m },
                    { 8, "The process of carefully cutting or filing the nails of animals to prevent overgrowth, injury, and discomfort.", "Nail trimming", 75.43m },
                    { 9, "A procedure where the animal's teeth are cleaned to remove plaque, tartar, and debris, helping to prevent dental disease and maintain oral health.", "Teeth cleaning", 155.40m },
                    { 10, "The process of gently cleaning the animal’s ears to remove dirt, wax, and debris, preventing infections and discomfort.", "Ear cleaning", 19.56m }
                });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AnimalTypes");

            migrationBuilder.AlterColumn<int>(
                name: "ProcedureId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of the procedure in the order");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Orders",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                comment: "The user who is owner of the animal",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldComment: "Identifier of the owner of the order");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier of the animal in the order");

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
    }
}
