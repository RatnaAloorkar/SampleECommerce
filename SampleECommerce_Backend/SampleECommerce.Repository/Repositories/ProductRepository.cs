using SampleECommerce.Models;
using SampleECommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleECommerce.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Constructor and Member Variables 
        private List<Product> products = new List<Product>()
        {
            new Product() { Id=1,Name="Samsung Galaxy A12 128GB",BaseUnitPrice=299,SellingPrice=299 },
            new Product() { Id=2,Name="Apple iPhone 8 Red 64GB",BaseUnitPrice=269, SellingPrice=269},
            new Product() { Id=3,Name="Apple iPhone 8 Red 64GB",BaseUnitPrice=412, SellingPrice = 412},
            new Product() { Id=4,Name="OnePlus Nord CE 5G ",BaseUnitPrice=478, SellingPrice = 478},
            new Product() { Id=5,Name="Nokia 16QENL21A07 225 4G",BaseUnitPrice=75, SellingPrice = 75}
        };

        private readonly ICountryRepository _countryRepository;

        public ProductRepository(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        #endregion

        #region Get Methods
        /// <summary>
        /// Gets the list of products with their selling prices in the currency of the country provided
        /// </summary>
        /// <param name="countryId">Id of a country to calculate products selling prices</param>
        /// <returns>List of products</returns>
        public List<Product> GetProductsList(int countryId)
        {
            var exchangeRate = _countryRepository.GetExchangeRate(countryId);
            var productList = from product in products
                           select new Product
                           {
                               Id = product.Id,
                               Name = product.Name,
                               BaseUnitPrice = product.BaseUnitPrice,
                               SellingPrice = Math.Floor(product.BaseUnitPrice * exchangeRate)
                           };
            return productList.ToList<Product>();
        }
        #endregion
    }
}
