﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShop.Core.Contracts
{
    public interface IAppUserService
    {
        Task<bool> UserWithEmailExists(string email);
    }
}
