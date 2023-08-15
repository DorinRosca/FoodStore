using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodMarket.Migrations
{
     /// <inheritdoc />
     public partial class AddWishListItem : Migration
     {
          /// <inheritdoc />
          protected override void Up(MigrationBuilder migrationBuilder)
          {
               migrationBuilder.DropTable(
                   name: "ProductWishList");

               migrationBuilder.CreateTable(
                   name: "WishListItem",
                   columns: table => new
                   {
                        Id = table.Column<int>(type: "int", nullable: false)
                           .Annotation("SqlServer:Identity", "1, 1"),
                        WishListId = table.Column<int>(type: "int", nullable: false),
                        ProductId = table.Column<int>(type: "int", nullable: false),
                        Quantity = table.Column<short>(type: "smallint", nullable: false),
                        TotalAmount = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                   },
                   constraints: table =>
                   {
                        table.PrimaryKey("PK_WishListItem", x => x.Id);
                        table.ForeignKey(
                         name: "FK_WishListItem_Products_ProductId",
                         column: x => x.ProductId,
                         principalTable: "Products",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                         name: "FK_WishListItem_WishLists_WishListId",
                         column: x => x.WishListId,
                         principalTable: "WishLists",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Cascade);
                   });

               migrationBuilder.CreateIndex(
                   name: "IX_WishListItem_ProductId",
                   table: "WishListItem",
                   column: "ProductId");

               migrationBuilder.CreateIndex(
                   name: "IX_WishListItem_WishListId",
                   table: "WishListItem",
                   column: "WishListId");
          }

          /// <inheritdoc />
          protected override void Down(MigrationBuilder migrationBuilder)
          {
               migrationBuilder.DropTable(
                   name: "WishListItem");

               migrationBuilder.CreateTable(
                   name: "ProductWishList",
                   columns: table => new
                   {
                        ProductsId = table.Column<int>(type: "int", nullable: false),
                        WishListsId = table.Column<int>(type: "int", nullable: false)
                   },
                   constraints: table =>
                   {
                        table.PrimaryKey("PK_ProductWishList", x => new { x.ProductsId, x.WishListsId });
                        table.ForeignKey(
                         name: "FK_ProductWishList_Products_ProductsId",
                         column: x => x.ProductsId,
                         principalTable: "Products",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                         name: "FK_ProductWishList_WishLists_WishListsId",
                         column: x => x.WishListsId,
                         principalTable: "WishLists",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Cascade);
                   });

               migrationBuilder.CreateIndex(
                   name: "IX_ProductWishList_WishListsId",
                   table: "ProductWishList",
                   column: "WishListsId");
          }
     }
}
