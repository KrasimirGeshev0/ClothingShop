using System.ComponentModel.DataAnnotations;
using ClothingShop.Infrastructure.Data.Entities;
using ClothingShop.Infrastructure.Data.Enums;
using static ClothingShop.Infrastructure.Data.DataConstants.Cloth;

namespace ClothingShop.Core.Models.ClothModels
{
    public class ClothAddToShopAndEditModel
    {
        public int Id { get; set; } 

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

        [Range(QuantityMinAddAndEditModel, QuantityMax)]
        public int Quantity { get; set; }
        
        public string GenderOrientation { get; set; } = null!;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        public IEnumerable<ClothesCategoryModel> Categories { get; set; } = new List<ClothesCategoryModel>();

        public IEnumerable<ClothesBrandModel> Brands { get; set; } = new List<ClothesBrandModel>();
    }
}
