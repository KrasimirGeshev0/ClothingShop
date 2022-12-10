using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingShop.Core.Contracts;
using ClothingShop.Infrastructure.Data.Common;
using ClothingShop.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Core.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IRepository repo;

        public AppUserService(IRepository _repository)
        {
            repo = _repository;
        }
        public async Task<bool> UserWithEmailExists(string email)
        {
           return await repo.AllReadonly<ApplicationUser>().AnyAsync(u => u.Email == email);
        }
    }
}
