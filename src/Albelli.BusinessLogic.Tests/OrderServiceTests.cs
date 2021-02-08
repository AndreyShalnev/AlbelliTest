using System;
using Albelli.BusinessLogic.Interfaces;
using Albelli.Data;
using Albelli.Data.Access;
using NUnit.Framework;
using Moq;

namespace Albelli.BusinessLogic.Tests
{
    public class OrderServiceTests
    {
        private decimal _packageWidth = 10;

        private OrderService Service;
        private Mock<IGuidEntityRepository<Order>> OrderRepository;
        private Mock<IOrderCalculator> OrderCalculator;

        [SetUp]
        public void Setup()
        {
            OrderCalculator = new Mock<IOrderCalculator>();
            
            OrderRepository = new Mock<IGuidEntityRepository<Order>>();
            OrderRepository.Setup(r => r.Add(It.IsAny<Order>())).Returns<Order>(x => x);

            Service = new OrderService(OrderCalculator.Object, OrderRepository.Object);
        }

        [Test]
        public void Create_ShouldAddOrderIntoRepository()
        {
            var order = new Order();

            Service.Create(order);

            OrderRepository.Verify(x => x.Add(It.IsAny<Order>()));
        }

        [Test]
        public void Create_ShouldFillInGuidAndPackageWidth()
        {
            OrderCalculator.Setup(x => x.GetPackageWidth(It.IsAny<Order>())).Returns(_packageWidth);
            var order = new Order();

            var result = Service.Create(order);

            Assert.AreEqual(_packageWidth, result.PackageWidth);
            Assert.AreNotEqual(Guid.Empty, result.Guid);
        }
    }
}
