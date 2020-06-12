using System;
using System.Web.Mvc;
using GroceryDelivery.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryDelivery.Tests.Controllers
{
    [TestClass]
    public class MapControllerTest
    {
            [TestMethod]
            public void TestgetRequestUrl()
            {
                // Arange
                MapController controller = new MapController();
                string address = "Test Street 23/7";
                string expectedUrl = "https://maps.google.com/maps/api/geocode/xml?address=Test Street 23/7&sensor=false&key=AIzaSyAz1BRGW3DxpKbmSKAXe5hMKici_1VUvAQ";

                // Act

                var result = controller.getRequestUrl(address);

                //Assert

                Assert.AreEqual(expectedUrl, result);
            }

        [TestMethod]
        public void TestGetDistance()
        {
            // Arange

            MapController controller = new MapController();

            // Act

            var result = controller.GetDistance((float)51.63328, (float)15.1254072, (float)51.93567, (float)15.5056419);

            // Assert
            Assert.AreEqual(42.598865677090807,result);

        }

        [TestMethod]
        public void TesttoRadians()
        {
            // Arange

            MapController controller = new MapController();

            // Act

            var result = controller.toRadians(180);

            // Assert

            Assert.AreEqual(Math.PI, result);
        }
    }
}

