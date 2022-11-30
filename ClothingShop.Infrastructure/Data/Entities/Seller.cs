using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ClothingShop.Infrastructure.Data.DataConstants.Seller;

namespace ClothingShop.Infrastructure.Data.Entities
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(FirstNameMaxLength)]
        public string? FirstName { get; set; }

        [MaxLength(LastNameMaxLength)]
        public string? LastName { get; set; } = null!;
        [Required]
        [MaxLength]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; } = null!;

        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
