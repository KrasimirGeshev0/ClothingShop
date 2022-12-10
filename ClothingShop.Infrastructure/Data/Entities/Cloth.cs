using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClothingShop.Infrastructure.Data.Enums;
using static ClothingShop.Infrastructure.Data.DataConstants.Cloth;

namespace ClothingShop.Infrastructure.Data.Entities
{
    public class Cloth
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required] 
        public string ImageUrl { get; set; } = null!;

        public bool IsAvailable { get; set; }  = true;

        [Required]
        public ProductGenderOrient GenderOrientation { get; set; } = new ProductGenderOrient();

        [Range(QuantityMin, QuantityMax)]
        public int Quantity { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;

        [ForeignKey(nameof(Category))]  
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int SellerId { get; set; }

        public List<ApplicationUserCloth> ProductApplicationUsers { get; set; } = new List<ApplicationUserCloth>();

    }
}
