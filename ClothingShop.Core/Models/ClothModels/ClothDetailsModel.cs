namespace ClothingShop.Core.Models.ClothModels
{
    public class ClothDetailsModel : ClothesServiceModel
    {
        public string Description { get; set; } = null!;

        public int Quantity { get; set; }

        public string GenderOrientation { get; set; } = null!;

        public string SellerPhoneNumber { get; set; } = null!;
    }
}
