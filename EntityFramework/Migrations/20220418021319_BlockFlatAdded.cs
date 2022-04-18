using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class BlockFlatAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blocks",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlatTypes",
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
                    table.PrimaryKey("PK_FlatTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
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
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlatTypeId = table.Column<int>(type: "int", nullable: false),
                    BlockId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserTypeId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flats_Blocks_BlockId",
                        column: x => x.BlockId,
                        principalSchema: "Identity",
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flats_FlatTypes_FlatTypeId",
                        column: x => x.FlatTypeId,
                        principalSchema: "Identity",
                        principalTable: "FlatTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flats_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flats_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalSchema: "Identity",
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "FlatTypes",
                columns: new[] { "Id", "DateCreated", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(464), false, "Tanımsız" },
                    { 2, new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(489), false, "1+0" },
                    { 3, new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(491), false, "1+1" },
                    { 4, new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(492), false, "2+0" },
                    { 5, new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(494), false, "2+1" },
                    { 6, new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(498), false, "3+0" },
                    { 7, new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(499), false, "3+1" },
                    { 8, new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(500), false, "4+0" },
                    { 9, new DateTime(2022, 4, 18, 5, 13, 18, 926, DateTimeKind.Local).AddTicks(502), false, "4+1" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserTypes",
                columns: new[] { "Id", "DateCreated", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 18, 5, 13, 18, 923, DateTimeKind.Local).AddTicks(4428), false, "Daire Sahibi" },
                    { 2, new DateTime(2022, 4, 18, 5, 13, 18, 924, DateTimeKind.Local).AddTicks(3609), false, "Kiracı" },
                    { 3, new DateTime(2022, 4, 18, 5, 13, 18, 924, DateTimeKind.Local).AddTicks(3625), false, "Apartman Görevlisi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flats_BlockId",
                schema: "Identity",
                table: "Flats",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_FlatTypeId",
                schema: "Identity",
                table: "Flats",
                column: "FlatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_UserId",
                schema: "Identity",
                table: "Flats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_UserTypeId",
                schema: "Identity",
                table: "Flats",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flats",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Blocks",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "FlatTypes",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTypes",
                schema: "Identity");
        }
    }
}
