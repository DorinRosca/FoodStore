using FoodMarket.Pages.Categories.Entities;
using FoodMarket.Pages.Products.Entities;
using FoodMarket.Pages.WishListItems.Entities;
using FoodMarket.Pages.WishLists.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodMarket.Data
{
     public class DataContext : IdentityDbContext
     {
          public DataContext(DbContextOptions options) : base(options)
          {
          }

          public virtual DbSet<Category> Categories { get; set; }
          public virtual DbSet<Product> Products { get; set; }
          public virtual DbSet<WishList> WishLists { get; set; }
          public virtual DbSet<WishListItem> WishListItems { get; set; }
          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {

               base.OnModelCreating(modelBuilder);
          }
     }
}
