using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.RatingEnums;
using ContosoCrafts.WebSite.Controllers;
using System.Linq;

namespace UnitTests.Controller
{
    /// <summary>
    /// This class contains all the tests for the application's ProductModel
    /// </summary>
    public class FeedbackControllerTests
    {
        #region TestSetup
        //ProductsController object used to test Product controller's functionalities
        public FeedbackController Controller;

        /// <summary>
        /// Test constructor.
        /// Creating the mock environment for conducting our test against
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            Controller = new FeedbackController(TestHelper.FeedbackService);
        }
        #endregion


        #region ConvertToString
        /// <summary>
        /// This tests the convertToSTring in ProductModel.cs to confirm that the correct string is displayed 
        /// when Best Choice is converted from the productrating ENUM.
        /// </summary>
        [Test]
        public void GetAllData_Valid_Should_Return_True()
        {
            // Arrange
            //Dummy variable to store original counts of all products
            var randomProduct = TestHelper.FeedbackService.GetAllFeedback();

            // Act
            //Set the page model's product variable
            var Data = Controller.Get();

            //Reset

            // Assert
            Assert.AreEqual(Data.Count(), randomProduct.Count());
        }

        /// <summary>
        /// This tests construction of a RatingRequest object 
        /// </summary>
        [Test]
        public void CreateFeedback_Valid_Should_Return_True()
        {
            // Arrange
            var FeedbackReq = new FeedbackController.FeedbackRequest();

            // Act
            FeedbackReq.ID = "testId";
            FeedbackReq.Rating = 3;
            FeedbackReq.Comment = "test comment";


            //Reset

            // Assert
            Assert.AreEqual(FeedbackReq.ID, "testId");
            Assert.AreEqual(FeedbackReq.Rating, 3);
            Assert.AreEqual(FeedbackReq.Comment, "test comment");
        }

        /// <summary>
        /// This tests the return of Ok ActionResult
        /// </summary>
        [Test]
        public void FeebackRequest_Invalid_Should_Return_Null()
        {
            // Arrange
            var FeedbackReq = new FeedbackController.FeedbackRequest();
            FeedbackReq.ID = "testId";
            FeedbackReq.Rating = 3;
            FeedbackReq.Comment = "test comment";

            // Act
            var OkResult = Controller.Patch(FeedbackReq) as OkObjectResult;

            //Reset

            // Assert
            Assert.AreEqual(OkResult, null);
        }
        #endregion
    }
}