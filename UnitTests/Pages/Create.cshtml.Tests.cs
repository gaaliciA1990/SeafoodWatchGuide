using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
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
        //CreateModel object used to test Create page model
        public static CreateModel PageModel;

        /// <summary>
        /// Test constructor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<CreateModel>>();

            PageModel = new CreateModel(MockLoggerDirect, TestHelper.ProductService)
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

            //Act
            PageModel.OnGet();

            //Reset

            //Assert
            Assert.AreEqual(null, PageModel.Product);

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
            PageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = PageModel.OnPost() as ActionResult;

            //Reset

            // Assert
            Assert.AreEqual(false, PageModel.ModelState.IsValid);

        }

        /// <summary>
        /// Test OnPost method when the Title field is just a string with
        /// numbers and symbols. Should return to Create page with the error
        /// message
        /// </summary>
        [Test]
        public void OnPost_Title_Has_Only_Numbers_Return_To_Page()
        {
            //Arrange
            PageModel.Product = new ProductModel
            {
                Id = "123",
                Title = "12345678(*@#*@#",
                Description = "testDescription",
                Image = "https://test.com",
                Rating = ContosoCrafts.WebSite.RatingEnums.ProductRating.AVOID,
                Region = "West Coast"
            };

            //Act
            var result = PageModel.OnPost();

            //Reset
            PageModel.ModelState.AddModelError("bogus", "bogus error");

            //Assert
            Assert.AreEqual(false, PageModel.ModelState.IsValid);
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
            PageModel.Product = new ProductModel
            {
                Id = "123",
                Title = "testTitle",
                Description = "testDescription",
                Image = "https://test.com",
                Rating = ContosoCrafts.WebSite.RatingEnums.ProductRating.AVOID,
                Region = "West Coast"
            };
            //Act
            var result = PageModel.OnPost() as RedirectToPageResult;

            //Reset

            //Assert
            Assert.AreEqual(true, PageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Admin"));

        }

        #endregion OnPost
    }
}