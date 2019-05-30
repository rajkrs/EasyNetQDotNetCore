using System;

namespace Order.Service.Models
{
    public class PurchaseOrderResDto
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }

    }
}
