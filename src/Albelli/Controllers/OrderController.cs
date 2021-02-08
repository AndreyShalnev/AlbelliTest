using System;
using Albelli.BusinessLogic.Interfaces;
using Albelli.Data;
using Albelli.Data.Access;
using Albelli.Web.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Albelli.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderMapper OrderMapper { get; }
        private IOrderService OrderService { get; }
        private IGuidEntityRepository<Order> OrderRepository { get; }

        public OrderController(IOrderMapper orderMapper, IOrderService orderService, IGuidEntityRepository<Order> orderRepository)
        {
            OrderMapper = orderMapper;
            OrderService = orderService;
            OrderRepository = orderRepository;
        }

        [HttpGet("{guid}")]
        public IActionResult Get(Guid guid)
        {
            var order = OrderRepository.GetByGuid(guid);
            
            if (order == null)
                return NotFound();

            return Ok(OrderMapper.ToWebModel(order));
        }

        [HttpPost]
        public ActionResult<Models.Order> Post([FromBody] Models.Order webOrder)
        {
            var domainOrder = OrderMapper.ToDomainModel(webOrder);
            domainOrder = OrderService.Create(domainOrder);
            return OrderMapper.ToWebModel(domainOrder);
        }
    }
}
