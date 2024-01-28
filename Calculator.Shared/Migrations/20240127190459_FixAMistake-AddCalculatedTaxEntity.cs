using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calculator.Shared.Migrations
{
    /// <inheritdoc />
    public partial class FixAMistakeAddCalculatedTaxEntity : Migration
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

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3574), new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3590) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3599), new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3703), new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3705) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3709), new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3715), new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3716) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3724), new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3725) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3729), new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3731) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3735), new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3736) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3740), new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3741) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3747), new DateTime(2024, 1, 27, 22, 34, 57, 730, DateTimeKind.Local).AddTicks(3748) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatedTax");

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(485), new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(496) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(557), new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(558) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(561), new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(562) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(565), new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(566) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(569), new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(575), new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(576) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(579), new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(580) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(582), new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(583) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(586), new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(587) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(592), new DateTime(2024, 1, 26, 21, 46, 9, 92, DateTimeKind.Local).AddTicks(593) });
        }
    }
}
