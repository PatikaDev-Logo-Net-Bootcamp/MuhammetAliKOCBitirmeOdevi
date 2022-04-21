using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class Odemetakipicinsutunlareklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 40, DateTimeKind.Local).AddTicks(9306));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 40, DateTimeKind.Local).AddTicks(9340));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 40, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 40, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 40, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 40, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 33, DateTimeKind.Local).AddTicks(1850));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 38, DateTimeKind.Local).AddTicks(3503));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 38, DateTimeKind.Local).AddTicks(3527));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 38, DateTimeKind.Local).AddTicks(3529));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 38, DateTimeKind.Local).AddTicks(3531));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 38, DateTimeKind.Local).AddTicks(3532));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 38, DateTimeKind.Local).AddTicks(3536));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 38, DateTimeKind.Local).AddTicks(3537));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 38, DateTimeKind.Local).AddTicks(3539));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 38, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 37, DateTimeKind.Local).AddTicks(4495));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 37, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 37, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 19, 2, 23, 34, 37, DateTimeKind.Local).AddTicks(4568));
        }
    }
}
