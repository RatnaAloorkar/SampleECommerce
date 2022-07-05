namespace SampleECommerce.Service.Interfaces
{
    public interface IShippingRulesService
    {
        public double GetShippingPrice(float orderSubTotal);
    }
}
