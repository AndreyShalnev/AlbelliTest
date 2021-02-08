using System;
using Albelli.BusinessLogic.Interfaces;
using Albelli.Data;
using Albelli.Data.Access;

namespace Albelli.BusinessLogic
{
    public class OrderService : IOrderService
    {
        private IGuidEntityRepository<Order> OrderRepository { get; }
        private IOrderCalculator OrderCalculator { get; }

        public OrderService(IOrderCalculator orderCalculator, IGuidEntityRepository<Order> orderRepository)
        {
            OrderCalculator = orderCalculator;
            OrderRepository = orderRepository;
        }

        public Order Create(Order order)
        {
            order.Guid = Guid.NewGuid();
            order.PackageWidth = OrderCalculator.GetPackageWidth(order);

            return OrderRepository.Add(order);
        }
    }
}
