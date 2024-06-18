using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTLERP.Data.Migrations
{
    /// <inheritdoc />
    public partial class PartnersNujCeAre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Partners");

            migrationBuilder.AddColumn<int>(
                name: "PartnerTypeId",
                table: "Partners",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partners_PartnerTypeId",
                table: "Partners",
                column: "PartnerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_PartnerTypes_PartnerTypeId",
                table: "Partners",
                column: "PartnerTypeId",
                principalTable: "PartnerTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partners_PartnerTypes_PartnerTypeId",
                table: "Partners");

            migrationBuilder.DropIndex(
                name: "IX_Partners_PartnerTypeId",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "PartnerTypeId",
                table: "Partners");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
