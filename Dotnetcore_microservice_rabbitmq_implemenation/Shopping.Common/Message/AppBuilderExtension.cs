using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Shopping.Common.Message
{
    public static class AppBuilderExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appBuilder"></param>
        /// <param name="service">Topic, that define routing key.</param>
        /// <param name="assemblyType">Represent identifier of Assebmly that contains complete implementation of consumer.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseSubscribe(this IApplicationBuilder appBuilder, Shopping.Common.Enums.Service service, Type assemblyType)
        {
            var bus = appBuilder.ApplicationServices.GetService(typeof(IBus)) as IBus;
            var lifeTime = appBuilder.ApplicationServices.GetService(typeof(IApplicationLifetime)) as IApplicationLifetime;

            var assembly = assemblyType.Assembly;
            lifeTime.ApplicationStarted.Register(() =>
            {
                var subscriber = new AutoSubscriber(bus, assemblyType.Name)
                {
                    ConfigureSubscriptionConfiguration = config => config.WithTopic(service.ToString())
                };
                subscriber.Subscribe(assembly);
                subscriber.SubscribeAsync(assembly);
            });

            lifeTime.ApplicationStopped.Register(() => bus.Dispose());

            return appBuilder;
        }
    }

}
