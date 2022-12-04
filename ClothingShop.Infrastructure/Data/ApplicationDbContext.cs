using ClothingShop.Infrastructure.Data.Configuration;
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

        public DbSet<Cloth> Clothes { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Brand> Brands { get; set; }
            
        public DbSet<Category> Categories { get; set; }

        public DbSet<ApplicationUserCloth> ApplicationUsersClothes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new SellerConfiguration());
            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ClothConfiguration());


            builder.Entity<ApplicationUserCloth>().HasKey(uc => new { uc.ApplicationUserId, uc.ClothId });

            builder.Entity<ApplicationUser>()
                .Property(u => u.Email)
                .HasMaxLength(EmailMaxLength)
                .IsRequired();

            base.OnModelCreating(builder);
        }
    }
}