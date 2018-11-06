using Microsoft.EntityFrameworkCore.Migrations;

namespace Dolce_Vita.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Orders_OrderId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Categories_CategoryId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Dishes_DishId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "Orders",
                newName: "DishID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DishId",
                table: "Orders",
                newName: "IX_Orders_DishID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Dishes",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes",
                newName: "IX_Dishes_CategoryID");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Customers",
                newName: "OrdersID");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_OrderId",
                table: "Customers",
                newName: "IX_Customers_OrdersID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Orders_OrdersID",
                table: "Customers",
                column: "OrdersID",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Categories_CategoryID",
                table: "Dishes",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Dishes_DishID",
                table: "Orders",
                column: "DishID",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Orders_OrdersID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Categories_CategoryID",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Dishes_DishID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "DishID",
                table: "Orders",
                newName: "DishId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DishID",
                table: "Orders",
                newName: "IX_Orders_DishId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Dishes",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_CategoryID",
                table: "Dishes",
                newName: "IX_Dishes_CategoryId");

            migrationBuilder.RenameColumn(
                name: "OrdersID",
                table: "Customers",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_OrdersID",
                table: "Customers",
                newName: "IX_Customers_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Orders_OrderId",
                table: "Customers",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Categories_CategoryId",
                table: "Dishes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Dishes_DishId",
                table: "Orders",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
