using ClothingShop.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingShop.Infrastructure.Data.Configuration
{
    internal class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasData(new Seller()
            {
                Id = 1,
                FirstName = "Tosho",
                LastName = "Kukata",
                PhoneNumber = "+1 202-918-2132",
                ApplicationUserId = "dea12856-c198-4129-b3f3-b893d8395082"
            });
        }
    }
}
