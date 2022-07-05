using SampleECommerce.Models;
using System.Collections.Generic;

namespace SampleECommerce.Repository.Interfaces
{
    public interface ICountryRepository
    {   
        List<Country> GetCountryList();
        double GetExchangeRate(int countryId);
    }
}
