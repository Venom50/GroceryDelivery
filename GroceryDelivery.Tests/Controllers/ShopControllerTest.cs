using System;
using System.Web.Mvc;
using GroceryDelivery.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryDelivery.Tests.Controllers
{
    [TestClass]
    public class ShopControllerTest
    {
        [TestMethod]
        public void TestSumUmpRedirectToAction()
        {
            // Arange

            ShopController controller = new ShopController();

            // Act

            var result = controller.SumUp() as RedirectToRouteResult;

            // Assert

            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
        }
    }
}
