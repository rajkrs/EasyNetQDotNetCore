using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Common.EasyNetQ
{
    public class BusSubscriber : IBusSubscriber
    {
        private readonly IBus _bus;

        public BusSubscriber(IBus bus) {
            _bus = bus;
        }
        public async Task SubscribeAsync<TMessage>(TMessage @message) where TMessage : class
            => await _bus.PublishAsync(@message);
        
    }
}
