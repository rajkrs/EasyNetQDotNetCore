using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Shipping.Service.Models;

namespace Shipping.Service.Provider
{
    public class ShippingService : IShippingService
    {
        public Task<bool> CreateShippingRequestAsync(ShippingReqDto shippingReqDto)
        {
            return Task.FromResult(true);
        }

        public Task<bool> RequestTopackAsync(RequestToPackDto purchaseOrderReqDto)
        {
            return Task.FromResult(true);
        }
    }
}
