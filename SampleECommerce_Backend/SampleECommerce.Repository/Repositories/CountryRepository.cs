using SampleECommerce.Models;
using SampleECommerce.Repository.Interfaces;
using System.Collections.Generic;

namespace SampleECommerce.Repository.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        #region Member Variables
        private List<Country> countries = new List<Country>() {
            new Country() { Id=1,Name="Australia", CurrencyCode="AUD", ExchangeRate=1 },
            new Country() { Id=2,Name="New Zealand", CurrencyCode="NZD", ExchangeRate=1.10 },
            new Country() { Id=3,Name="UK", CurrencyCode="GBP", ExchangeRate=0.56},
            new Country() { Id=4,Name="Canada", CurrencyCode="CAD", ExchangeRate=0.88},
            new Country() { Id=5,Name="India", CurrencyCode="INR", ExchangeRate=53.89},
        };
        #endregion

        #region Get Methods
        /// <summary>
        /// Gets the list of all countries where products can be sold
        /// </summary>
        /// <returns>List of countries</returns>
        public List<Country> GetCountryList()
        {
            return countries;
        }

        /// <summary>
        /// Gets the exchange rate for the country provided
        /// </summary>
        /// <param name="countryId">Country Id</param>
        /// <returns>Exchange Rate</returns>
        public double GetExchangeRate(int countryId)
        {
            var country = countries.Find(c => c.Id == countryId);
            return country != null ? country.ExchangeRate : 1;
        }
        #endregion
    }
}
