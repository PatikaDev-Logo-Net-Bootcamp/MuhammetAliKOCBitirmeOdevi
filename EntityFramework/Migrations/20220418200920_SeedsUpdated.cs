using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class SeedsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Blocks",
                columns: new[] { "Id", "Address", "DateCreated", "Description", "IsActive", "Name" },
                values: new object[] { 1, null, new DateTime(2022, 4, 18, 23, 9, 19, 666, DateTimeKind.Local).AddTicks(1550), null, true, "Tanımsız" });

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
                columns: new[] { "DateCreated", "Name" },
                values: new object[] { new DateTime(2022, 4, 18, 23, 9, 19, 668, DateTimeKind.Local).AddTicks(9549), "Tanımsız" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "Name" },
                values: new object[] { new DateTime(2022, 4, 18, 23, 9, 19, 668, DateTimeKind.Local).AddTicks(9580), "Daire Sahibi" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "Name" },
                values: new object[] { new DateTime(2022, 4, 18, 23, 9, 19, 668, DateTimeKind.Local).AddTicks(9582), "Kiracı" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserTypes",
                columns: new[] { "Id", "DateCreated", "IsActive", "Name" },
                values: new object[] { 4, new DateTime(2022, 4, 18, 23, 9, 19, 668, DateTimeKind.Local).AddTicks(9584), true, "Apartman Görevlisi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4663));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4688));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4692));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4693));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4695));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4702));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4703));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4705));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4706));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Name" },
                values: new object[] { new DateTime(2022, 4, 18, 6, 1, 29, 368, DateTimeKind.Local).AddTicks(6326), "Daire Sahibi" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "Name" },
                values: new object[] { new DateTime(2022, 4, 18, 6, 1, 29, 369, DateTimeKind.Local).AddTicks(6744), "Kiracı" });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "Name" },
                values: new object[] { new DateTime(2022, 4, 18, 6, 1, 29, 369, DateTimeKind.Local).AddTicks(6764), "Apartman Görevlisi" });
        }
    }
}
