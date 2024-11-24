using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AnimalTypesAndWorkersImagesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AnimalTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/img/animal-types/cat.jpg");

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/img/animal-types/dog.jpg");

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/img/animal-types/sheep.jpg");

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/img/animal-types/duck.jpg");

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/img/animal-types/parrot.jpg");

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/img/animal-types/snake.jpg");

            migrationBuilder.UpdateData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/img/animal-types/lizard.jpg");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/img/workers/Donald-Trump.jpg", "Donald Trump" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/img/workers/Vladimir-Putin.jpg", "Vladimir Putin" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/img/workers/Xi_Jinping.jpg", "Xi Jinping" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/img/workers/Narendra-Modi.jpg", "Narendra Modi" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/img/workers/Boiko-Borisov.jpg", "Boiko Borisov" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/img/workers/Boris-Johnson.jpg", "Boris Johnson" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/img/workers/Eva-Mendes.jpg", "Eva Mendes" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/img/workers/Josh-Holloway.jpg", "Josh Holloway" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/img/workers/Natasha-Moneva.jpg", "Natasha Moneva" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/img/workers/Deborah-De-Luca.jpg", "Deborah De Luca" });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 11, "", "Jennifer Lopez" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AnimalTypes");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "John Doe");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Jane Smith");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Alex Johnson");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Emily Davis");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Michael Brown");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Sarah Wilson");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "David Lee");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Laura Garcia");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Chris Martin");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Anna Thompson");
        }
    }
}
