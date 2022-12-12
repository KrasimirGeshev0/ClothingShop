namespace ClothingShop.Core.Models.AdminModels
{
    public class UserServiceModel
    {
        public string UserId { get; init; } = null!;

        public string Email { get; init; } = null!;

        public string UserName { get; init; } = null!;

        public string? FullName { get; set; }

        public int? SellerId { get; set; }

        public string? PhoneNumber { get; init; } = null;
    }
}
