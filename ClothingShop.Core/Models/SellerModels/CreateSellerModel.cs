using System.ComponentModel.DataAnnotations;
using static ClothingShop.Infrastructure.Data.DataConstants.Seller;

namespace ClothingShop.Core.Models.SellerModels
{
    public class CreateSellerModel
    {
        [MaxLength(FirstNameMaxLength)]
        public string? FirstName { get; set; } = null!;

        [MaxLength(LastNameMaxLength)]
        public string? LastName { get; set; } = null!;
        [Required]
        [MaxLength]
        public string PhoneNumber { get; set; } = null!;
    }
}
