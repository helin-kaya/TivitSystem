using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TivitSystemDL.Migrations
{
    /// <inheritdoc />
    public partial class changedtablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTivitMediaTable_USERTIVIT_UserTivitId",
                table: "UserTivitMediaTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTivitMediaTable",
                table: "UserTivitMediaTable");

            migrationBuilder.RenameTable(
                name: "UserTivitMediaTable",
                newName: "USERTIVITMEDIA");

            migrationBuilder.RenameIndex(
                name: "IX_UserTivitMediaTable_UserTivitId",
                table: "USERTIVITMEDIA",
                newName: "IX_USERTIVITMEDIA_UserTivitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USERTIVITMEDIA",
                table: "USERTIVITMEDIA",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_USERTIVITMEDIA_USERTIVIT_UserTivitId",
                table: "USERTIVITMEDIA",
                column: "UserTivitId",
                principalTable: "USERTIVIT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USERTIVITMEDIA_USERTIVIT_UserTivitId",
                table: "USERTIVITMEDIA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USERTIVITMEDIA",
                table: "USERTIVITMEDIA");

            migrationBuilder.RenameTable(
                name: "USERTIVITMEDIA",
                newName: "UserTivitMediaTable");

            migrationBuilder.RenameIndex(
                name: "IX_USERTIVITMEDIA_UserTivitId",
                table: "UserTivitMediaTable",
                newName: "IX_UserTivitMediaTable_UserTivitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTivitMediaTable",
                table: "UserTivitMediaTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTivitMediaTable_USERTIVIT_UserTivitId",
                table: "UserTivitMediaTable",
                column: "UserTivitId",
                principalTable: "USERTIVIT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
