using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calculator.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseRule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseRule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehicle = table.Column<int>(type: "int", nullable: true),
                    DayOfWeek = table.Column<int>(type: "int", nullable: true),
                    HolydayDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaveNotTax = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseRule", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(346), new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(361) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(373), new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(374) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(378), new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(379) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(385), new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(386) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(389), new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(391) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(398), new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(399) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(403), new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(404) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(407), new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(408) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(412), new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(413) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(418), new DateTime(2024, 1, 29, 12, 35, 1, 991, DateTimeKind.Local).AddTicks(419) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseRule");

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6406), new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6427) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6436), new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6437) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6441), new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6442) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6446), new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6447) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6450), new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6451) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6459), new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6591), new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6593) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6597), new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6598) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6601), new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6603) });

            migrationBuilder.UpdateData(
                table: "TaxRule",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6612), new DateTime(2024, 1, 28, 19, 22, 34, 231, DateTimeKind.Local).AddTicks(6613) });
        }
    }
}
