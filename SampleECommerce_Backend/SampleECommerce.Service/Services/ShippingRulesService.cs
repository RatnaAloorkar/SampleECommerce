using SampleECommerce.Service.Interfaces;

namespace SampleECommerce.Service.Services
{
    public class ShippingRulesService : IShippingRulesService
    {
        #region Get Methods
        public double GetShippingPrice(float subTotal)
        {
            var baseShippingPrice = 0;
        
            if (subTotal > 0 && subTotal <= 50)
            {
                baseShippingPrice = 10;
            }
            else if (subTotal > 50)
            {
                baseShippingPrice = 20;

            }

            return baseShippingPrice;
        }
        #endregion
    }
}
