using SampleECommerce.Models;
using System.Collections.Generic;

namespace SampleECommerce.Service.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProductsList(int countryId);
    }
}
