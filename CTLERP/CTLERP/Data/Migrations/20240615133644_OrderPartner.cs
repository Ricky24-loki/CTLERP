using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTLERP.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderPartner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartnerId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PartnerId",
                table: "Orders",
                column: "PartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Partners_PartnerId",
                table: "Orders",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Partners_PartnerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PartnerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "Orders");
        }
    }
}
