
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Models;
using System.Linq;

namespace UnitTests.Pages.Product.Update
{
    public class UpdateTests
    {
        #region TestSetup
        public static UpdateModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("Crab");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Crab: Southern King (Argentina)", pageModel.Product.Title);
        }
        #endregion OnGet


        #region OnPost

        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        [Test]
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange

            pageModel.Product = new ProductModel
            {
                Id = "Crab",
                Image = "data/Fish_img/Crab.bmp",
                Rating = ContosoCrafts.WebSite.Data.Product_Rating.AVOID,
                Description = "Blue crab caught in Maryland's Chesapeake Bay waters with trotlines is a Best Choice. The stock is healthy, and overfishing is a low concern. The trotline fishery doesn't catch any other species, and management is rated highly effective. There are no major concerns about seafloor impacts, but ecosystem-based management measures haven't been implemented.",
                Region = "West Coast",
                Title = "Crab: Southern King(Argentina)"
            };
            

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Admin"));
        }
        #endregion OnPost

    }
}