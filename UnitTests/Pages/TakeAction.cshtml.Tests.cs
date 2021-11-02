using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.TakeAction
{
    /// <summary>
    /// Class to contain all tests for TakeAction page
    /// </summary>
    public class TakeActionTests
    {
        #region TestSetup
        //AboutModel object used to test our About page model
        public static AboutModel AboutModel;

        /// <summary>
        /// Set up the test framework
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<AboutModel>>();

            AboutModel = new AboutModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }
        #endregion TestSetup


        #region OnGet
        /// <summary>
        /// Test OnGet function on Privacy model
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange

            // Act
            AboutModel.OnGet();

            // Assert
            Assert.AreEqual(true, AboutModel.ModelState.IsValid);
        }
        #endregion OnGet
    }
}
