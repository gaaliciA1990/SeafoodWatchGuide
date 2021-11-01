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

namespace UnitTests.Pages.Index
{
    /// <summary>
    /// Class containing all unit tests for Index page
    /// </summary>
    public class IndexTests
    {

        #region TestSetup
        //pageModel represents the Index model used to get tested
        public static IndexModel pageModel;

        /// <summary>
        /// Test constructor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();

            pageModel = new IndexModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup


        #region OnGet
        /// <summary>
        /// Test OnGet function where all data should be retrieved successfully
        /// to be shown.
        /// </summary>
        [Test]
        public void OnGet_get_all_data()
        {
            // Arrange
            //Dummy variable to store original counts of all products
            var randomProduct = TestHelper.ProductService.GetAllData();

            // Act
            //Set the page model's product variable
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(pageModel.Products.Count(), randomProduct.Count());
        }
        #endregion OnGet
    }
}