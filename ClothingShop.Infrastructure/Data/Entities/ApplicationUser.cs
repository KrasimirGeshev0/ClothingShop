using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static ClothingShop.Infrastructure.Data.DataConstants.User;

namespace ClothingShop.Infrastructure.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public decimal Balance { get; set; } = 0;

        public List<ApplicationUserProduct> ApplicationUserProducts { get; set; } = new List<ApplicationUserProduct>();
    }
}
        