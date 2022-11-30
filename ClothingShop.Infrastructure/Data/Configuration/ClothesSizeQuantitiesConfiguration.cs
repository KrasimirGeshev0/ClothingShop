using ClothingShop.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingShop.Infrastructure.Data.Configuration
{
    internal class ClothesSizeQuantitiesConfiguration : IEntityTypeConfiguration<ClothSizesQuantities>
    {
        public void Configure(EntityTypeBuilder<ClothSizesQuantities> builder)
        {
            builder.HasData(CreateCSQConfigurations());
        }

        private List<ClothSizesQuantities> CreateCSQConfigurations()
        {
            var csq = new List<ClothSizesQuantities>();

            csq.Add(new ClothSizesQuantities()
            {
                Id = 1,
                SQuantity = 3,
                MQuantity = 5,
                LQuantity = 2,
                XlQuantity = 1
            });

            csq.Add(new ClothSizesQuantities()
            {
                Id = 2,
                SQuantity = 3,
                MQuantity = 5,
                LQuantity = 2,
                XlQuantity = 1
            });

            csq.Add(new ClothSizesQuantities()
            {
                Id = 3,
                SQuantity = 4,
                MQuantity = 2,
                LQuantity = 1,
                XlQuantity = 0
            });

            return csq;
        }   
    }
}
