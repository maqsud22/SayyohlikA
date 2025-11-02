using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SayyohlikA.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Davlats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Davlats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarjimons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FISH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Til = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjimons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "xaridors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FISH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xaridors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yangiliklars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sarlavxa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yangiliklars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shahars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MamlakatId = table.Column<int>(type: "int", nullable: false),
                    DavlatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shahars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shahars_Davlats_DavlatId",
                        column: x => x.DavlatId,
                        principalTable: "Davlats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shahars_DavlatId",
                table: "Shahars",
                column: "DavlatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shahars");

            migrationBuilder.DropTable(
                name: "Tarjimons");

            migrationBuilder.DropTable(
                name: "xaridors");

            migrationBuilder.DropTable(
                name: "Yangiliklars");

            migrationBuilder.DropTable(
                name: "Davlats");
        }
    }
}
