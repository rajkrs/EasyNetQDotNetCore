using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Order.Service.Publisher.Shipping;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Shipping.Service.Provider;

namespace Shipping.Service.Consumer
{
    public class ShippingReqConsumer : IConsumeAsync<ShippingReqDto>
    {

        [AutoSubscriberConsumer(SubscriptionId = "ShippingConsumer.CreateShippingRequestAsync")]
        public Task ConsumeAsync(ShippingReqDto message)
        {
            //var shippingService = DependencyResolver.Current.GetService<IShippingService>();
            //shippingService.CreateShippingRequestAsync(message);
            return Task.CompletedTask;
        }

    }
}
