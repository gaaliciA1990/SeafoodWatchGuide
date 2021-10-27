
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Models;
using System.Linq;

namespace UnitTests.Pages.Update
{
    public class UpdateTests
    {
        #region TestSetup
        public static UpdateModel pageModel;

        /// <summary>
        /// test constructor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// Test OnGet function with valid state, which it should then fetch the
        /// correct item to get updated
        /// </summary>
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
        /// <summary>
        /// test OnPost function with invalid state, which it should not allow
        /// the update to happen. Done by checking if the model state is invalid
        /// </summary>
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

        /// <summary>
        /// Test OnPost function with valid state, which should allow the update
        /// to happen. Done by checking if the model is in valid state, if update
        /// happened, the function should also redirect the user back to
        /// Admin page.
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange

            pageModel.Product = new ProductModel
            {
                Id = "Crab",
                Image = "data/Fish_img/Crab.bmp",
                Rating = ContosoCrafts.WebSite.Data.ProductRating.AVOID,
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