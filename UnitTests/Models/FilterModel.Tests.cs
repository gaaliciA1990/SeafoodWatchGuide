
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using ContosoCrafts.WebSite.Data;

namespace UnitTests.Model
{
    public class FilterModelTests
    {
        #region TestSetup
        //ProductModel object used to test FilterModel's functionalities
        public FilterModel Model;

        /// <summary>
        /// Test constructor.
        /// Creating the mock environment for conducting our test against
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            Model = new FilterModel();
        }
        #endregion


        #region ClearData
        /// <summary>
        /// This tests the ClearData method in FilterModel, which should
        /// reset all filter criteria to default values
        /// </summary>
        [Test]
        public void ClearData_Should_Reset_All_Data_To_Default()
        {
            // Arrange
            Model.Rating = ProductRating.BEST_CHOICE;
            Model.Region = "West Coast";
            FilterModel testOriginal = new FilterModel
            {
                Rating = Model.Rating,
                Region = Model.Region
            };

        // Act
        Model.ClearData();

            //Reset

            // Assert
            Assert.AreEqual("West Coast", testOriginal.Region);
            Assert.AreEqual(ProductRating.BEST_CHOICE, testOriginal.Rating);
            Assert.AreEqual(null, Model.Region);
            Assert.AreEqual(ProductRating.UNKNOWN, Model.Rating);
        }

        #endregion ClearData
    }
}