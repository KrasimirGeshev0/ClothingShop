using System.ComponentModel.DataAnnotations;

namespace ClothingShop.Core.Models.ClothModels
{
    public class ClothesServiceModel
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; } = null!;

        public decimal Price { get; init; }

        public string Category { get; set; } = null!;

    }
}
