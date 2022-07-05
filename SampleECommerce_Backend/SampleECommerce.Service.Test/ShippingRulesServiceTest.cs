using FluentAssertions;
using SampleECommerce.Service.Services;
using SampleECommerce.Service.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleECommerce.Test
{
    [TestClass]
    public class ShippingRulesServiceTest
    {
        [TestMethod]
        public void WhenOrderTotalIsMoreThan50_ShippingPrice_ShouldBe20()
        {
            //Arrange
            var orderTotal = 51;
            var expectedShipping = 20;
            //Act
            IShippingRulesService service = new ShippingRulesService();
            var actualShipping = service.GetShippingPrice(orderTotal);
            //Assert
            Assert.AreEqual(actualShipping, expectedShipping);
            actualShipping.Should().Be(expectedShipping);
        }

        [TestMethod]
        public void WhenOrderTotalIs50OrLess_ShippingPrice_ShouldBe10()
        {
            //Arrange
            var orderTotal = 50;
            var expectedShipping = 10;
            //Act
            IShippingRulesService service = new ShippingRulesService();
            var actualShipping = service.GetShippingPrice(orderTotal);
            //Assert
            actualShipping.Should().Be(expectedShipping);
        }

        [TestMethod]
        public void WhenOrderTotalIs0_ShippingPrice_ShouldBe0()
        {
            //Arrange
            var orderTotal = 0;
            var expectedShipping = 0;
            //Act
            IShippingRulesService service = new ShippingRulesService();
            var actualShippingCost = service.GetShippingPrice(orderTotal);
            //Assert
            actualShippingCost.Should().Be(expectedShipping);
        }
    }
}
