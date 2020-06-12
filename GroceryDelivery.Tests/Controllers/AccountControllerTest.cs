using System;
using System.Web.Mvc;
using GroceryDelivery.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryDelivery.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void TestLoginView()
        {
            // Arange

            AccountController controller = new AccountController();

            // Act

            var result = controller.Login("home") as ViewResult;

            // Assert

            Assert.AreEqual("home", result.ViewBag.ReturnUrl);
        }

        [TestMethod]
        public void TestRegisterView()
        {
            // Arange

            AccountController controller = new AccountController();

            // Act

            var result = controller.Register() as ViewResult;

            // Assert

            Assert.AreEqual("Register", result.ViewName);
        }

        [TestMethod]
        public void TestForgotPasswordView()
        {
            // Arange

            AccountController controller = new AccountController();

            // Act

            var result = controller.ForgotPassword() as ViewResult;

            // Assert

            Assert.AreEqual("ForgotPassword", result.ViewName);
        }

        [TestMethod]
        public void TestForgotPasswordConfirmationView()
        {
            // Arange

            AccountController controller = new AccountController();

            // Act

            var result = controller.ForgotPasswordConfirmation() as ViewResult;

            // Assert

            Assert.AreEqual("ForgotPasswordConfirmation", result.ViewName);
        }

        [TestMethod]
        public void TestResetPasswordViewWithCode()
        {
            // Arange

            AccountController controller = new AccountController();
            string code = "123";

            // Act

            var result = controller.ResetPassword(code) as ViewResult;

            // Assert

            Assert.AreEqual("ResetPassword", result.ViewName);
        }
        
        [TestMethod]
        public void TestResetPasswordViewWithCodeNull()
        {
            // Arange

            AccountController controller = new AccountController();
            string code = null;

            // Act

            var result = controller.ResetPassword(code) as ViewResult;

            // Assert

            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void TestResetPasswordConfirmationView()
        {
            // Arange

            AccountController controller = new AccountController();

            // Act

            var result = controller.ResetPasswordConfirmation() as ViewResult;

            // Assert

            Assert.AreEqual("ResetPasswordConfirmation", result.ViewName);
        }

        [TestMethod]
        public void TestLogOffView()
        {
            // Arange

            AccountController controller = new AccountController();

            // Act

            var result = controller.LogOff() as ViewResult;

            // Assert

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void TestExternalLoginFailureView()
        {
            // Arange

            AccountController controller = new AccountController();

            // Act

            var result = controller.ExternalLoginFailure() as ViewResult;

            // Assert

            Assert.AreEqual("ExternalLoginFailure", result.ViewName);
        }
    }
}
