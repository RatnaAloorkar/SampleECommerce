using Moq;
using System;
using SampleECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SampleECommerce.Service.Interfaces;
using SampleECommerce.WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleECommerce.Test
{
    [TestClass]
    public class OrdersControllerTest
    {
        private List<Product> products = new List<Product>()
        {
            new Product() { Id=1,Name="Samsung Galaxy A12 128GB",BaseUnitPrice=299,SellingPrice=299 },
            new Product() { Id=2,Name="Apple iPhone 8 Red 64GB",BaseUnitPrice=269, SellingPrice=269},
        };

        [TestMethod]
        public void Checkout_ReturnsAccepted_WhenModelStateIsValid_AndOrderIsCreated()
        {
            // Arrange
            Order order = new Order
            {
                Products = products,
                CountryId = 1,
                ShippingCost = 20,
                SubTotal = 568,
                Total = 588
            };

            var mockOrderService = new Mock<IOrderService>();
            mockOrderService.Setup(x => x.PlaceOrder(order)).Returns(Guid.NewGuid());
            var mockShippingRulesService = new Mock<IShippingRulesService>();
            var controller = new OrdersController(mockOrderService.Object, mockShippingRulesService.Object);

            // Act
            var actionResult = controller.Checkout(order);
            var acceptedResult = actionResult as CreatedAtActionResult;

            // Assert
            Assert.IsNotNull(acceptedResult);
        }

        [TestMethod]
        public void Checkout_ReturnsUnprocessableEntity_WhenModelStateIsValid_AndOrderIsNotCreated()
        {
            // Arrange
            Order order = new Order
            {
                Products = products,
                CountryId = 1,
                ShippingCost = 20,
                SubTotal = 568,
                Total = 588
            };

            var mockOrderService = new Mock<IOrderService>();
            mockOrderService.Setup(x => x.PlaceOrder(order)).Returns(Guid.Empty);
            var mockShippingRulesService = new Mock<IShippingRulesService>();
            var controller = new OrdersController(mockOrderService.Object, mockShippingRulesService.Object);

            // Act
            var actionResult = controller.Checkout(order);
            var unprocessableEntityResult = actionResult as UnprocessableEntityObjectResult;

            // Assert
            Assert.IsNotNull(unprocessableEntityResult);
        }

        [TestMethod]
        public void Checkout_ReturnsBadRequest_WhenModelStateIsInValid()
        {
            // Arrange
            Order order = new Order
            {
                CountryId = 1,
                ShippingCost = 20,
                SubTotal = 568,
                Total = 588
            };

            var mockOrderService = new Mock<IOrderService>();
            var mockShippingRulesService = new Mock<IShippingRulesService>();
            var controller = new OrdersController(mockOrderService.Object, mockShippingRulesService.Object);
            controller.ModelState.AddModelError("Products", "Required");

            // Act
            var actionResult = controller.Checkout(order);
            var badRequestResult = actionResult as BadRequestResult;

            // Assert
            Assert.IsNotNull(badRequestResult);
        }

    }
}
