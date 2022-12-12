using ClothingShop.Infrastructure.Data.Configuration;
using ClothingShop.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
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

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "415f0424-de60-4ffe-a988-e267825ed52c"
                });



            builder.Entity<ApplicationUserCloth>().HasKey(uc => new { uc.ApplicationUserId, uc.ClothId });

            builder.Entity<ApplicationUser>()
                .Property(u => u.Email)
                .HasMaxLength(EmailMaxLength)
                .IsRequired();

            base.OnModelCreating(builder);
        }
    }
}