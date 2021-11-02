using System;
using System.Collections.Generic;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Data;
using Moq;

namespace UnitTests.Model
{
    /// <summary>
    /// This class contains all the tests for the application's ProductModel
    /// </summary>
    public class ProductModelTests
    {
        #region TestSetup
        //ProductModel object used to test Product model's functionalities
        public ProductModel model;

        /// <summary>
        /// Test constructor.
        /// Creating the mock environment for conducting our test against
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            model = new ProductModel();
        }
        #endregion


        #region ConvertToString
        /// <summary>
        /// This tests the convertToSTring in ProductModel.cs to confirm that the correct string is displayed 
        /// when Best Choice is converted from the productrating ENUM.
        /// </summary>
        [Test]
        public void ConvertToString_Valid_String_For_BestChoice_ENUM()
        {
            // Arrange - not needed

            // Act
            var result = ProductModel.covertToString(ContosoCrafts.WebSite.Data.ProductRating.BEST_CHOICE);

            // Assert
            Assert.AreEqual("Best choice", result);
        }

        /// <summary>
        /// This tests the convertToSTring in ProductModel.cs to confirm that the correct string is displayed 
        /// when Good Alternative is converted from the productrating ENUM.
        /// </summary>
        [Test]
        public void ConvertToString_Valid_String_For_GoodAlt_ENUM()
        {
            // Arrange - not needed

            // Act
            var result = ProductModel.covertToString(ContosoCrafts.WebSite.Data.ProductRating.GOOD_ALTERNATIVE);

            // Assert
            Assert.AreEqual("Good alternative", result);

        }

        /// <summary>
        /// This tests the convertToSTring in ProductModel.cs to confirm that the correct string is displayed 
        /// when Avoid is converted from the productrating ENUM.
        /// </summary>
        [Test]
        public void ConvertToString_Valid_String_For_Avoid_ENUM()
        {
            // Arrange - not needed

            // Act
            var result = ProductModel.covertToString(ContosoCrafts.WebSite.Data.ProductRating.AVOID);

            // Assert
            Assert.AreEqual("Avoid", result);

        }

        /// <summary>
        /// UT for testing the serializer is acting as expected. Author
        /// unknown?
        /// </summary>
        [Test]
        public void ToString_Serialize()
        {
            // Arrange
            String Json = "{\"Id\":\"id\",\"Region\":\"region\",\"img\":\"image\",\"Title\":\"title\",\"Description\":\"description\",\"Rating\":\""+ProductRating.BEST_CHOICE+"\"}";

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
            // Assert
            Assert.AreEqual(serialized, Json);
        }
        #endregion
    }
}
