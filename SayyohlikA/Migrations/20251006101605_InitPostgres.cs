using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SayyohlikA.Migrations
{
    /// <inheritdoc />
    public partial class InitPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shahars_Davlatlar_DavlatId",
                table: "Shahars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Yangiliklars",
                table: "Yangiliklars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shahars",
                table: "Shahars");

            migrationBuilder.RenameTable(
                name: "Yangiliklars",
                newName: "Yangiliklar");

            migrationBuilder.RenameTable(
                name: "Shahars",
                newName: "Shaharlar");

            migrationBuilder.RenameIndex(
                name: "IX_Shahars_DavlatId",
                table: "Shaharlar",
                newName: "IX_Shaharlar_DavlatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Yangiliklar",
                table: "Yangiliklar",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shaharlar",
                table: "Shaharlar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shaharlar_Davlatlar_DavlatId",
                table: "Shaharlar",
                column: "DavlatId",
                principalTable: "Davlatlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shaharlar_Davlatlar_DavlatId",
                table: "Shaharlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Yangiliklar",
                table: "Yangiliklar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shaharlar",
                table: "Shaharlar");

            migrationBuilder.RenameTable(
                name: "Yangiliklar",
                newName: "Yangiliklars");

            migrationBuilder.RenameTable(
                name: "Shaharlar",
                newName: "Shahars");

            migrationBuilder.RenameIndex(
                name: "IX_Shaharlar_DavlatId",
                table: "Shahars",
                newName: "IX_Shahars_DavlatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Yangiliklars",
                table: "Yangiliklars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shahars",
                table: "Shahars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shahars_Davlatlar_DavlatId",
                table: "Shahars",
                column: "DavlatId",
                principalTable: "Davlatlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
