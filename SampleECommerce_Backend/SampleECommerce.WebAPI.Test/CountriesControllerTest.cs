using Moq;
using FluentAssertions;
using SampleECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SampleECommerce.Service.Interfaces;
using SampleECommerce.WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleECommerce.Test
{
    [TestClass]
    public class CountriesControllerTest
    {
        private List<Country> countries = new List<Country>() {
            new Country() { Id=1,Name="Australia", CurrencyCode="AUD", ExchangeRate=1 },
            new Country() { Id=2,Name="New Zealand", CurrencyCode="NZD", ExchangeRate=1.10 },
            new Country() { Id=3,Name="UK", CurrencyCode="GBP", ExchangeRate=0.56},
            new Country() { Id=4,Name="Canada", CurrencyCode="CAD", ExchangeRate=0.88},
            new Country() { Id=5,Name="India", CurrencyCode="INR", ExchangeRate=53.89},
        };

        [TestMethod]
        public void GetCountries_ReturnsOK_WhenResultsFound()
        {
            // Arrange
            var mockCountryService = new Mock<ICountryService>();
            mockCountryService.Setup(x => x.GetCountryList()).Returns(countries);

            var controller = new CountriesController(mockCountryService.Object);

            // Act
            var actionResult = controller.GetCountryList();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().Be(countries);
        }

        [TestMethod]
        public void GetCountries_ReturnsNotFound_WhenResultsNotFound()
        {
            // Arrange
            List<Country> countriesList = null;
            var mockCountryService = new Mock<ICountryService>();
            mockCountryService.Setup(x => x.GetCountryList()).Returns(countriesList);

            var controller = new CountriesController(mockCountryService.Object);

            // Act
            var actionResult = controller.GetCountryList();

            // Assert
            var result = actionResult.Result as NotFoundObjectResult;
            result.Should().BeNull();
        }
    }
}
