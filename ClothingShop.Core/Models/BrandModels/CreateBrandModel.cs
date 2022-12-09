using System.ComponentModel.DataAnnotations;
using static ClothingShop.Infrastructure.Data.DataConstants.Brand;

namespace ClothingShop.Core.Models.BrandModels
{
    public class CreateBrandModel
    {
        [Required]
        [StringLength(NameMaxLength), MinLength(NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string Logo { get; set; } = null!;


    }
}
