using ClothingShop.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingShop.Infrastructure.Data.Configuration
{
    internal class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasData(CreateSellers());
        }

        private List<Seller> CreateSellers()
        {
            var sellers = new List<Seller>();

            sellers.Add(new Seller()
            {
                Id = 1,
                FirstName = "Tosho",
                LastName = "Kukata",
                PhoneNumber = "+1 202-918-2132",
                ApplicationUserId = "dea12856-c198-4129-b3f3-b893d8395082"
            });

            sellers.Add(new Seller()
            {
                Id = 2,
                FirstName = "Administrator",
                LastName = " ",
                PhoneNumber = "+1 111-111-1111",
                ApplicationUserId = "415f0424-de60-4ffe-a988-e267825ed52c"
            });

            return sellers;
        }
    }
}
