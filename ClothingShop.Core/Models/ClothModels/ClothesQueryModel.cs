namespace ClothingShop.Core.Models.ClothModels
{
    public class ClothesQueryModel
    {
        public int TotalClothesCount { get; set; }
        public IEnumerable<ClothesServiceModel> Clothes { get; set; } = new List<ClothesServiceModel>();
    }
}
