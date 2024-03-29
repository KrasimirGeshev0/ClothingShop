﻿using ClothingShop.Infrastructure.Data.Entities;
using ClothingShop.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingShop.Infrastructure.Data.Configuration
{
    internal class ClothConfiguration : IEntityTypeConfiguration<Cloth>
    {
        public void Configure(EntityTypeBuilder<Cloth> builder)
        {
            builder.HasData(CreateClothes());
        }

        private List<Cloth> CreateClothes()
        {
            List<Cloth> clothes = new List<Cloth>();

            var cloth = new Cloth()
            {
                Id = 1,
                Name = "Men’s 1996 Retro Nuptse Jacket",
                Price = 750,
                Description = "The moment you see the oversized baffles you know you’re looking at our iconic Nuptse. This warm, durable jacket has lofty 700-fill down, a water-repellent finish and a stowable hood. It also features 100% recycled fabrics and a design inspired by the classic 1996 version.",
                ImageUrl = "https://images.thenorthface.com/is/image/TheNorthFace/NF0A3C8D_LE4_int?wid=1300&hei=1510&fmt=jpeg&qlt=90&resMode=sharp2&op_usm=0.9,1.0,8,0",
                GenderOrientation = ProductGenderOrient.Male,
                Quantity = 2,
                BrandId = 1,
                CategoryId = 1,
                SellerId = 1
            };

            clothes.Add(cloth);

           cloth = new Cloth()
            {
                Id = 2,
               Name = "Nike x Supreme Black Reversible Puffer Jacket",
                Price = 900,
                Description = "This Nike x Supreme Puffy Jacket worn by J Balvin features a reversible black polyester knit shell, with one side featuring an allover Nike Sportswear logo jacquard; and the other side a solid black knit with a Nike Sportswear logo on the left chest; grey snakeskin Nike logo above the back right hem; elastic cuffs; drawcord hem; zip front; & stand collar",
                ImageUrl = "https://image.goat.com/transform/v1/attachments/product_template_additional_pictures/images/052/170/816/original/746090_01.jpg.jpeg?action=crop&width=750",
                GenderOrientation = ProductGenderOrient.Unisex,
                Quantity = 10,
                BrandId = 2,
                CategoryId = 1,
                SellerId = 1
           };

           clothes.Add(cloth);

           cloth = new Cloth()
           {
               Id = 3,
               Name = "Classics 3-Sstripes T-Shirt",
               Price = 50,
               Description = "No need to overcomplicate things — this adidas t-shirt is all about ease. Keep your vibe real, real chill with the understated look. Though it doesn't give into full minimalism. The comfort goes all out, thanks to the super soft cotton build.",
               ImageUrl = "https://img01.ztat.net/article/spp-media-p1/20f877b0dfd33bc99f742bf8a7e57db4/aa07fae097284ea589a1665965c73678.jpg?imwidth=1800",
               GenderOrientation = ProductGenderOrient.Male,
               Quantity = 5,
               BrandId = 3,
               CategoryId = 3,
               SellerId = 1
           };

           clothes.Add(cloth);

           return clothes;
        }
    }
}
