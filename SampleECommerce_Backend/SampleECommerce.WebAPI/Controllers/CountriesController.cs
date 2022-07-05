using System;
using SampleECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SampleECommerce.Service.Interfaces;

namespace SampleECommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        #region Constructor and Member Variables
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        #endregion

        #region Get Methods
        //NOTE: Ideally all the action methods which make database/network call internally should be using async await.
        //That feature is not used here, because in this sample application, static data is returned.
        [HttpGet("")]
        public ActionResult<List<Country>> GetCountryList()
        {
            try
            {
                var result = _countryService.GetCountryList();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
