using Shopping.Common.Message;

using consumer = Shipping.Service.Models;

namespace Order.Service.Publisher.Shipping
{
    [MessageForwardedTo(Shopping.Common.Enums.Service.Shipping)] //Topic
    public class ShippingReqDto : consumer.ShippingReqDto
    {

    }
}
