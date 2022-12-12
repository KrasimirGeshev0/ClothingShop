using System.Text;
using ClothingShop.Core.Contracts;

namespace ClothingShop.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IClothModel cloth)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(cloth.Name.Replace(" ", "-"));
            sb.Append("-");

            return sb.ToString();
        }
    }
}
