using System.ComponentModel.DataAnnotations;
using ClothingShop.Infrastructure.Data.Entities;
using ClothingShop.Infrastructure.Data.Enums;
using static ClothingShop.Infrastructure.Data.DataConstants.Cloth;

namespace ClothingShop.Core.Models.ClothModels
{
    public class ClothAddToShopModel
    {
        [Required]
        [StringLength(NameMaxLength), MinLength(NameMinLength)]
        public string Name { get; set; } = null!;

        [Range(0, 10000)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength), MinLength(DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Range(QuantityMin, QuantityMax)]
        public int Quantity { get; set; }

        [Required]
        public ProductGenderOrient GenderOrientation { get; set; } = new ProductGenderOrient();

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        public IEnumerable<ClothesCategoryModel> Categories { get; set; } = new List<ClothesCategoryModel>();

        public IEnumerable<ClothesBrandModel> Brands { get; set; } = new List<ClothesBrandModel>();
    }
}
