using ClothingShop.Core.Contracts;
using ClothingShop.Core.Models.ClothModels;
using ClothingShop.Extensions;
using ClothingShop.Models.Clothes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Controllers
{
    [Authorize]
    public class ClothController : Controller
    {
        private readonly IClothService clothService;
        private readonly IBrandService brandService;
        private readonly ISellerService sellerService;

        public ClothController(IClothService _clothService, IBrandService _brandService, ISellerService _sellerService)
        {
            clothService = _clothService;
            brandService = _brandService;
            sellerService = _sellerService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllClothesQueryModel query)
        {
            var result = await clothService.All(
                query.Sorting,
                query.Category,
                query.GenderOrientation,
                query.SearchTerm,
                query.CurrentPage,
                AllClothesQueryModel.ClothesPerPage);

            query.TotalClothesCount = result.TotalClothesCount;
            query.Categories = await clothService.AllCategoriesNames();
            query.Clothes = result.Clothes;

            return View(query);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if ((await sellerService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(SellerController.Become), "Seller");
            }

            var model = new ClothAddToShopAndEditModel()
            {
                Categories = await clothService.AllCategories(),
                Brands = await clothService.AllBrands()
            };

            return View(model);
        }

        public async Task<IActionResult> Add(ClothAddToShopAndEditModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await clothService.AllCategories();
                model.Brands = await clothService.AllBrands();
                return View(model);
            }

            if ((await sellerService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(SellerController.Become), "Seller");
            }

            if (await clothService.CategoryExists(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            if (await clothService.BrandExists(model.BrandId) == false)
            {
                ModelState.AddModelError(nameof(model.BrandId), "Brand does not exists");
            }

            var sellerId = await sellerService.GetSellerId(User.Id());
            await clothService.Create(model, sellerId);

            return RedirectToAction(nameof(All), new AllClothesQueryModel()
            {
                Sorting = ClothesSorting.Newest
            });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)    
        {
            if ((await sellerService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(SellerController.Become), "Seller");
            }

            if (await clothService.IsClothAvailable(id) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var cloth = await clothService.GetClothDetails(id);
            var categoryId = await clothService.GetClothCategoryId(id);
            var brandId = await clothService.GetClothBrandId(id);

            var model = new ClothAddToShopAndEditModel()
            {
                Id = id,
                CategoryId = categoryId,
                BrandId = brandId,
                Name = cloth.Name,
                Description = cloth.Description,
                GenderOrientation = cloth.GenderOrientation,
                ImageUrl = cloth.ImageUrl,
                Price = cloth.Price,
                Quantity = cloth.Quantity,
                Categories = await clothService.AllCategories(),
                Brands = await  clothService.AllBrands()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClothAddToShopAndEditModel model)
        {
            if ((await sellerService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(SellerController.Become), "Seller");
            }

            if (await clothService.IsClothAvailable(model.Id) == false)
            {
                ModelState.AddModelError("", "Cloth does not exist");
                model.Categories = await clothService.AllCategories();
                model.Brands = await clothService.AllBrands();

                return View(model);
            }

            if (await clothService.CategoryExists(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            if (await clothService.BrandExists(model.BrandId) == false)
            {
                ModelState.AddModelError(nameof(model.BrandId), "Brand does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await clothService.AllCategories();
                model.Brands = await clothService.AllBrands();
                return View(model);
            }

            await clothService.Edit(model);

            return RedirectToAction("All");
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (await clothService.IsClothAvailable(id))
            {
                await clothService.Delete(id);
            }
            else
            {
                throw new ArgumentException("Invalid ClothId");
            }

            return RedirectToAction(nameof(All));
        }

        [AllowAnonymous]
        public IActionResult Jackets()
        {
            return RedirectToAction(nameof(All), new AllClothesQueryModel()
            {
                Category = "Jackets"
            });
        }

        [AllowAnonymous]
        public IActionResult AllFromNike()
        {
            return RedirectToAction(nameof(BrandClothes), new
            {
                id = 2
            });
        }

        [AllowAnonymous]
        public IActionResult MenClothes()
        {
            return RedirectToAction(nameof(All), new AllClothesQueryModel()
            {
                GenderOrientation = "Male"
            });
        }

        [AllowAnonymous]
        public IActionResult WomenClothes()
        {
            return RedirectToAction(nameof(All), new AllClothesQueryModel()
            {
                GenderOrientation = "Female"
            });
        }

        [AllowAnonymous]
        public async Task<IActionResult> BrandClothes(int id)
        {
           var clothes = await clothService.AllClothesByBrandId(id);
           var brandName = await brandService.GetBrandNameById(id);

           var model = new ClothesServiceBrandNameModel()
           {
               Clothes = clothes,
               BrandName = brandName
           };

           return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            if ((await sellerService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(SellerController.Become), "Seller");
            }

            var sellerId = await sellerService.GetSellerId(User.Id());
            var model = await clothService.AllClothesBySellerId(sellerId);

            return View(model);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var userId = User.Id();

            await clothService.AddClothToUsersCart(id, userId);

            return StatusCode(204);
        }

        public async Task<IActionResult> Cart()
        {
            var userId = User.Id();

            var model = new ClothesCartModel
            {
                Clothes = await clothService.UserCartClothes(User.Id())
            };
            model.TotalPrice = model.Clothes.Select(c => c.Price).Sum();

            return View(model);
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = User.Id();

            await clothService.RemoveClothFromUserCart(id, userId);

            return RedirectToAction("Cart");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (await clothService.IsClothAvailable(id) == false)
            {
                return BadRequest();
            }

            var model = await clothService.ClothDetails(id);

            return View(model);
        }
    }
}
