using System.ComponentModel.DataAnnotations;
using static ClothingShop.Infrastructure.Data.DataConstants.Seller;

namespace ClothingShop.Core.Models.SellerModels
{
    public class CreateSellerModel
    {
        [Required]
        [MaxLength(FirstNameMaxLength)]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        [Display(Name = "Lirst name")]
        public string LastName { get; set; } = null!;

        [Phone]
        [Required]
        [MaxLength]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;

    }
}
