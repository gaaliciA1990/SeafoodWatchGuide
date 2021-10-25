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

namespace UnitTests.Pages.Read
{
    public class ReadTests
    {
        #region TestSetup
        public static ReadModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<ReadModel>>();

            pageModel = new ReadModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }


        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGetDelete_delete_card()
        {
            // Arrange
            // Act
            var sampleProduct = TestHelper.ProductService.GetAllData().FirstOrDefault();
            var page = pageModel.OnGetDelete(sampleProduct.Id) as RedirectToPageResult;

            // Assert
            Assert.AreEqual("Delete", page.PageName);
            
        }

        #endregion OnGet
    }
}