using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class ispaidadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                schema: "Identity",
                table: "BillFlats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayTime",
                schema: "Identity",
                table: "BillFlats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PayUserId",
                schema: "Identity",
                table: "BillFlats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 197, DateTimeKind.Local).AddTicks(4324));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 197, DateTimeKind.Local).AddTicks(4346));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 197, DateTimeKind.Local).AddTicks(4348));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 197, DateTimeKind.Local).AddTicks(4350));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 197, DateTimeKind.Local).AddTicks(4352));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 197, DateTimeKind.Local).AddTicks(4356));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 191, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 195, DateTimeKind.Local).AddTicks(105));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 195, DateTimeKind.Local).AddTicks(126));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 195, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 195, DateTimeKind.Local).AddTicks(130));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 195, DateTimeKind.Local).AddTicks(132));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 195, DateTimeKind.Local).AddTicks(136));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 195, DateTimeKind.Local).AddTicks(137));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 195, DateTimeKind.Local).AddTicks(138));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 195, DateTimeKind.Local).AddTicks(140));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 194, DateTimeKind.Local).AddTicks(1224));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 194, DateTimeKind.Local).AddTicks(1261));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 194, DateTimeKind.Local).AddTicks(1264));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 6, 44, 18, 194, DateTimeKind.Local).AddTicks(1265));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                schema: "Identity",
                table: "BillFlats");

            migrationBuilder.DropColumn(
                name: "PayTime",
                schema: "Identity",
                table: "BillFlats");

            migrationBuilder.DropColumn(
                name: "PayUserId",
                schema: "Identity",
                table: "BillFlats");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 217, DateTimeKind.Local).AddTicks(1428));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 217, DateTimeKind.Local).AddTicks(1486));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 217, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 217, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 217, DateTimeKind.Local).AddTicks(1492));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 217, DateTimeKind.Local).AddTicks(1496));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 210, DateTimeKind.Local).AddTicks(3753));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 214, DateTimeKind.Local).AddTicks(2942));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 214, DateTimeKind.Local).AddTicks(2966));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 214, DateTimeKind.Local).AddTicks(2969));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 214, DateTimeKind.Local).AddTicks(2970));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 214, DateTimeKind.Local).AddTicks(2971));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 214, DateTimeKind.Local).AddTicks(2976));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 214, DateTimeKind.Local).AddTicks(2977));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 214, DateTimeKind.Local).AddTicks(2979));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 214, DateTimeKind.Local).AddTicks(2980));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 213, DateTimeKind.Local).AddTicks(4255));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 213, DateTimeKind.Local).AddTicks(4299));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 213, DateTimeKind.Local).AddTicks(4302));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 4, 45, 53, 213, DateTimeKind.Local).AddTicks(4304));
        }
    }
}
