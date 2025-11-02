using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SayyohlikA.Migrations
{
    /// <inheritdoc />
    public partial class AddXaridorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_xaridors",
                table: "xaridors");

            migrationBuilder.RenameTable(
                name: "xaridors",
                newName: "Xaridorlar");

            migrationBuilder.AddColumn<string>(
                name: "Manzili",
                table: "Xaridorlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sayohat_manzili",
                table: "Xaridorlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Xaridorlar",
                table: "Xaridorlar",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Xaridorlar",
                table: "Xaridorlar");

            migrationBuilder.DropColumn(
                name: "Manzili",
                table: "Xaridorlar");

            migrationBuilder.DropColumn(
                name: "Sayohat_manzili",
                table: "Xaridorlar");

            migrationBuilder.RenameTable(
                name: "Xaridorlar",
                newName: "xaridors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_xaridors",
                table: "xaridors",
                column: "Id");
        }
    }
}
