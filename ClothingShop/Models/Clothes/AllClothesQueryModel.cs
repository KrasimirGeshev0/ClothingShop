using ClothingShop.Core.Models.ClothModels;

namespace ClothingShop.Models.Clothes
{
    public class AllClothesQueryModel
    {
        public ClothesSorting Sorting { get; set; }

        public string? Category { get; set; }

        public string? SearchTerm { get; set; } 

        public int CurrentPage { get; set; } = 1;

        public const int ClothesPerPage = 3;

        public int TotalClothesCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<ClothesServiceModel> Clothes { get; set; } = Enumerable.Empty<ClothesServiceModel>();
    }
}
