using SampleECommerce.Models;
using System.Collections.Generic;

namespace SampleECommerce.Repository.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProductsList(int countryId);
    }
}
