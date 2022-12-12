using System.ComponentModel.DataAnnotations;
using ClothingShop.Core.Contracts;

namespace ClothingShop.Core.Models.ClothModels
{
    public class ClothesServiceModel : IClothModel
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; } = null!;

        public decimal Price { get; init; }

        public string Category { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public int SellerId { get; set; }

        [Display(Name = "Seller Name")] 
        public string SellerName { get; set; } = null!;

    }
}
