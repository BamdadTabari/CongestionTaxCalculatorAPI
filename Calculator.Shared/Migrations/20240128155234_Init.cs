using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Calculator.Shared.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculatedTax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonetaryUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountOfDay = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatedTax", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxRule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonetaryUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRule", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaxRule",
                columns: new[] { "Id", "City", "Country", "CreatedAt", "EndTime", "MonetaryUnit", "StartTime", "TaxAmount", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Gothenburg", "Sweden", new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6406), new TimeOnly(6, 29, 0), "SEK", new TimeOnly(6, 0, 0), 8m, new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6427) },
                    { 2, "Gothenburg", "Sweden", new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6436), new TimeOnly(6, 59, 0), "SEK", new TimeOnly(6, 30, 0), 13m, new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6437) },
                    { 3, "Gothenburg", "Sweden", new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6441), new TimeOnly(7, 59, 0), "SEK", new TimeOnly(7, 0, 0), 18m, new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6442) },
                    { 4, "Gothenburg", "Sweden", new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6446), new TimeOnly(8, 29, 0), "SEK", new TimeOnly(8, 0, 0), 13m, new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6447) },
                    { 5, "Gothenburg", "Sweden", new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6450), new TimeOnly(14, 59, 0), "SEK", new TimeOnly(8, 30, 0), 8m, new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6451) },
                    { 6, "Gothenburg", "Sweden", new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6459), new TimeOnly(15, 29, 0), "SEK", new TimeOnly(15, 0, 0), 13m, new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6460) },
                    { 7, "Gothenburg", "Sweden", new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6591), new TimeOnly(16, 59, 0), "SEK", new TimeOnly(15, 30, 0), 18m, new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6593) },
                    { 8, "Gothenburg", "Sweden", new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6597), new TimeOnly(17, 59, 0), "SEK", new TimeOnly(17, 0, 0), 13m, new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6598) },
                    { 9, "Gothenburg", "Sweden", new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6601), new TimeOnly(18, 29, 0), "SEK", new TimeOnly(18, 0, 0), 8m, new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6603) },
                    { 10, "Gothenburg", "Sweden", new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6612), new TimeOnly(5, 59, 0), "SEK", new TimeOnly(18, 30, 0), 0m, new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6613) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatedTax");

            migrationBuilder.DropTable(
                name: "TaxRule");
        }
    }
}
