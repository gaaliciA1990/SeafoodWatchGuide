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

        [Test]
        public void UpdateCard_inValid_Product_Should_Return_Null()
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
            var result = TestHelper.ProductService.UpdateCard(origin_data);


            //Assert
            Assert.AreEqual(result, null);
        }


        [Test]
        public void UpdateCard_Valid_Product_Should_Return_Updated_Product()
        {

            // Arrange
            var data = TestHelper.ProductService.GetAllData().First();
            string defaultDesription = data.Description;
            data.Description = "Test Test Test";

            //Act
            var result = TestHelper.ProductService.UpdateCard(data);
            var updated_data = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(data.Id));

            //Reset
            data.Description = defaultDesription;
            TestHelper.ProductService.UpdateCard(data);

            //Assert
            Assert.AreEqual("Test Test Test", updated_data.Description);
        }


        [Test]
        public void GetRegionData_inValid_Product_Should_Return_Empyt_IEnumerable()
        {

            // Arrange
            string testing_region = "no exist region";


            //Act
            var result = TestHelper.ProductService.GetRegionData(testing_region);


            //Assert
            Assert.IsEmpty(result);
        }

    }
}
