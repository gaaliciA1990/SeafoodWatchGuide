using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Models;
using System.Linq;
using Newtonsoft.Json;

namespace UnitTests.Services
{
    class JsonFileProductServiceTests
    {
         #region TestSetup
        [SetUp]
        public void Setup()
        {
        }
        #endregion TestSetup


        [Test]
        public void CreateCard_Valid_Product_Should_Return_True()
        {

            // Arrange
            var origin_data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Region = "West Coast",
                Image = "testing image",
                Title = "testing title",
                Description = "Enter URL",
                Rating = ContosoCrafts.WebSite.Data.Product_Rating.AVOID,
            };

            //Act
            TestHelper.ProductService.CreateCard(origin_data);
            var dataSet = TestHelper.ProductService.GetAllData();

            //Reset
            TestHelper.ProductService.DeleteCard(origin_data.Id);

            //Assert
            var newCreate = dataSet.FirstOrDefault(m => m.Id.Equals(origin_data.Id));

            var origin_data_json= JsonConvert.SerializeObject(origin_data);
            var newCreate_json = JsonConvert.SerializeObject(newCreate);

            Assert.AreEqual(origin_data_json, newCreate_json);
        }

    }
}
