using Challenge.ApplicationService;
using Challenge.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            return await _orderService.GetOrder(id);
        }

        [Authorize]
        [HttpPost]
        public async Task Post([FromBody] Order order)
        {
            await _orderService.CreateOrderAsync(order);
        }

    }
}
