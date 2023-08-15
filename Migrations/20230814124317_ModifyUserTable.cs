using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodMarket.Migrations
{
     /// <inheritdoc />
     public partial class ModifyUserTable : Migration
     {
          /// <inheritdoc />
          protected override void Up(MigrationBuilder migrationBuilder)
          {
               migrationBuilder.DropForeignKey(
                   name: "FK_AspNetUsers_WishLists_WishListId",
                   table: "AspNetUsers");

               migrationBuilder.DropIndex(
                   name: "IX_AspNetUsers_WishListId",
                   table: "AspNetUsers");

               migrationBuilder.DropColumn(
                   name: "WishListId",
                   table: "AspNetUsers");

               migrationBuilder.AddColumn<string>(
                   name: "UserId1",
                   table: "WishLists",
                   type: "nvarchar(450)",
                   nullable: false,
                   defaultValue: "");

               migrationBuilder.CreateIndex(
                   name: "IX_WishLists_UserId1",
                   table: "WishLists",
                   column: "UserId1");

               migrationBuilder.AddForeignKey(
                   name: "FK_WishLists_AspNetUsers_UserId1",
                   table: "WishLists",
                   column: "UserId1",
                   principalTable: "AspNetUsers",
                   principalColumn: "Id",
                   onDelete: ReferentialAction.Cascade);
          }

          /// <inheritdoc />
          protected override void Down(MigrationBuilder migrationBuilder)
          {
               migrationBuilder.DropForeignKey(
                   name: "FK_WishLists_AspNetUsers_UserId1",
                   table: "WishLists");

               migrationBuilder.DropIndex(
                   name: "IX_WishLists_UserId1",
                   table: "WishLists");

               migrationBuilder.DropColumn(
                   name: "UserId1",
                   table: "WishLists");

               migrationBuilder.AddColumn<int>(
                   name: "WishListId",
                   table: "AspNetUsers",
                   type: "int",
                   nullable: false,
                   defaultValue: 0);

               migrationBuilder.CreateIndex(
                   name: "IX_AspNetUsers_WishListId",
                   table: "AspNetUsers",
                   column: "WishListId",
                   unique: true);

               migrationBuilder.AddForeignKey(
                   name: "FK_AspNetUsers_WishLists_WishListId",
                   table: "AspNetUsers",
                   column: "WishListId",
                   principalTable: "WishLists",
                   principalColumn: "Id",
                   onDelete: ReferentialAction.Cascade);
          }
     }
}
