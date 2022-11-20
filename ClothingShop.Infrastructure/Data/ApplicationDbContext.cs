using ClothingShop.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static ClothingShop.Infrastructure.Data.DataConstants.User;

namespace ClothingShop.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ApplicationUserProduct> ApplicationUsersProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserProduct>().HasKey(up => new { up.ApplicationUserId, up.ProductId });

            builder.Entity<ApplicationUser>()
                .Property(u => u.Email)
                .HasMaxLength(EmailMaxLength)
                .IsRequired();

            base.OnModelCreating(builder);
        }
    }
}