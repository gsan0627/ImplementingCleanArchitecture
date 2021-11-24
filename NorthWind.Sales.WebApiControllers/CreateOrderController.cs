using Microsoft.AspNetCore.Mvc;
using NorthWind.Sales.Controllers;
using NorthWind.Sales.DTOs.CreateOrder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.WebApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateOrderController : ControllerBase
    {
        readonly ICreateOrderController _controller;
        public CreateOrderController(ICreateOrderController controller)
        {
            _controller = controller;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO order)
        {
            var createOrderViewModel =
                await _controller.CreateOrder(order);
            return Ok(createOrderViewModel.OrderId);
        }

    }
}
