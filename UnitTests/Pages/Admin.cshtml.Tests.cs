using System;
using System.Collections.Generic;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;
using Moq;

namespace UnitTests.Pages.Admin
{
    /// <summary>
    /// Class containing all unit tests for Admin page
    /// </summary>
    public class AdminTests
    {
        #region TestSetup
        //AdminModel object used to test Admin page's model
        public static AdminModel PageModel;

        /// <summary>
        /// Test constructor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<AdminModel>>();

            PageModel = new AdminModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }


        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// test OnGet function when it fetches all data to be shown
        /// </summary>
        [Test]
        public void OnGet_get_all_data()
        {
            // Arrange
            var randomProduct = TestHelper.ProductService.GetAllData();
            // Act
            PageModel.OnGet();

            //Reset

            // Assert
            Assert.AreEqual(PageModel.Products.Count(), randomProduct.Count());

        }

        /// <summary>
        /// Test OnGetCreate when user hits the Create button, they should be
        /// redirected to the Create page
        /// </summary>
        [Test]
        public void OnGetCreate_redirect()
        {
            // Arrange
            // Act
            var page = PageModel.OnGetCreate() as RedirectToPageResult;

            //Reset

            // Assert
            Assert.AreEqual("Create", page.PageName);

        }

        /// <summary>
        /// Test OnGetClear method which clears all data from the filter
        /// </summary>
        [Test]
        public void OnGetClear_Should_Clear_All_Filter_Data()
        {
            // Arrange
            PageModel.Filter.Region = "West Coast";
            PageModel.Filter.Rating = ContosoCrafts.WebSite.RatingEnums.ProductRating.BEST_CHOICE;

            var testOriginal = new FilterModel()
            {
                Region = PageModel.Filter.Region,
                Rating = PageModel.Filter.Rating
            };
            
            // Act
            PageModel.OnGetClear();

            //Reset

            //Assert
            Assert.AreEqual("West Coast", testOriginal.Region);
            Assert.AreEqual(ContosoCrafts.WebSite.RatingEnums.ProductRating.BEST_CHOICE, testOriginal.Rating);

            Assert.AreEqual(null, PageModel.Filter.Region);
            Assert.AreEqual(ContosoCrafts.WebSite.RatingEnums.ProductRating.UNKNOWN, PageModel.Filter.Rating);
        }

        #endregion OnGet

        #region OnPost
        /// <summary>
        /// Tests OnPost method where product list is filtered by stated criteria
        /// </summary>
        [Test]
        public void OnPost_Should_Return_Product_According_To_Region_Filter()
        {
            //Arrange
            PageModel.Filter.Region = "West Coast";

            IEnumerable<ProductModel> productList = PageModel.ProductService.GetAllData();
            productList = productList.Where(m => m.Region.Equals("West Coast"));

            //Act
            PageModel.OnPost();

            //Reset

            //Assert
            Assert.AreEqual(productList.ToString(), PageModel.Products.ToString());
        }

        /// <summary>
        /// Tests OnPost method where product list is filtered by stated criteria
        /// </summary>
        [Test]
        public void OnPost_Should_Return_Product_According_To_Rating_Filter()
        {
            //Arrange
            PageModel.Filter.Rating = ContosoCrafts.WebSite.RatingEnums.ProductRating.BEST_CHOICE;

            IEnumerable<ProductModel> productList = PageModel.ProductService.GetAllData();
            productList = productList.Where(m => m.Rating.Equals(ContosoCrafts.WebSite.RatingEnums.ProductRating.BEST_CHOICE));


            //Act
            PageModel.OnPost();

            //Reset

            //Assert
            Assert.AreEqual(productList.ToString(), PageModel.Products.ToString());
        }

        /// <summary>
        /// Tests OnPost method where product list is filtered by stated criteria
        /// </summary>
        [Test]
        public void OnPost_Should_Return_Product_According_To_Region_And_Rating_Filters()
        {
            //Arrange
            PageModel.Filter.Region = "West Coast";
            PageModel.Filter.Rating = ContosoCrafts.WebSite.RatingEnums.ProductRating.BEST_CHOICE;

            IEnumerable<ProductModel> productList = PageModel.ProductService.GetAllData();
            productList = productList.Where(m => m.Region.Equals("West Coast"));
            productList = productList.Where(m => m.Rating.Equals(ContosoCrafts.WebSite.RatingEnums.ProductRating.BEST_CHOICE));


            //Act
            PageModel.OnPost();

            //Reset

            //Assert
            Assert.AreEqual(productList.ToString(), PageModel.Products.ToString());
        }
        #endregion OnPost
    }
}