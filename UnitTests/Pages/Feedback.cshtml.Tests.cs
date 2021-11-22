using System.Linq;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;
using Moq;

namespace UnitTests.Pages.Feedback
{
    /// <summary>
    /// Class containing all unit tests for Index page
    /// </summary>
    public class FeedbackTests
    {

        #region TestSetup
        //pageModel represents the Index model used to get tested
        public static IndexModel PageModel;

        /// <summary>
        /// Test constructor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();

            PageModel = new IndexModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Test OnGet function on Privacy model
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_Valid_Model_State()
        {
            // Arrange

            // Act
            PageModel.OnGet();

            // Assert
            Assert.AreEqual(true, PageModel.ModelState.IsValid);
        }
        #endregion OnGet
    }
}