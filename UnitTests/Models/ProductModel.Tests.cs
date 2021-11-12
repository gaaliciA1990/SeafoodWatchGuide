using System;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using ContosoCrafts.WebSite.RatingEnums;

namespace UnitTests.Model
{
    /// <summary>
    /// This class contains all the tests for the application's ProductModel
    /// </summary>
    public class ProductModelTests
    {
        #region TestSetup
        //ProductModel object used to test Product model's functionalities
        public ProductModel Model;

        /// <summary>
        /// Test constructor.
        /// Creating the mock environment for conducting our test against
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            Model = new ProductModel();
        }
        #endregion


        #region ConvertToString
        /// <summary>
        /// UT for testing the serializer is acting as expected. Author
        /// unknown?
        /// </summary>
        [Test]
        public void ToString_Serialize()
        {
            // Arrange
            String Json = "{\"Id\":\"id\",\"Title\":\"title\",\"Region\":\"region\",\"Rating\":\"" + ProductRating.BEST_CHOICE + "\",\"Description\":\"description\",\"img\":\"image\"}";
            var obj = new ProductModel()
            {
                Id = "id",
                Region = "region",
                Image = "image",
                Title = "title",
                Description = "description",
                Rating = ProductRating.BEST_CHOICE
            };

            // Act
            var serialized = obj.ToString();

            System.Diagnostics.Debug.WriteLine(Json);
            System.Diagnostics.Debug.WriteLine(serialized);

            //Reset

            // Assert
            Assert.AreEqual(serialized, Json);
        }
        #endregion
    }
}
