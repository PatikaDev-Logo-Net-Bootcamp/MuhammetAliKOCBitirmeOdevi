using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class BillAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillTypes",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillTypeId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Mount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_BillTypes_BillTypeId",
                        column: x => x.BillTypeId,
                        principalSchema: "Identity",
                        principalTable: "BillTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillFlats",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    FlatId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillFlats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillFlats_Bills_BillId",
                        column: x => x.BillId,
                        principalSchema: "Identity",
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillFlats_Flats_FlatId",
                        column: x => x.FlatId,
                        principalSchema: "Identity",
                        principalTable: "Flats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "BillTypes",
                columns: new[] { "Id", "DateCreated", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 19, 2, 23, 34, 40, DateTimeKind.Local).AddTicks(9306), true, "Tanımsız" },
                    { 2, new DateTime(2022, 4, 19, 2, 23, 34, 40, DateTimeKind.Local).AddTicks(9340), true, "Aidat" },
                    { 3, new DateTime(2022, 4, 19, 2, 23, 34, 40, DateTimeKind.Local).AddTicks(9342), true, "Elektrik" },
                    { 4, new DateTime(2022, 4, 19, 2, 23, 34, 40, DateTimeKind.Local).AddTicks(9344), true, "Su" },
                    { 5, new DateTime(2022, 4, 19, 2, 23, 34, 40, DateTimeKind.Local).AddTicks(9345), true, "Doğal Gaz" },
                    { 6, new DateTime(2022, 4, 19, 2, 23, 34, 40, DateTimeKind.Local).AddTicks(9349), true, "Diğer" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_BillFlats_BillId",
                schema: "Identity",
                table: "BillFlats",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillFlats_FlatId",
                schema: "Identity",
                table: "BillFlats",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BillTypeId",
                schema: "Identity",
                table: "Bills",
                column: "BillTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillFlats",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Bills",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "BillTypes",
                schema: "Identity");

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
    }
}
