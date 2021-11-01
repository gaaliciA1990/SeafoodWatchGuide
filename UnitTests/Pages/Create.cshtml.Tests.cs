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
    /// <summary>
    /// Class containing all unit tests for Create page model
    /// </summary>
    public class CreateTests
    {

        #region TestSetup
        //CreteModel object used to test Create page model
        public static CreateModel pageModel;

        /// <summary>
        /// Test constructor
        /// </summary>
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
        /// <summary>
        /// Test empty OnGet function. Should not change the state of the CreateModel object
        /// </summary>
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
        /// <summary>
        /// Test OnPost method when the model state is invalid, thus redirecting
        /// the user back to the original Create page. 
        /// </summary>
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

        /// <summary>
        /// Test OnPost method when the model state is valid, thus creating
        /// a new card with the provided Product info. After that, redirecting
        /// the user back to Admin page to view all available items.
        /// </summary>
        [Test]
        public void OnPost_ValidState_createCard()
        {
            //Arrange
            //Act

            pageModel.Product = new ProductModel
            {
                Id = "123",
                Title = "testTitle",
                Description = "testDescription",
                Image = "https://test.com",
                Rating = ContosoCrafts.WebSite.Data.ProductRating.AVOID,
                Region = "West Coast"
            };

            var result = pageModel.OnPost() as RedirectToPageResult;

            //Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Admin"));

        }

        #endregion OnPost
    }
}