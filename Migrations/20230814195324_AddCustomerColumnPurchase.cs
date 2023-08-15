using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodMarket.Migrations
{
     /// <inheritdoc />
     public partial class AddCustomerColumnPurchase : Migration
     {
          /// <inheritdoc />
          protected override void Up(MigrationBuilder migrationBuilder)
          {
               migrationBuilder.AddColumn<int>(
                   name: "CustomerPurchaseCount",
                   table: "Products",
                   type: "int",
                   nullable: false,
                   defaultValue: 0);
          }

          /// <inheritdoc />
          protected override void Down(MigrationBuilder migrationBuilder)
          {
               migrationBuilder.DropColumn(
                   name: "CustomerPurchaseCount",
                   table: "Products");
          }
     }
}
