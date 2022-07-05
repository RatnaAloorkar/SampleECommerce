using System;
using SampleECommerce.Models;
using SampleECommerce.Repository.Interfaces;
using SampleECommerce.Service.Interfaces;

namespace SampleECommerce.Service.Services
{
    public class OrderService : IOrderService
    {
        #region Constructor and Member Variables
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        #endregion

        #region Get Methods
        public Order GetOrder(Guid orderNumber)
        {
            return _orderRepository.GetOrder(orderNumber);
        }
        #endregion

        #region Post Methods
        /// <summary>
        /// Place order in database
        /// </summary>
        /// <param name="order">Order Details</param>
        /// <returns>Bool representing if the order was successfully placed</returns>
        public Guid PlaceOrder(Order order)
        {
            return _orderRepository.PlaceOrder(order);
        }
        #endregion
    }
}
