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
    public class ProductsControllerTest
    {
        private List<Product> products = new List<Product>()
        {
            new Product() { Id=1,Name="Samsung Galaxy A12 128GB",BaseUnitPrice=299,SellingPrice=299 },
            new Product() { Id=2,Name="Apple iPhone 8 Red 64GB",BaseUnitPrice=269, SellingPrice=269},
            new Product() { Id=3,Name="Apple iPhone 8 Red 64GB",BaseUnitPrice=412, SellingPrice = 412},
            new Product() { Id=4,Name="OnePlus Nord CE 5G ",BaseUnitPrice=478, SellingPrice = 478},
            new Product() { Id=5,Name="Nokia 16QENL21A07 225 4G",BaseUnitPrice=75, SellingPrice = 75}
        };

        [TestMethod]
        public void GetProducts_ReturnsOK_WhenResultsFound()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetProductsList(1)).Returns(products);

            var controller = new ProductsController(mockProductService.Object);

            // Act
            var actionResult = controller.GetProducts(1);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().Be(products);
        }

        [TestMethod]
        public void GetProducts_ReturnsNotFound_WhenResultsNotFound()
        {
            // Arrange
            List<Product> productsList = null;
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetProductsList(1)).Returns(productsList);

            var controller = new ProductsController(mockProductService.Object);

            // Act
            var actionResult = controller.GetProducts(1);

            // Assert
            var result = actionResult.Result as NotFoundObjectResult;
            result.Should().BeNull();
        }
    }
}
