using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Common.EasyNetQ
{
    public interface IBusSubscriber 
    {
        Task SubscribeAsync<TMessage>(TMessage @event) where TMessage : class;

    }
}
