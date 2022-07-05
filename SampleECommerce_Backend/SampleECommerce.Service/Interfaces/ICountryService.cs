using SampleECommerce.Models;
using System.Collections.Generic;

namespace SampleECommerce.Service.Interfaces
{
    public interface ICountryService
    {
        List<Country> GetCountryList();
        double GetExchangeRate(int countryId);
    }
}
