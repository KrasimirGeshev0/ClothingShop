using ClothingShop.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingShop.Infrastructure.Data.Configuration
{
    internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(CreateBrands());
        }

        private List<Brand> CreateBrands()
        {
            var brands = new List<Brand>();

            brands.Add(new Brand()
            {
                Id = 1,
                Logo = "https://1000logos.net/wp-content/uploads/2017/05/Symbol-North-Face.jpg",
                Name = "The North Face"
            });

            brands.Add(new Brand()
            {
                Id = 2,
                Logo = "https://upload.wikimedia.org/wikipedia/commons/3/36/Logo_nike_principal.jpg",
                Name = "Nike"
            });

            brands.Add(new Brand()
            {
                Id = 3,
                Logo = "https://1000logos.net/wp-content/uploads/2019/06/Adidas-Logo-1991.jpg",
                Name = "Addidas"
            });

            return brands;
        }
    }
}
