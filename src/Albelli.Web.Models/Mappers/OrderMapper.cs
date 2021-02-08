using System.Linq;
using Albelli.Data;
using Albelli.Data.Access;
using Albelli.Web.Models.Interfaces;

namespace Albelli.Web.Models.Mappers
{
    public class OrderMapper : IOrderMapper
    {
        private IRepository<ProductType> ProductTypeRepository { get; set; }

        public OrderMapper(IRepository<ProductType> productTypeRepository)
        {
            ProductTypeRepository = productTypeRepository;
        }

        public Data.Order ToDomainModel(Models.Order webOrder)
        {
            var productTypes = ProductTypeRepository.GetAll();

            return new Data.Order
            {
                Products = webOrder.Products.Select(x => new Data.Product
                {
                    ProductType = productTypes.FirstOrDefault(y => y.Type == x.ProductType),
                    Quantity = x.Quantity
                }).ToList()
            };
        }

        public Models.Order ToWebModel(Data.Order order)
        {
            return new Models.Order
            {
                OrderId = order.Guid,
                Products = order.Products.Select(x => new Models.Product
                {
                    Quantity = x.Quantity,
                    ProductType = x.ProductType.Type
                }).ToList(),
                RequiredBinWidth = order.PackageWidth
            };
        }
    }
}
