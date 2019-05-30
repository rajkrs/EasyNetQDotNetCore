using Shipping.Service.Models;
using System.Threading.Tasks;

namespace Shipping.Service.Provider
{
    public interface IShippingService
    {
        Task<bool> CreateShippingRequestAsync(ShippingReqDto shippingReqDto);
        Task<bool> RequestTopackAsync(RequestToPackDto requestToPackDto);
    }

}
