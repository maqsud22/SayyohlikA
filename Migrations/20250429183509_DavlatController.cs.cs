using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SayyohlikA.Migrations
{
    /// <inheritdoc />
    public partial class DavlatControllercs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shahars_Davlats_DavlatId",
                table: "Shahars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Davlats",
                table: "Davlats");

            migrationBuilder.RenameTable(
                name: "Davlats",
                newName: "Davlatlar");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Davlatlar",
                newName: "Nomi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Davlatlar",
                table: "Davlatlar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shahars_Davlatlar_DavlatId",
                table: "Shahars",
                column: "DavlatId",
                principalTable: "Davlatlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shahars_Davlatlar_DavlatId",
                table: "Shahars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Davlatlar",
                table: "Davlatlar");

            migrationBuilder.RenameTable(
                name: "Davlatlar",
                newName: "Davlats");

            migrationBuilder.RenameColumn(
                name: "Nomi",
                table: "Davlats",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Davlats",
                table: "Davlats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shahars_Davlats_DavlatId",
                table: "Shahars",
                column: "DavlatId",
                principalTable: "Davlats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
