using System.Collections.Generic;
using System.Linq;
using Albelli.Data;
using NUnit.Framework;

namespace Albelli.BusinessLogic.Tests
{
    public class OrderCalculatorTests
    {
        private OrderCalculator Calculator;
        private readonly List<ProductType> ProductTypeValues = new List<ProductType>
        {
            new ProductType { Id = (int)ProductTypes.Calendar, PackageWidth = 10, ItemsInPackage = 1},
            new ProductType { Id = (int)ProductTypes.Mug,      PackageWidth = 94, ItemsInPackage = 4 },
        };

        [SetUp]
        public void Setup()
        {
            Calculator = new OrderCalculator();
        }

        [Test]
        [TestCase(ProductTypes.Calendar, 10)]
        [TestCase(ProductTypes.Mug, 94)]
        public void GetPackageWidth_ShouldReturnPackageWidth_WhenOrderContainOneProductWithOneElement(ProductTypes productType, decimal expectedPackageWidth)
        {
            var order = GetOrder(productType, 1);

            var packageWidth = Calculator.GetPackageWidth(order);

            Assert.AreEqual(expectedPackageWidth, packageWidth);
        }

        [Test]
        [TestCase(ProductTypes.Calendar, 2, 10 * 2)]
        [TestCase(ProductTypes.Calendar, 3, 10 * 3)]
        [TestCase(ProductTypes.Calendar, 4, 10 * 4)]
        public void GetPackageWidth_ShouldReturnPackageWidthMultipliedByQuantity_WhenProductHasOneItemInPackage(ProductTypes productType, int quantity, decimal expectedPackageWidth)
        {
            var order = GetOrder(productType, quantity);

            var packageWidth = Calculator.GetPackageWidth(order);

            Assert.AreEqual(expectedPackageWidth, packageWidth);
        }

        [Test]
        [TestCase(ProductTypes.Mug, 2, 94)]
        [TestCase(ProductTypes.Mug, 3, 94)]
        [TestCase(ProductTypes.Mug, 4, 94)]
        [TestCase(ProductTypes.Mug, 5, 94 * 2)]
        public void GetPackageWidth_ShouldGroupProductItemsInOneStack_WhenProductHasMoreThanOneItemInPackage(ProductTypes productType, int quantity, decimal expectedPackageWidth)
        {
            var order = GetOrder(productType, quantity);

            var packageWidth = Calculator.GetPackageWidth(order);

            Assert.AreEqual(expectedPackageWidth, packageWidth);
        }

        [Test]
        [TestCase(1, 1, 94)]
        [TestCase(1, 2, 94)]
        [TestCase(2, 2, 94)]
        [TestCase(3, 2, 94 * 2)]
        public void GetPackageWidth_ShouldGroupSameTypeProductsInOneStack_WhenProductHasMoreThanOneItemInPackage(int quantity1, int quantity2, decimal expectedPackageWidth)
        {
            var productType = ProductTypes.Mug;
            var order = new Order
            {
                Products = new List<Product>
                {
                    GetProduct(productType, quantity1),
                    GetProduct(productType, quantity2)
                }
            };

            var packageWidth = Calculator.GetPackageWidth(order);

            Assert.AreEqual(expectedPackageWidth, packageWidth);
        }

        private Order GetOrder(ProductTypes productType, int quantity)
        {
            return new Order
            {
                Products = new List<Product>
                {
                    GetProduct(productType, quantity)
                }
            };
        }

        private Product GetProduct(ProductTypes productType, int quantity)
        {
            return new Product
            {
                Quantity = quantity,
                ProductType = ProductTypeValues.First(i => i.Type == productType)
            };
        }
    }
}