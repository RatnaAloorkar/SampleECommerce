using Microsoft.Extensions.DependencyInjection;
using SampleECommerce.Repository.Interfaces;
using SampleECommerce.Repository.Repositories;

namespace SampleECommerce.Repository
{
    public static  class RepositoryConfigurations
    {
        public static void ConfigureSampleECommerceRepository(this IServiceCollection services )
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
        }
    }
}
