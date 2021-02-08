using Albelli.Data;
using System.Linq;
using Albelli.BusinessLogic.Interfaces;

namespace Albelli.BusinessLogic
{
    public class OrderCalculator : IOrderCalculator
    {
        public decimal GetPackageWidth(Order order)
        {
            decimal packageWidth = 0;

            // I use GroupBy here because I expect order with different products of same type. That's why I'm using groupby to avoid wasting of PackageWidth 
            foreach (var uniqueProducts in order.Products.GroupBy(i => i.ProductType.Type))
            {
                var quantity = uniqueProducts.Sum(i => i.Quantity);
                var productType = uniqueProducts.FirstOrDefault().ProductType;

                if (productType.ItemsInPackage == 1)
                {
                    packageWidth += productType.PackageWidth * quantity;
                }
                else
                {
                    var fullPackageLines = quantity / productType.ItemsInPackage;

                    if (quantity % productType.ItemsInPackage != 0)
                    {
                        fullPackageLines++;
                    }

                    packageWidth += productType.PackageWidth * fullPackageLines;
                }
            }

            return packageWidth;
        }
    }
}
