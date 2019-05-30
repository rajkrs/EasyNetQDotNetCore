using Order.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Service.Provider
{
    public interface IOrderService
    {
        Task<PurchaseOrderResDto> CreateOrderAsync(PurchaseOrderReqDto purchaseOrderReqDto);

    }
}
    