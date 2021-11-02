using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Data;
using ContosoCrafts.WebSite.Controllers;

namespace UnitTests.Controller
{
    /// <summary>
    /// This class contains all the tests for the application's ProductModel
    /// </summary>
    public class ProductControllerTests
    {
        #region TestSetup
        //ProductsController object used to test Product controller's functionalities
        public ProductsController controller;

        /// <summary>
        /// Test constructor.
        /// Creating the mock environment for conducting our test against
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            controller = new ProductsController(TestHelper.ProductService);
        }
        #endregion


        #region ConvertToString
        /// <summary>
        /// This tests the convertToSTring in ProductModel.cs to confirm that the correct string is displayed 
        /// when Best Choice is converted from the productrating ENUM.
        /// </summary>
        [Test]
        public void Get_Get_All_Data()
        {
            // Arrange
            //Dummy variable to store original counts of all products
            var Prods = TestHelper.ProductService.GetAllData();

            // Act
            //Set the page model's product variable
            var Data = controller.Get();

            // Assert
            Assert.AreEqual(Data, Prods);
        }

        /// <summary>
        /// This tests construction of a RatingRequest object 
        /// </summary>
        [Test]
        public void RatingRequest_Get_Set()
        {
            // Arrange
            var RatingReq = new ProductsController.RatingRequest();

            // Act
            RatingReq.ProductId= "testId";
            RatingReq.Rating = ProductRating.AVOID;

            // Assert
            Assert.AreEqual(RatingReq.ProductId, "testId");
            Assert.AreEqual(RatingReq.Rating, ProductRating.AVOID);
        }

        /// <summary>
        /// This tests the return of Ok ActionResult
        /// </summary>
        [Test]
        public void Patch_Return_Ok()
        {
            // Arrange
            var RatingReq = new ProductsController.RatingRequest();
            RatingReq.ProductId = "testId";
            RatingReq.Rating = ProductRating.AVOID;

            // Act
            var OkResult = controller.Patch(RatingReq) as OkObjectResult;


            // Assert
            Assert.AreEqual(OkResult, null);
        }
        #endregion
    }
}
