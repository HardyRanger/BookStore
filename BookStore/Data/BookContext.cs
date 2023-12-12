using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookContext : IdentityDbContext<ApplicationUser>
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Books>()
                .HasOne(b => b.Author)
                .WithMany()
                .HasForeignKey(b => b.AuthorId)
                .IsRequired(false); 

           
            modelBuilder.Entity<Books>()
                .HasOne(b => b.Category)
                .WithMany()
                .HasForeignKey(b => b.CatId)
                .IsRequired(false);
    
            modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(sci => sci.Books)
                .WithMany()
                .HasForeignKey(sci => sci.BooksId)
                .IsRequired();


            base.OnModelCreating(modelBuilder);
        }
    }
}
