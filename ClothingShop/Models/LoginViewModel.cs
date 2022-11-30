using System.ComponentModel.DataAnnotations;

namespace ClothingShop.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

    }
}
