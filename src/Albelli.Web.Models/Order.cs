using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Albelli.Data;

namespace Albelli.Web.Models
{
    public class Order : IValidatableObject
    {
        public Guid OrderId { get; set; }
        public List<Product> Products { get; set; }
        public decimal RequiredBinWidth { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var productTypes = Enum.GetValues(typeof(ProductTypes)) as IEnumerable<ProductTypes>;
            var unknownProductTypes = Products.Where(x => !productTypes.Contains(x.ProductType));

            foreach (var unknownProductType in unknownProductTypes)
            {
                yield return new ValidationResult($"Unexpected ProductType value: {unknownProductType.ProductType}");
            }
        }
    }
}
