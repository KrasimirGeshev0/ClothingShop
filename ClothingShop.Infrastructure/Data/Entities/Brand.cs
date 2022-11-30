using System.ComponentModel.DataAnnotations;
using static ClothingShop.Infrastructure.Data.DataConstants.Brand;

namespace ClothingShop.Infrastructure.Data.Entities
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required] 
        public string Logo { get; set; } = null!;

        public List<Cloth> Clothes { get; set; } = new List<Cloth>();
    }
}
    