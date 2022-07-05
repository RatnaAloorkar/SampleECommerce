using Microsoft.AspNetCore.Mvc;
using SampleECommerce.Models;
using SampleECommerce.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace SampleECommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        #region Constructor and Member Variables
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
           _productService = productService;
        }
        #endregion

        #region Get Methods
        [HttpGet("{countryId}")]
        public ActionResult<List<Product>> GetProducts(int countryId)
        {
            try
            {
                var result = _productService.GetProductsList(countryId);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
