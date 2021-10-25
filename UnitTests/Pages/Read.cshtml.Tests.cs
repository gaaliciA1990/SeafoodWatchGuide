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
        public void OnGetDelete_redirect()
        {
            // Arrange
            // Act
            var sampleProduct = TestHelper.ProductService.GetAllData().FirstOrDefault();
            var page = pageModel.OnGetDelete(sampleProduct.Id) as RedirectToPageResult;

            // Assert
            Assert.AreEqual("Delete", page.PageName);
            
        }

        
        [Test]
        public void OnGet_get_data()
        {
            // Arrange
            // Act
            var randomProduct = TestHelper.ProductService.GetAllData().FirstOrDefault();
            var sampleProduct = TestHelper.ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(randomProduct.Id));
            pageModel.OnGet(sampleProduct.Id);

            // Assert
            Assert.AreEqual(sampleProduct.Id, pageModel.Product.Id);

        }

        [Test]
        public void OnGetUpdate_redirect()
        {
            // Arrange
            // Act
            var sampleProduct = TestHelper.ProductService.GetAllData().FirstOrDefault();
            var page = pageModel.OnGetUpdate(sampleProduct.Id) as RedirectToPageResult;

            // Assert
            Assert.AreEqual("Update", page.PageName);

        }

        #endregion OnGet
    }
}