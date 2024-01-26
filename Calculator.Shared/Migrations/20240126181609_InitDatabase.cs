using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Calculator.Shared.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxRule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    { 1, "Gothenburg", "Sweden", new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(485), new DateTime(2013, 1, 10, 6, 29, 0, 0, DateTimeKind.Unspecified), "SEK", new DateTime(2013, 1, 10, 6, 0, 0, 0, DateTimeKind.Unspecified), 8m, new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(496) },
                    { 2, "Gothenburg", "Sweden", new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(557), new DateTime(2013, 1, 10, 6, 59, 0, 0, DateTimeKind.Unspecified), "SEK", new DateTime(2013, 1, 10, 6, 30, 0, 0, DateTimeKind.Unspecified), 13m, new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(558) },
                    { 3, "Gothenburg", "Sweden", new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(561), new DateTime(2013, 1, 10, 7, 59, 0, 0, DateTimeKind.Unspecified), "SEK", new DateTime(2013, 1, 10, 7, 0, 0, 0, DateTimeKind.Unspecified), 18m, new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(562) },
                    { 4, "Gothenburg", "Sweden", new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(565), new DateTime(2013, 1, 10, 8, 29, 0, 0, DateTimeKind.Unspecified), "SEK", new DateTime(2013, 1, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), 13m, new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(566) },
                    { 5, "Gothenburg", "Sweden", new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(569), new DateTime(2013, 1, 10, 14, 59, 0, 0, DateTimeKind.Unspecified), "SEK", new DateTime(2013, 1, 10, 8, 30, 0, 0, DateTimeKind.Unspecified), 8m, new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(570) },
                    { 6, "Gothenburg", "Sweden", new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(575), new DateTime(2013, 1, 10, 15, 29, 0, 0, DateTimeKind.Unspecified), "SEK", new DateTime(2013, 1, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 13m, new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(576) },
                    { 7, "Gothenburg", "Sweden", new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(579), new DateTime(2013, 1, 10, 16, 59, 0, 0, DateTimeKind.Unspecified), "SEK", new DateTime(2013, 1, 10, 15, 30, 0, 0, DateTimeKind.Unspecified), 18m, new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(580) },
                    { 8, "Gothenburg", "Sweden", new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(582), new DateTime(2013, 1, 10, 17, 59, 0, 0, DateTimeKind.Unspecified), "SEK", new DateTime(2013, 1, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), 13m, new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(583) },
                    { 9, "Gothenburg", "Sweden", new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(586), new DateTime(2013, 1, 10, 18, 29, 0, 0, DateTimeKind.Unspecified), "SEK", new DateTime(2013, 1, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), 8m, new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(587) },
                    { 10, "Gothenburg", "Sweden", new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(592), new DateTime(2013, 1, 10, 5, 59, 0, 0, DateTimeKind.Unspecified), "SEK", new DateTime(2013, 1, 10, 18, 30, 0, 0, DateTimeKind.Unspecified), 0m, new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(593) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxRule");
        }
    }
}
