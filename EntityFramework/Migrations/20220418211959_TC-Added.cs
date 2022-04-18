using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class TCAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TC",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 0, 19, 58, 969, DateTimeKind.Local).AddTicks(9791));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 0, 19, 58, 975, DateTimeKind.Local).AddTicks(1334));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 0, 19, 58, 975, DateTimeKind.Local).AddTicks(1368));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 0, 19, 58, 975, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 0, 19, 58, 975, DateTimeKind.Local).AddTicks(1371));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 0, 19, 58, 975, DateTimeKind.Local).AddTicks(1373));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 0, 19, 58, 975, DateTimeKind.Local).AddTicks(1377));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 0, 19, 58, 975, DateTimeKind.Local).AddTicks(1378));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 0, 19, 58, 975, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 0, 19, 58, 975, DateTimeKind.Local).AddTicks(1381));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 0, 19, 58, 974, DateTimeKind.Local).AddTicks(1105));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 0, 19, 58, 974, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 0, 19, 58, 974, DateTimeKind.Local).AddTicks(1182));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 0, 19, 58, 974, DateTimeKind.Local).AddTicks(1183));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TC",
                schema: "Identity",
                table: "User");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 23, 9, 19, 666, DateTimeKind.Local).AddTicks(1550));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 23, 9, 19, 669, DateTimeKind.Local).AddTicks(7943));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 23, 9, 19, 669, DateTimeKind.Local).AddTicks(7964));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 23, 9, 19, 669, DateTimeKind.Local).AddTicks(7966));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 23, 9, 19, 669, DateTimeKind.Local).AddTicks(7968));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 23, 9, 19, 669, DateTimeKind.Local).AddTicks(7969));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 23, 9, 19, 669, DateTimeKind.Local).AddTicks(7973));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 23, 9, 19, 669, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 23, 9, 19, 669, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 23, 9, 19, 669, DateTimeKind.Local).AddTicks(7977));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 23, 9, 19, 668, DateTimeKind.Local).AddTicks(9549));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 23, 9, 19, 668, DateTimeKind.Local).AddTicks(9580));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 23, 9, 19, 668, DateTimeKind.Local).AddTicks(9582));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 23, 9, 19, 668, DateTimeKind.Local).AddTicks(9584));
        }
    }
}
