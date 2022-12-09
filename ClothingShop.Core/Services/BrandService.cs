using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingShop.Core.Contracts;
using ClothingShop.Core.Models.BrandModels;
using ClothingShop.Infrastructure.Data.Common;
using ClothingShop.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Core.Services
{
    public class BrandService : IBrandService
    {
        private readonly IRepository repo;

        public BrandService(IRepository _repository)
        {
            repo = _repository;
        }
        public async Task<IEnumerable<AllBrandsModel>> All(string? searchTerm = null)
        {
            var result = new List<AllBrandsModel>();
            var brands = repo.AllReadonly<Brand>().Where(b => b.IsAvailable);

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                brands = brands
                    .Where(c => EF.Functions.Like(c.Name.ToLower(), searchTerm));

            }

            return await brands
                .Select(b => new AllBrandsModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Logo = b.Logo,
                })
                .ToListAsync();
        }

        public async Task<string> GetBrandNameById(int brandId)
        {
            return (await repo.GetByIdAsync<Brand>(brandId)).Name;
        }

        public async Task Delete(int brandId)
        {
            var brand = await repo.All<Brand>()
                .FirstOrDefaultAsync(b => b.Id == brandId);

            if (brand != null)
            {
                brand.IsAvailable = false;
            }

            await repo.SaveChangesAsync();
        }

        public async Task<bool> IsBrandAvailable(int brandId)
        {
            if (await repo.AllReadonly<Brand>().AnyAsync(b => b.Id == brandId))
            {
                if (await repo.AllReadonly<Brand>().Where(b => b.Id == brandId).Select(c => c.IsAvailable).FirstOrDefaultAsync())
                {
                    return true;
                }
            }

            return false;

        }

        public async Task Create(CreateBrandModel model)
        {
            var brand = new Brand()
            {
                Name = model.Name,
                Logo = model.Logo,
            };

           await repo.AddAsync(brand);
           await repo.SaveChangesAsync();
        }

        public async Task<int> BrandsCount()
        {
           return await repo.All<Brand>().CountAsync();
        }
    }
}
