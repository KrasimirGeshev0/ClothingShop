using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingShop.Core.Models.ClothModels;
using ClothingShop.Core.Models.HomeModels;

namespace ClothingShop.Core.ExternalData.HomePageExternal
{
    public static class HomeCarouselSeed
    {
        public static IEnumerable<HomeModel> SeedCarousel()
        {
            List<HomeModel> models = new List<HomeModel>();
            var model = new HomeModel()
            {
                Title = "View all jackets",
                ImageUrl =
                    "https://i8.amplience.net/i/jpl/generic-cg-mob-85a612467ab89af170abf9cbe8b6fbe0?fmt=auto",
                ActionName = "Jackets"
            };

            models.Add(model);

            model = new HomeModel()
            {
                Title = "All From Nike",
                ImageUrl = "https://www.gridsu.com/wp-content/uploads/2020/10/5d49924e100a241a884446cc.jpg",
                ActionName = "AllFromNike"
            };

            models.Add(model);

            return models;
        }
    }
}
