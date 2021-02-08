using System.Collections.Generic;

namespace Albelli.Data.Access.Mocks
{
    public class ProductTypeRepositoryMock : RepositoryMock<ProductType>
    {
        public ProductTypeRepositoryMock()
        {
            Storage = new List<ProductType>
            {
                new ProductType { Id = 1, PackageWidth = 19, ItemsInPackage = 1},
                new ProductType { Id = 2, PackageWidth = 10, ItemsInPackage = 1},
                new ProductType { Id = 3, PackageWidth = 16, ItemsInPackage = 1},
                new ProductType { Id = 4, PackageWidth = 4.7M, ItemsInPackage = 1},
                new ProductType { Id = 5, PackageWidth = 94, ItemsInPackage = 4},
            };
        }
    }
}
