using System;
using SampleECommerce.Models;

namespace SampleECommerce.Service.Interfaces
{
    public interface IOrderService
    {
        Order GetOrder(Guid orderNumber);
        Guid PlaceOrder(Order order);
    }
}
