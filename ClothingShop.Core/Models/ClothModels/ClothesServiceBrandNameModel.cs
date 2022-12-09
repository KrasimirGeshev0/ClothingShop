using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShop.Core.Models.ClothModels
{
    public class ClothesServiceBrandNameModel
    {
        public string BrandName { get; set; } = null!;

        public IEnumerable<ClothesServiceModel> Clothes { get; set; } = Enumerable.Empty<ClothesServiceModel>();
    }
}
