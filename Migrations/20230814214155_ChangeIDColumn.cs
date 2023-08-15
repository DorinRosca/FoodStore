using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodMarket.Migrations
{
     /// <inheritdoc />
     public partial class ChangeIDColumn : Migration
     {
          /// <inheritdoc />
          protected override void Up(MigrationBuilder migrationBuilder)
          {
               migrationBuilder.DropForeignKey(
                   name: "FK_CategoryProduct_Categories_CategoriesId",
                   table: "CategoryProduct");

               migrationBuilder.DropForeignKey(
                   name: "FK_CategoryProduct_Products_ProductsId",
                   table: "CategoryProduct");

               migrationBuilder.RenameColumn(
                   name: "Id",
                   table: "WishLists",
                   newName: "WishListId");

               migrationBuilder.RenameColumn(
                   name: "Id",
                   table: "WishListItems",
                   newName: "WishListItemId");

               migrationBuilder.RenameColumn(
                   name: "Id",
                   table: "Products",
                   newName: "ProductId");

               migrationBuilder.RenameColumn(
                   name: "ProductsId",
                   table: "CategoryProduct",
                   newName: "ProductsProductId");

               migrationBuilder.RenameColumn(
                   name: "CategoriesId",
                   table: "CategoryProduct",
                   newName: "CategoriesCategoryId");

               migrationBuilder.RenameIndex(
                   name: "IX_CategoryProduct_ProductsId",
                   table: "CategoryProduct",
                   newName: "IX_CategoryProduct_ProductsProductId");

               migrationBuilder.RenameColumn(
                   name: "Id",
                   table: "Categories",
                   newName: "CategoryId");

               migrationBuilder.AlterColumn<decimal>(
                   name: "TotalAmount",
                   table: "WishLists",
                   type: "decimal(8,2)",
                   nullable: false,
                   oldClrType: typeof(double),
                   oldType: "float");

               migrationBuilder.AddForeignKey(
                   name: "FK_CategoryProduct_Categories_CategoriesCategoryId",
                   table: "CategoryProduct",
                   column: "CategoriesCategoryId",
                   principalTable: "Categories",
                   principalColumn: "CategoryId",
                   onDelete: ReferentialAction.Cascade);

               migrationBuilder.AddForeignKey(
                   name: "FK_CategoryProduct_Products_ProductsProductId",
                   table: "CategoryProduct",
                   column: "ProductsProductId",
                   principalTable: "Products",
                   principalColumn: "ProductId",
                   onDelete: ReferentialAction.Cascade);
          }

          /// <inheritdoc />
          protected override void Down(MigrationBuilder migrationBuilder)
          {
               migrationBuilder.DropForeignKey(
                   name: "FK_CategoryProduct_Categories_CategoriesCategoryId",
                   table: "CategoryProduct");

               migrationBuilder.DropForeignKey(
                   name: "FK_CategoryProduct_Products_ProductsProductId",
                   table: "CategoryProduct");

               migrationBuilder.RenameColumn(
                   name: "WishListId",
                   table: "WishLists",
                   newName: "Id");

               migrationBuilder.RenameColumn(
                   name: "WishListItemId",
                   table: "WishListItems",
                   newName: "Id");

               migrationBuilder.RenameColumn(
                   name: "ProductId",
                   table: "Products",
                   newName: "Id");

               migrationBuilder.RenameColumn(
                   name: "ProductsProductId",
                   table: "CategoryProduct",
                   newName: "ProductsId");

               migrationBuilder.RenameColumn(
                   name: "CategoriesCategoryId",
                   table: "CategoryProduct",
                   newName: "CategoriesId");

               migrationBuilder.RenameIndex(
                   name: "IX_CategoryProduct_ProductsProductId",
                   table: "CategoryProduct",
                   newName: "IX_CategoryProduct_ProductsId");

               migrationBuilder.RenameColumn(
                   name: "CategoryId",
                   table: "Categories",
                   newName: "Id");

               migrationBuilder.AlterColumn<double>(
                   name: "TotalAmount",
                   table: "WishLists",
                   type: "float",
                   nullable: false,
                   oldClrType: typeof(decimal),
                   oldType: "decimal(8,2)");

               migrationBuilder.AddForeignKey(
                   name: "FK_CategoryProduct_Categories_CategoriesId",
                   table: "CategoryProduct",
                   column: "CategoriesId",
                   principalTable: "Categories",
                   principalColumn: "Id",
                   onDelete: ReferentialAction.Cascade);

               migrationBuilder.AddForeignKey(
                   name: "FK_CategoryProduct_Products_ProductsId",
                   table: "CategoryProduct",
                   column: "ProductsId",
                   principalTable: "Products",
                   principalColumn: "Id",
                   onDelete: ReferentialAction.Cascade);
          }
     }
}
