using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Order.Service.Models;
using Order.Service.Provider;
using Shopping.Common.EasyNetQ;

namespace Order.Service.Controllers
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


        // GET api/values
        [HttpGet]
        public async Task<PurchaseOrderResDto> GetAsync()
        {
            return await _orderService.CreateOrderAsync(new PurchaseOrderReqDto { OrderId = Guid.NewGuid()});
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public Task<PurchaseOrderResDto> CreateOrderAsync([FromBody] PurchaseOrderReqDto purchaseOrderReqDto)
        {
            return _orderService.CreateOrderAsync(purchaseOrderReqDto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
