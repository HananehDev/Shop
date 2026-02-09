using Microsoft.EntityFrameworkCore;
using MySHop.Models;

namespace MySHop.Data
{
    public class MyShopContext : DbContext
    {
        public MyShopContext(DbContextOptions<MyShopContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<CategoryToProduct> categoryToProducts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> ordersDetails { get; set; }    
        //public DbSet<Cart> carts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>().HasKey(t => new {t.CategoryId, t.ProductId});  // Required
            //modelBuilder.Entity<Product>(p => 
            //{ 
            //    p.HasKey(w => w.Id);
            //    p.OwnsOne<Item>(w => w.item);
            //    p.HasOne(w => w.item).WithOne(p => p.Product);
            //});

            modelBuilder.Entity<Item>(i =>                                                          // Optional
            {
                    i.Property(w => w.Price).HasColumnType("Money");
                }
            );

            #region seed data Item
            modelBuilder.Entity<Item>().HasData(
                    new Item()
                    {
                        Id = 1,
                        Price = 100.0M,
                        QuantityInStock = 4,
                        productId=1
                    },
                    new Item()
                    {
                        Id = 2,
                        Price = 2000.500M,
                        QuantityInStock = 5,
                        productId=2
                    },
                    new Item()
                    {
                        Id = 3,
                        Price = 5000.0M ,
                        QuantityInStock = 1,
                        productId=3
                    }
                );
            #endregion

            #region seed data Product
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "تیشرت آستین کوتاه زنانه ",
                    Description = "تیشرت آستین کوتاه زنانه"
                },
                new Product()
                {
                    Id = 2,
                    Name = "تیشرت آستین بلند زنانه ",
                    Description = "تیشرت آستین بلند زنانه"
                },
                new Product()
                {
                    Id = 3,
                    Name = "پیراهن مردانه ",
                    Description = "پیراهن مردانه"
                }
                );
            #endregion

            #region seed data CategoryToProduct
            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct() { CategoryId = 1 , ProductId = 1 },
                new CategoryToProduct() { CategoryId = 2 , ProductId = 1 },
                new CategoryToProduct() { CategoryId = 3 , ProductId = 1 },
                new CategoryToProduct() { CategoryId = 4 , ProductId = 1 },

                new CategoryToProduct() { CategoryId = 1 , ProductId = 2 },
                new CategoryToProduct() { CategoryId = 2 , ProductId = 2 },
                new CategoryToProduct() { CategoryId = 3 , ProductId = 2 },
                new CategoryToProduct() { CategoryId = 4 , ProductId = 2 },

                new CategoryToProduct() { CategoryId = 1 , ProductId = 3 },
                new CategoryToProduct() { CategoryId = 2 , ProductId = 3 },
                new CategoryToProduct() { CategoryId = 3 , ProductId = 3 },
                new CategoryToProduct() { CategoryId = 4 , ProductId = 3 }


            );
            #endregion

            #region Seed data category
            modelBuilder.Entity<Category>().HasData(new Category()
                {
                    Id =1,
                    Title = "لباس زنانه",
                    Description = "لباس زنانه"
            },new Category()
                {
                    Id= 2,
                    Title= "لباس مردانه", 
                    Description= "لباس مردانه"
            }, new Category()
                {
                    Id = 3,
                    Title = "لباس بچه گانه",
                    Description = "لباس بچه گانه"
            }, new Category()
                {
                    Id = 4,
                    Title = "لباس نوزاد ",
                    Description = "لباس نوزاد"
            }
            );

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
