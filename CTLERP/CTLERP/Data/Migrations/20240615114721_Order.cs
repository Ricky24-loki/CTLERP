using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTLERP.Data.Migrations
{
    /// <inheritdoc />
    public partial class Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItems_Orders_OrderId",
                table: "OrdersItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItems_Products_ProductId",
                table: "OrdersItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Orders",
                newName: "AmountDue");

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OrdersItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrdersItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItems_Orders_OrderId",
                table: "OrdersItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItems_Products_ProductId",
                table: "OrdersItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItems_Orders_OrderId",
                table: "OrdersItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItems_Products_ProductId",
                table: "OrdersItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "AmountDue",
                table: "Orders",
                newName: "Price");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OrdersItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrdersItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItems_Orders_OrderId",
                table: "OrdersItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItems_Products_ProductId",
                table: "OrdersItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
