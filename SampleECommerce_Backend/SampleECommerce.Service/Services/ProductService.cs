using SampleECommerce.Models;
using SampleECommerce.Repository.Interfaces;
using SampleECommerce.Service.Interfaces;
using System.Collections.Generic;

namespace SampleECommerce.Service.Services
{
    public class ProductService : IProductService
    {
        #region Constructor and Member Variables
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
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
            return _productRepository.GetProductsList(countryId);
        }
        #endregion
    }
}
