namespace ClothingShop.Core.Models.ClothModels
{
    public class ClothesCartModel
    {
        public IEnumerable<ClothesServiceModel> Clothes { get; set; } = null!;

        public decimal TotalPrice { get; set; }
    }
}
