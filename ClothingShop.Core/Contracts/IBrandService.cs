using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingShop.Core.Models.BrandModels;

namespace ClothingShop.Core.Contracts
{
    public interface IBrandService
    {
        Task<IEnumerable<AllBrandsModel>> All(string? searchTerm = null,
            int currentPage = 1, int brandsPerPage = 1);

        Task<string> GetBrandNameById(int brandId);

        Task Delete(int brandId);

        Task<bool> IsBrandAvailable(int brandId);
    }
}   
        