using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRExample.Hubs;
using SignalRExample.Models;

namespace SignalRExample.Controllers
{
    public class OrderController : Controller
    {
        private readonly IHubContext<OrderHub> _orderHub;
        public OrderController(IHubContext<OrderHub> orderHub)
        {

            _orderHub = orderHub;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("[Controller]")]
        [HttpPost]
        public IActionResult Order([FromBody] Order order)
        {
            //same bussines rules
            _orderHub.Clients.All.SendAsync("lastOrder", order);

            return Accepted();
        }
    }
}
