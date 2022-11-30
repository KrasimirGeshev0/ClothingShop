using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingShop.Infrastructure.Data.Entities
{
    public class ApplicationUserCloth
    {
        [Required]
        [ForeignKey(nameof(ApplicationUser))] 
        public string ApplicationUserId { get; set; } = null!;
        public ApplicationUser ApplicationUser { get; set; } = null!;

        [ForeignKey(nameof(Cloth))]
        public int ClothId { get; set; }
        public Cloth Cloth { get; set; } = null!;
    }
}
