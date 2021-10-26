using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.About
{
    public class PrivacyTests
    {
        #region TestSetup
        public static AboutModel AboutModel;

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
