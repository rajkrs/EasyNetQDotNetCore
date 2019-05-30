using EasyNetQ;
using Shopping.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Common.EasyNetQ
{
    public class BusPublisher : IBusPublisher
    {
        private readonly IBus _bus;

        public BusPublisher(IBus bus)
        {
            _bus = bus;
        }

        public async Task PublishAsync<TMessage>(TMessage @message) where TMessage : class
        {
            var consumerService = @message.GetType().GetCustomAttributes(typeof(MessageForwardedToAttribute),true).FirstOrDefault() as MessageForwardedToAttribute;
            await _bus.PublishAsync(@message, consumerService.Service);
        }
    }
}
