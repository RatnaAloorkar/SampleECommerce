using SampleECommerce.Models;
using SampleECommerce.Repository.Interfaces;
using SampleECommerce.Service.Interfaces;
using System.Collections.Generic;

namespace SampleECommerce.Service.Services
{
    public class CountryService : ICountryService
    {
        #region Constructor and Member Variables
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        #endregion

        #region Get Methods
        /// <summary>
        /// Gets the list of all countries where products can be sold
        /// </summary>
        /// <returns>List of countries</returns>
        public List<Country> GetCountryList()
        {
            return _countryRepository.GetCountryList();
        }

        /// <summary>
        /// Gets the exchange rate for the country provided
        /// </summary>
        /// <param name="countryId">Country Id</param>
        /// <returns>Exchange Rate</returns>
        public double GetExchangeRate(int countryId)
        {
            return _countryRepository.GetExchangeRate(countryId);
        }
        #endregion
    }
}
