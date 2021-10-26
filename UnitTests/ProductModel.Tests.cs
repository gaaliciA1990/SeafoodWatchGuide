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
using Moq;

namespace UnitTests.Model
{
    public class ProductModelTests
    {
        /// <summary>
        /// Setting up the testing environment for the Region page
        /// </summary>
        #region TestSetup
        public ProductModel model;

        /// <summary>
        /// Creating the mock environment for conducting our test against
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            model = new ProductModel();
        }
        #endregion

        /// <summary>
        /// This tests the convertToSTring in ProductModel.cs to confirm that the correct string is displayed 
        /// when converted from the productrating ENUM. 
        /// TODO: Update method code to capitalize the first letter of each word.
        /// </summary>
        #region ConvertToString

        [Test]
        public void ConvertToString_Valid_String_For_BestChoice_ENUM()
        {
            // Arrange - not needed

            // Act
            var result = ProductModel.covertToString(ContosoCrafts.WebSite.Data.ProductRating.BEST_CHOICE);

            // Assert
            Assert.AreEqual("Best choice", result);
        }

        [Test]
        public void ConvertToString_Valid_String_For_GoodAlt_ENUM()
        {
            // Arrange - not needed

            // Act
            var result = ProductModel.covertToString(ContosoCrafts.WebSite.Data.ProductRating.GOOD_ALTERNATIVE);

            // Assert
            Assert.AreEqual("Good alternative", result);

        }

        [Test]
        public void ConvertToString_Valid_String_For_Avoid_ENUM()
        {
            // Arrange - not needed

            // Act
            var result = ProductModel.covertToString(ContosoCrafts.WebSite.Data.ProductRating.AVOID);

            // Assert
            Assert.AreEqual("Avoid", result);

        }
        #endregion

    }
}
