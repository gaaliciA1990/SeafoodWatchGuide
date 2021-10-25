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

namespace UnitTests.Pages.Admin
{
    public class AdminTests
    {
        #region TestSetup
        public static AdminModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<AdminModel>>();

            pageModel = new AdminModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }


        #endregion TestSetup

        #region OnGet

        [Test]
        public void OnGet_get_all_data()
        {
            // Arrange
            // Act
            var randomProduct = TestHelper.ProductService.GetAllData();
            pageModel.OnGet();
            
            // Assert
            Assert.AreEqual(pageModel.Products.Count(), randomProduct.Count());

        }

        [Test]
        public void OnGetCreate_redirect()
        {
            // Arrange
            // Act
            var page = pageModel.OnGetCreate() as RedirectToPageResult;

            // Assert
            Assert.AreEqual("Create", page.PageName);

        }

        #endregion OnGet
    }
}