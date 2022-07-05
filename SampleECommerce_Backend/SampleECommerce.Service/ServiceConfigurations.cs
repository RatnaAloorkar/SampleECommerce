using SampleECommerce.Repository;
using Microsoft.Extensions.DependencyInjection;
using SampleECommerce.Service.Interfaces;
using SampleECommerce.Service.Services;

namespace SampleECommerce.Service
{
    public static class ServiceConfigurations
    {
        public static void ConfigureSampleECommerceService(this IServiceCollection services)
        {
            services.ConfigureSampleECommerceRepository();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IShippingRulesService, ShippingRulesService>();
        }
    }
}
