using ClothingShop.Core.Models.HomeModels;

namespace ClothingShop.Core.ExternalData.HomePageExternal
{
    public class HomeGenderSectionsSeed
    {
        //TODO male and female
        public static IEnumerable<HomeModel> SeedGenderSections()
        {
            List<HomeModel> models = new List<HomeModel>();
            var model = new HomeModel()
            {
                Title = "Clothes for man",
                ImageUrl =
                    "https://img.freepik.com/premium-photo/men-s-clothing-set-with-oxford-shoes-watch-sunglasses-office-shirt-tie-jacket-isolated-white-background-top-view_107612-80.jpg?w=2000",
                ActionName = "MenClothes"
            };

            models.Add(model);

            model = new HomeModel()
            {
                Title = "Clothes for woman",
                ImageUrl = "https://media.istockphoto.com/id/855095958/photo/womens-clothing-isolated-on-white-background.jpg?s=612x612&w=0&k=20&c=IU2y7Y7Q0kvAiCv3lxP1peiTkx1-dmp_7yPGSZIozjw=",
                ActionName = "WomenClothes"
            };

            models.Add(model);

            return models;
        }
    }
}
