namespace ClothingShop.Core.Models.HomeModels
{
    public class HomePageModel
    {
        public IEnumerable<HomeModel> HomePageCarousel { get; set; } = new List<HomeModel>();

        public IEnumerable<HomeModel> HomePageGenderSection { get; set; } = new List<HomeModel>();
    }
}
