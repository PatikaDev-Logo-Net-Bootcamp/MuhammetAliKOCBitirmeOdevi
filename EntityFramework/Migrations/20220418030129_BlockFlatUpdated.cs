using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class BlockFlatUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4663), true });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4688), true });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4692), true });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4693), true });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4695), true });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4702), true });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4703), true });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4705), true });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 6, 1, 29, 371, DateTimeKind.Local).AddTicks(4706), true });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 6, 1, 29, 368, DateTimeKind.Local).AddTicks(6326), true });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 6, 1, 29, 369, DateTimeKind.Local).AddTicks(6744), true });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 6, 1, 29, 369, DateTimeKind.Local).AddTicks(6764), true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(464), false });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(489), false });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(491), false });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(492), false });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(494), false });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(498), false });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(499), false });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(500), false });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(502), false });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 5, 13, 18, 923, DateTimeKind.Local).AddTicks(4428), false });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 5, 13, 18, 924, DateTimeKind.Local).AddTicks(3609), false });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 18, 5, 13, 18, 924, DateTimeKind.Local).AddTicks(3625), false });
        }
    }
}
