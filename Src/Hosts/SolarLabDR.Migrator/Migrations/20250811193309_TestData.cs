using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SolarLabDR.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class TestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Date", "Email", "LastName", "Name" },
                values: new object[,]
                {
                    { new Guid("0198888d-6478-7548-848b-d5726a2dccc4"), new DateTime(2005, 8, 20, 0, 0, 0, 0, DateTimeKind.Utc), "bukin@mail.ru", "Букин", "Вася" },
                    { new Guid("01988eaa-649d-7ee3-b8ce-0291de8587be"), new DateTime(2001, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "slavko@mail.ru", "Славко", "Валерий" },
                    { new Guid("019898fb-da44-7018-879c-b0826773613a"), new DateTime(1981, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), "testhendler@mail.ru", "Корочаев", "Петр" },
                    { new Guid("0198990c-b2ff-711e-b008-135e3cdae65d"), new DateTime(2003, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), "asin@mail.ru", "Бякина", "Ася" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("0198888d-6478-7548-848b-d5726a2dccc4"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("01988eaa-649d-7ee3-b8ce-0291de8587be"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("019898fb-da44-7018-879c-b0826773613a"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("0198990c-b2ff-711e-b008-135e3cdae65d"));
        }
    }
}
