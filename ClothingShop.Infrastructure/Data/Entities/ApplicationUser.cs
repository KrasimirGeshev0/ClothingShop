using Microsoft.AspNetCore.Identity;

namespace ClothingShop.Infrastructure.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsActive { get; set; } = true;
        public List<ApplicationUserCloth> ApplicationUserClothes { get; set; } = new List<ApplicationUserCloth>();
    }
}
            