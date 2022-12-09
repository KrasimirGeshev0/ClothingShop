﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingShop.Core.Models.BrandModels;

namespace ClothingShop.Core.Contracts
{
    public interface IBrandService
    {
        Task<IEnumerable<AllBrandsModel>> All(string? searchTerm = null);

        Task<string> GetBrandNameById(int brandId);

        Task Delete(int brandId);

        Task<bool> IsBrandAvailable(int brandId);

        Task Create(CreateBrandModel model);

        Task<int> BrandsCount();
    }
}   
        