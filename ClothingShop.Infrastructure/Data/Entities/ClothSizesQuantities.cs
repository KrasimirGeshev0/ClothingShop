using System.ComponentModel.DataAnnotations;
using static ClothingShop.Infrastructure.Data.DataConstants.ClothSizesQuantities;

namespace ClothingShop.Infrastructure.Data.Entities
{
    public class ClothSizesQuantities
    {
        [Key]
        public int Id { get; set; }

        [Range(QuantityMin,QuantityMax)]
        public int SQuantity { get; set; }
        [Range(QuantityMin, QuantityMax)]
        public int MQuantity { get; set; }
        [Range(QuantityMin, QuantityMax)]
        public int LQuantity { get; set; }
        [Range(QuantityMin, QuantityMax)]
        public int XlQuantity { get; set; }
    }
}   
