using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodMarket.Migrations
{
     /// <inheritdoc />
     public partial class AddWishListItemTable : Migration
     {
          /// <inheritdoc />
          protected override void Up(MigrationBuilder migrationBuilder)
          {
               migrationBuilder.DropForeignKey(
                   name: "FK_WishListItem_Products_ProductId",
                   table: "WishListItem");

               migrationBuilder.DropForeignKey(
                   name: "FK_WishListItem_WishLists_WishListId",
                   table: "WishListItem");

               migrationBuilder.DropPrimaryKey(
                   name: "PK_WishListItem",
                   table: "WishListItem");

               migrationBuilder.RenameTable(
                   name: "WishListItem",
                   newName: "WishListItems");

               migrationBuilder.RenameIndex(
                   name: "IX_WishListItem_WishListId",
                   table: "WishListItems",
                   newName: "IX_WishListItems_WishListId");

               migrationBuilder.RenameIndex(
                   name: "IX_WishListItem_ProductId",
                   table: "WishListItems",
                   newName: "IX_WishListItems_ProductId");

               migrationBuilder.AddPrimaryKey(
                   name: "PK_WishListItems",
                   table: "WishListItems",
                   column: "Id");

               migrationBuilder.AddForeignKey(
                   name: "FK_WishListItems_Products_ProductId",
                   table: "WishListItems",
                   column: "ProductId",
                   principalTable: "Products",
                   principalColumn: "Id",
                   onDelete: ReferentialAction.Cascade);

               migrationBuilder.AddForeignKey(
                   name: "FK_WishListItems_WishLists_WishListId",
                   table: "WishListItems",
                   column: "WishListId",
                   principalTable: "WishLists",
                   principalColumn: "Id",
                   onDelete: ReferentialAction.Cascade);
          }

          /// <inheritdoc />
          protected override void Down(MigrationBuilder migrationBuilder)
          {
               migrationBuilder.DropForeignKey(
                   name: "FK_WishListItems_Products_ProductId",
                   table: "WishListItems");

               migrationBuilder.DropForeignKey(
                   name: "FK_WishListItems_WishLists_WishListId",
                   table: "WishListItems");

               migrationBuilder.DropPrimaryKey(
                   name: "PK_WishListItems",
                   table: "WishListItems");

               migrationBuilder.RenameTable(
                   name: "WishListItems",
                   newName: "WishListItem");

               migrationBuilder.RenameIndex(
                   name: "IX_WishListItems_WishListId",
                   table: "WishListItem",
                   newName: "IX_WishListItem_WishListId");

               migrationBuilder.RenameIndex(
                   name: "IX_WishListItems_ProductId",
                   table: "WishListItem",
                   newName: "IX_WishListItem_ProductId");

               migrationBuilder.AddPrimaryKey(
                   name: "PK_WishListItem",
                   table: "WishListItem",
                   column: "Id");

               migrationBuilder.AddForeignKey(
                   name: "FK_WishListItem_Products_ProductId",
                   table: "WishListItem",
                   column: "ProductId",
                   principalTable: "Products",
                   principalColumn: "Id",
                   onDelete: ReferentialAction.Cascade);

               migrationBuilder.AddForeignKey(
                   name: "FK_WishListItem_WishLists_WishListId",
                   table: "WishListItem",
                   column: "WishListId",
                   principalTable: "WishLists",
                   principalColumn: "Id",
                   onDelete: ReferentialAction.Cascade);
          }
     }
}
