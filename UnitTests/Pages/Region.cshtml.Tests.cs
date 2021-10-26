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

namespace UnitTests.Pages.Region
{
    /// <summary>
    /// Unit testing for the Region page to ensure errors we can predict
    /// are covered.
    /// </summary>
    public class RegionTests
    {
        /// <summary>
        /// Setting up the testing environment for the Region page
        /// </summary>
        #region TestSetup
        public static RegionModel pageModel;

        /// <summary>
        /// Creating the mock environment for conducting our test against
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<RegionModel>>();

            pageModel = new RegionModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }
        #endregion

        /// <summary>
        /// This tests the OnGet for region.cshtml.cs to confirm that the correct region is pulled 
        /// when called
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Region_For_Data_Pulled()
        {
            // Arrange
            string region = "Central";

            // Act
            pageModel.OnGet(region);

            // Assert
            Assert.AreEqual("Central", pageModel.region);
        }
        #endregion
    }
}
