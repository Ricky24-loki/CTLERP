using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTLERP.Data.Migrations
{
    /// <inheritdoc />
    public partial class ParterTypeReq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partners_PartnerTypes_PartnerTypeId",
                table: "Partners");

            migrationBuilder.AlterColumn<int>(
                name: "PartnerTypeId",
                table: "Partners",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_PartnerTypes_PartnerTypeId",
                table: "Partners",
                column: "PartnerTypeId",
                principalTable: "PartnerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partners_PartnerTypes_PartnerTypeId",
                table: "Partners");

            migrationBuilder.AlterColumn<int>(
                name: "PartnerTypeId",
                table: "Partners",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_PartnerTypes_PartnerTypeId",
                table: "Partners",
                column: "PartnerTypeId",
                principalTable: "PartnerTypes",
                principalColumn: "Id");
        }
    }
}
