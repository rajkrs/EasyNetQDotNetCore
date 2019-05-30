using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shipping.Service.Consumer;
using Shipping.Service.Provider;
using Shopping.Common.EasyNetQ;
using Shopping.Common.Message;
using consumer = Shipping.Service.Consumer;

namespace Shipping.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton(RabbitHutch.CreateBus(Configuration["MQ:Dev"]));

            services.AddSingleton<IBusPublisher, BusPublisher>();

            services.AddSingleton<IShippingService, ShippingService>();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();



            app.UseSubscribe(
                Shopping.Common.Enums.Service.Shipping, //Subscribe by topic
                typeof(ShippingConsumer)//Create subscription id, denote Assembly of consumer implementation.
                ) ;


        }
    }
}
