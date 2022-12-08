using ClothingShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ClothingShop.Core.ExternalData.HomePageExternal;
using ClothingShop.Core.Models.HomeModels;

namespace ClothingShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var carouselModels = HomeCarouselSeed.SeedCarousel();   
            var genderSectionModels = HomeGenderSectionsSeed.SeedGenderSections();
            var model = new HomePageModel()
            {
                HomePageCarousel = carouselModels,
                HomePageGenderSection = genderSectionModels
            };

            
            return View(model);    
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}