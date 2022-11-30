using ClothingShop.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingShop.Infrastructure.Data.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            var categories = new List<Category>();

            categories.Add(new Category()
            {
                Id = 1,
                Name = "Jackets"
            });

            categories.Add(new Category()
            {
                Id = 2,
                Name = "Sweatshirt"
            });

            categories.Add(new Category()
            {
                Id = 3,
                Name = "T-Shirts"
            });

            return categories;
        }
    }
}
