using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class MessageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReceiveUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLooked = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_User_ReceiveUserId",
                        column: x => x.ReceiveUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_User_SendUserId",
                        column: x => x.SendUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 510, DateTimeKind.Local).AddTicks(4794));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 510, DateTimeKind.Local).AddTicks(4818));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 510, DateTimeKind.Local).AddTicks(4821));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 510, DateTimeKind.Local).AddTicks(4822));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 510, DateTimeKind.Local).AddTicks(4824));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "BillTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 510, DateTimeKind.Local).AddTicks(4827));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 503, DateTimeKind.Local).AddTicks(7189));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 507, DateTimeKind.Local).AddTicks(7573));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 507, DateTimeKind.Local).AddTicks(7600));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 507, DateTimeKind.Local).AddTicks(7602));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 507, DateTimeKind.Local).AddTicks(7604));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 507, DateTimeKind.Local).AddTicks(7605));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 507, DateTimeKind.Local).AddTicks(7609));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 507, DateTimeKind.Local).AddTicks(7610));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 507, DateTimeKind.Local).AddTicks(7612));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 507, DateTimeKind.Local).AddTicks(7613));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 506, DateTimeKind.Local).AddTicks(8557));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 506, DateTimeKind.Local).AddTicks(8597));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 506, DateTimeKind.Local).AddTicks(8601));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 21, 12, 11, 57, 506, DateTimeKind.Local).AddTicks(8603));

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiveUserId",
                schema: "Identity",
                table: "Messages",
                column: "ReceiveUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SendUserId",
                schema: "Identity",
                table: "Messages",
                column: "SendUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages",
                schema: "Identity");

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
    }
}
