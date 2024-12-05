using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderDataAndSeedWorkers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Orders",
                newName: "IsFinished");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Procedures",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Procedure name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Animal name");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date of order creation.");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Dr. Alan Jakson is a skilled veterinarian with years of training and experience in animal wellness, dedicated to making every pet feel their best at our Animal Studio.", "/img/workers/Alan_Jakson.jpg", "Alan Jakson" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "With a strong background in animal care, Dr. Ana Lucia combines expertise and compassion to offer top-tier treatments at our Animal Studio.", "/img/workers/Ana_Lucia.jpg", "Ana Lucia" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Dr. Ben White, an experienced veterinarian, brings a wealth of knowledge and hands-on experience to our Animal Studio, ensuring the utmost comfort and healing for every pet.", "/img/workers/Ben_White.jpg", "Ben White" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Passionate about animal health, Dr. Debora Browning is an expert with extensive training who ensures that each visit to our Animal Studio is a soothing and therapeutic experience.", "/img/workers/Debora_Browning.jpg", "Debora Browning" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "As a dedicated professional, Dr. Dru Bening provides expert veterinary care with years of practice and a deep understanding of animal needs at our Animal Studio.", "/img/workers/Dru_Bening.jpg", "Dru Bening" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Dr. Haris Young combines years of veterinary training and real-world experience to deliver exceptional care, making pets feel cared for and pampered.", "/img/workers/Haris_Young.jpg", "Haris Young" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "With a rich background in animal health and well-being, Dr. Jake Nikson brings skill and dedication to every treatment at our Animal Studio.", "/img/workers/Jake_Nikson.jpg", "Jake Nikson" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Dr. Kate Smith is a committed veterinarian whose extensive experience ensures pets receive the highest standard of care and comfort during every visit.", "/img/workers/Kate_Smith.jpg", "Kate Smith" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "A veterinarian with years of hands-on experience, Dr. Lili Palmer offers tailored treatments that prioritize each pet’s comfort and health at our Animal Studio", "/img/workers/Lili_Palmer.jpg", "Lili Palmer" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Dr. Rahit Mazin is an experienced veterinary professional who pairs his/her vast training with a love for animals, creating a welcoming and healing environment at our Animal Studio.", "/img/workers/Rahit_Mazin.jpg", "Rahit Mazin" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Name" },
                values: new object[] { "With significant training and a deep understanding of animal wellness, Dr. Stefan_Duglas delivers expert care and treatments that make every pet feel their best.", "Stefan Duglas" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "IsFinished",
                table: "Orders",
                newName: "IsDeleted");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Procedures",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Animal name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Procedure name");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "", "/img/workers/Donald-Trump.jpg", "Donald Trump" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "", "/img/workers/Vladimir-Putin.jpg", "Vladimir Putin" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "", "/img/workers/Xi_Jinping.jpg", "Xi Jinping" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "", "/img/workers/Narendra-Modi.jpg", "Narendra Modi" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "", "/img/workers/Boiko-Borisov.jpg", "Boiko Borisov" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "", "/img/workers/Boris-Johnson.jpg", "Boris Johnson" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "", "/img/workers/Eva-Mendes.jpg", "Eva Mendes" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "", "/img/workers/Josh-Holloway.jpg", "Josh Holloway" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "", "/img/workers/Natasha-Moneva.jpg", "Natasha Moneva" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "", "/img/workers/Deborah-De-Luca.jpg", "Deborah De Luca" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "Jennifer Lopez" });
        }
    }
}
