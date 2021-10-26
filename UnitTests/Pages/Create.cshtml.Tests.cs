using System;
using System.Collections.Generic;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;
using Moq;

namespace UnitTests.Pages.Create
{
    public class CreateTests
    {

        #region TestSetup
        public static CreateModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<CreateModel>>();

            pageModel = new CreateModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_initial_setup()
        {
            //Arrange
            pageModel.OnGet();

            //Assert
            Assert.AreEqual(null, pageModel.Product);

        }
        #endregion OnGet

        #region OnPost
        [Test]
        public void OnPost_invalidState_returnToPage()
        {
            //Arrange
            //Act
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);

        }

        #endregion OnPost
    }
}