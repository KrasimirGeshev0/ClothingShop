using System.ComponentModel.DataAnnotations;
using ClothingShop.Core.Models.BrandModels;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Models.Brands
{
    public class AllBrandsQueryModel 
    {
        [Display(Name = "")]
        public string? SearchTerm { get; set; }

        public IEnumerable<AllBrandsModel> Brands { get; set; } = new List<AllBrandsModel>();
    }
}
