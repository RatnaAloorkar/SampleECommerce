using SampleECommerce.Models;
using System;
using System.Collections.Generic;

namespace SampleECommerce.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Order GetOrder(Guid orderNumber);
        Guid PlaceOrder(Order order);
    }
}
