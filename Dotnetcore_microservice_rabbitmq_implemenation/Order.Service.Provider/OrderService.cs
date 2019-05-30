using System.Threading.Tasks;
using Order.Service.Models;
using Order.Service.Publisher.Shipping;
using Shopping.Common.EasyNetQ;

namespace Order.Service.Provider
{
    public class OrderService : IOrderService
    {
        private readonly IBusPublisher _busPublisher;
        public OrderService(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }
        public async Task<PurchaseOrderResDto> CreateOrderAsync(PurchaseOrderReqDto purchaseOrderReqDto)
        {
            await _busPublisher.PublishAsync(new ShippingReqDto { OrderId = purchaseOrderReqDto.OrderId });
            return new PurchaseOrderResDto { OrderId = purchaseOrderReqDto.OrderId, Status = "Order Accepted" };
        }
    }
}
