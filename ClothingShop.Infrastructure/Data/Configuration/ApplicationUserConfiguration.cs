using ClothingShop.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingShop.Infrastructure.Data.Configuration
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(CreateUsers());
        }

        private List<ApplicationUser> CreateUsers()
        {
            var users = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

           var user = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "SellerUser",
                NormalizedUserName = "SELLERUSER",
                Email = "seller@mail.com",
                NormalizedEmail = "SELLER@MAIL.COM"
            };

           user.PasswordHash =
                hasher.HashPassword(user, "seller123");

            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "NormalUser",
                NormalizedUserName = "NORMALUSER",
                Email = "user@mail.com",
                NormalizedEmail = "USER@MAIL.COM"
            };

            user.PasswordHash =
                hasher.HashPassword(user, "user123");

            users.Add(user);

            return users;
        }


    }
}
