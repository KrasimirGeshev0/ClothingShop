using ClothingShop.Core.Contracts;
using ClothingShop.Core.Models.ClothModels;
using ClothingShop.Models.Clothes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Controllers
{
    [Authorize]
    public class ClothesController :  Controller
    {
        private readonly IClothService clothService;


        public ClothesController(IClothService _clothService)
        {
            clothService = _clothService;  
        }

        public async Task<IActionResult> All([FromQuery]AllClothesQueryModel query)
        {
            var result = await clothService.All(
                query.Sorting,
                query.Category,
                query.SearchTerm,
                query.CurrentPage,
                AllClothesQueryModel.ClothesPerPage);

            query.TotalClothesCount = result.TotalClothesCount;
            query.Categories = await clothService.AllCategoriesNames();
            query.Clothes = result.Clothes;

            return View(query);
        }

        //TODO Implement
        public async Task<IActionResult> Details()
        {
            return null;
        }
        
        //TODO Implement
        public async Task<IActionResult> Edit()
        {
            return null;
        }

        //TODO Implement
        public async Task<IActionResult> Delete()
        {
            return null;
        }

        //TODO Implement
        public async Task<IActionResult> AddToCart()
        {
            return null;
        }

    }
}
