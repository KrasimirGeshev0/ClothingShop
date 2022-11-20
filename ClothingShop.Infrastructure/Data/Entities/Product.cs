using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClothingShop.Infrastructure.Data.Enums;
using static ClothingShop.Infrastructure.Data.DataConstants.Product;

namespace ClothingShop.Infrastructure.Data.Entities
{
    public class Product
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
        public string ImageUrl { get; set; }

        [Range(QuantityMin,QuantityMax)]
        public int SQuantity { get; set; }
        [Range(QuantityMin, QuantityMax)]
        public int MQuantity { get; set; }
        [Range(QuantityMin, QuantityMax)]
        public int LQuantity { get; set; }
        [Range(QuantityMin, QuantityMax)]
        public int XlQuantity { get; set; }

        [Required]
        public ProductGenderOrient GenderOrientation { get; set; } = new ProductGenderOrient();


        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
            
        public Brand Brand { get; set; } = null!;

        [ForeignKey(nameof(Category))]  
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public List<ApplicationUserProduct> ProductApplicationUsers { get; set; } = new List<ApplicationUserProduct>();

    }
}
