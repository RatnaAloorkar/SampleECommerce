using SampleECommerce.Models;
using SampleECommerce.Repository.Interfaces;
using System;

namespace SampleECommerce.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        #region Get Methods
        public Order GetOrder(Guid orderNumber)
        {
            //Fetch order from database with the given order number and return
            return new Order();
        }
        #endregion

        #region Save Methods
        /// <summary>
        /// Place order in database
        /// </summary>
        /// <param name="order">Order Details</param>
        /// <returns>Bool representing if the order was successfully placed</returns>
        public Guid PlaceOrder(Order order)
        {
            //Save order in database. If it is successful, set orderSuccessful to true.
            var orderSuccessful = true;
            if (orderSuccessful)
                return Guid.NewGuid();
            else
                return Guid.Empty;
        }
        #endregion
    }
}
